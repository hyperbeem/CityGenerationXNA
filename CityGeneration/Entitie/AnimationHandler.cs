using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CityGeneration.Entitie
{
    public class AnimationHandler
    {
        private Dictionary<string, AnimationSequence> _store;

        private float _totalElapsed;

        private bool _paused;

        private float _idleTimer;
        private bool _isIdle;
        private float _idleThreshold;

        private int _frame; // Current frame
        private int _animationFrames; // Max frames in the animation
        private float _timePerFrame;
        private string _currentAnimation;

        private int _pdirection; // last direction
        private int _direction; // current direction
        private int _startPos;

        private int _width;
        private int _height;
        private int _frameWidth;
        private int _frameHeight;
        private Texture2D _texture;
        Rectangle _rec = new Rectangle(0, 0, 0, 0);

        /// <summary>
        /// Handles animations that are defined for a sprite
        /// </summary>
        public AnimationHandler(Texture2D texture, int VirticalAnimationLines, int HorizontalAnimationLines)
        {
            _store = new Dictionary<string, AnimationSequence>();

            _texture = texture;
            _width = _texture.Width;
            _height = _texture.Height;
            _frameWidth = _width / HorizontalAnimationLines;
            _frameHeight = _height / VirticalAnimationLines;
            _startPos = 0;
            _direction = 0;
            _rec = new Rectangle(_frameWidth * (_frame + _startPos), _direction * _frameHeight, _frameWidth, _frameHeight);
        }

        public bool Paused
        {
            get { return _paused; }
            set { _paused = value; }
        }

        public bool IsIdle
        {
            get { return _isIdle; }
            set { _isIdle = value; }
        }

        public float IdleThreshold
        {
            get { return _idleThreshold; }
            set { _idleThreshold = value; }
        }

        public int UpdateDirection
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public float TotalElapsed
        {
            get { return _totalElapsed; }
            set { _totalElapsed = value; }
        }

        /// <summary>
        /// Adds and animation to the list, these can be played at any time
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="StartRow"></param>
        /// <param name="StartColumn"></param>
        /// <param name="NumberOfFrames"></param>
        /// <param name="TimePerFrame"></param>
        public void Add(string Name, int StartRow, int StartColumn, int NumberOfFrames, float TimePerFrame)
        {
            _store.Add(Name, new AnimationSequence(StartRow, StartColumn, NumberOfFrames, TimePerFrame));
        }

        public void Remove(string Name)
        {
            if (_store.ContainsKey(Name))
            {
                _store.Remove(Name);
            }
            else
            {
                Console.WriteLine("Error: The animation '{0}' doesn't exist and cannot be removed", Name);
            }
        }

        public void ChangeAnimation(string Name)
        {
            if (_currentAnimation != Name)
            {
                AnimationSequence obj;
                _store.TryGetValue(Name, out obj);
                _currentAnimation = Name;

                _totalElapsed = 0.2f;
                _timePerFrame = obj.TimePerFrame;
                _animationFrames = obj.NumberOfFrames;
                _direction = obj.StartRow;
                _startPos = obj.StartColumn;
            }
        }

        public void UpdateAnimation(GameTime gameTime, bool DidChange)
        {
            if (!_paused) // stops all animation
            {
                if (!DidChange)
                {
                    _idleTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                    if (_idleTimer > _idleThreshold)
                    {
                        _totalElapsed = 0f;
                        ChangeAnimation("Idle");
                        _frame = 0;
                        _rec = new Rectangle(_frameWidth * (_frame + _startPos), _direction * _frameHeight, _frameWidth, _frameHeight);
                        _idleTimer -= _idleThreshold;
                    }
                }
                else
                {
                    _idleTimer = 0f;
                    _totalElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

                    // Should allow for instant direction change
                    if (_direction != _pdirection)

                    {
                        _totalElapsed = 0.2f;
                        _pdirection = _direction;
                    }

                    if (_totalElapsed > _timePerFrame)
                    {
                        _frame++;
                        _frame = _frame % _animationFrames;
                        _totalElapsed -= _timePerFrame;
                        _rec = new Rectangle(_frameWidth * (_frame + _startPos), _direction * _frameHeight, _frameWidth, _frameHeight);
                    }
                }
            }
        }

        public void DrawFrame(SpriteBatch batch, Vector2 CharPosition)
        {
            //batch.Draw(_texture, Camera.Position, _rec, Color.White, 0.0f, CharPosition, 1f, SpriteEffects.None, 0.0f);
        }


    }
}
