using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CityGeneration.Entitie
{
    public abstract class Sprite
    {
        private Vector2 _position;
        private Vector2 _origin;
        private float _rotation;

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

        public Vector2 Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        public Sprite(Vector2 Pos, Vector2 Origin)
        {
            _position = Pos;
            _origin = Origin;
        }

        public abstract void Update();
        public abstract void Draw(SpriteBatch sb);
    }
}
