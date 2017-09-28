using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using CityGeneration.Entitie;
using CityGeneration.Util;

namespace CityGeneration.Entitie.Player
{
    public class Player : Sprite
    {
        private Rectangle _Hitbox;
        private Texture2D _PlayerTexture;

        private float _angleTo;
        private float _moveSpeed = 2.5f;

        private Vector2 _rCamPos;
        public Vector2 CurrentCamPos
        {
            set { _rCamPos = value; }
        }

        public float Speed
        {
            get { return _moveSpeed; }
            set { _moveSpeed = value; }
        }

        public Player(ContentManager cm, Texture2D Texture, Vector2 Pos, Vector2 Origin) : base (Pos, Origin)
        {
            _PlayerTexture = Texture;
            UpdateHitbox();
        }

        private Rectangle UpdateHitbox()
        {
            return new Rectangle((int)GetPosition.X,(int)GetPosition.Y,_PlayerTexture.Width, _PlayerTexture.Height);
        }

        public override void Update()
        {
            var ms = Mouse.GetState();
            var ks = Keyboard.GetState();

            UpdateRotation(ms);

            Vector2 dir = new Vector2((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
            dir.Normalize();

            if (ks.IsKeyDown(Keys.W) || ks.IsKeyDown(Keys.Up))
            {
                GetPosition -= dir * _moveSpeed;
            }

            if (ks.IsKeyDown(Keys.S))
            {
                GetPosition -= dir * (_moveSpeed * -1);
            }

            if (ks.IsKeyDown(Keys.A))
            {
                dir = new Vector2((float)Math.Cos(Rotation - (Math.PI * 2) / 4), (float)Math.Sin(Rotation - (Math.PI * 2) / 4));

                GetPosition -= dir * _moveSpeed;
            }

            if (ks.IsKeyDown(Keys.D))
            {
                dir = new Vector2((float)Math.Cos(Rotation + (Math.PI * 2) / 4), (float)Math.Sin(Rotation + (Math.PI * 2) / 4));

                GetPosition -= dir * _moveSpeed;
            }
        }

        // https://stackoverflow.com/questions/8584470/xna-2d-point-object-to-cursor-over-time
        private void UpdateRotation(MouseState ms)
        {
            Vector2 mPos = new Vector2(ms.X + _rCamPos.X, ms.Y + _rCamPos.Y);
            Vector2 dPos = GetPosition - mPos;

            _angleTo = (float)Math.Atan2(dPos.Y, dPos.X);
            Rotation = MathHelper.WrapAngle(Rotation);

            Rotation = _angleTo;
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(_PlayerTexture, GetPosition, null, Color.White, Rotation, Origin, 1, SpriteEffects.None, 0f);
        }
    }
}
