using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace CityGeneration.Util
{
    public class Camera
    {
        private float _zoom;
        private float _zoomAmount;

        private Matrix _transform;
        private Vector2 _position;
        private float _rotation;

        private int _WindowWidth;
        private int _WindowHeight;

        private bool _followingPlayer;

        public Camera(int WindowWidth, int WindowHeight)
        {
            _zoom = 1.0f;
            _zoomAmount = 0.05f;
            _rotation = 0.0f;
            _position = Vector2.Zero;
            _WindowWidth = WindowWidth;
            _WindowHeight = WindowHeight;
        }

        public float Zoom
        {
            get { return _zoom; }
            set
            {
                _zoom = value;
                if (_zoom < 0.1f)
                    _zoom = 0.1f;
            }
        }

        public float ZoomAmount
        {
            get { return _zoomAmount; }
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        public Vector2 GetPosition
        {
            get { return _position; }
            set { _position = value; }
        }

        public bool FollowingPlayer
        {
            get { return _followingPlayer; }
            set { _followingPlayer = value; }
        }

        public void Move(Vector2 amount)
        {
            _position += amount;
        }

        public void Update(Vector2 PlayerPos)
        {
            if (FollowingPlayer)
                FollowPlayer(PlayerPos);
        }

        public void FollowPlayer(Vector2 PlayerPos)
        {
            _position.X = PlayerPos.X - (_WindowWidth / 2);
            _position.Y = PlayerPos.Y - (_WindowHeight / 2);
        }

        public Matrix getTransformation(GraphicsDevice gd)
        {
            _transform = Matrix.CreateTranslation(new Vector3(-_position.X, -_position.Y, 0)) *
                                                  Matrix.CreateRotationZ(Rotation) *
                                                  Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                                                  Matrix.CreateTranslation(new Vector3(gd.Viewport.Width * 0.0f, gd.Viewport.Height * 0.0f, 0));
            return _transform;
        }
    }
}
