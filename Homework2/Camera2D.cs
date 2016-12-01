using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public class Camera2D : InvisibleGameEntity
    {
        private Matrix _World = Matrix.Identity;

        public Matrix World
        {
            get { return _World; }
            set { _World = value; }
        }
        private Matrix _View = Matrix.Identity;

        public Matrix View
        {
            get { return _View; }
            set { _View = value; }
        }
        private Matrix _Projection = Matrix.Identity;

        public Matrix Projection
        {
            get { return _Projection; }
        }

        public Matrix WVP // W 2 S
        {
            get
            {
                return World * View * Projection;
            }
        }

        public float TransX = 0, TransY = 0, TransZ = 0;
        public float RotX = 0, RotY = 0, RotZ = 0.0f;
        public float ScaleX = 1, ScaleY = 1, ScaleZ = 1f;
        public float PreTranX = 0, PreTranY = 0, PreTranZ = 0;

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            View = Matrix.CreateTranslation(PreTranX, PreTranY, PreTranZ) *
                Matrix.CreateScale(ScaleX, ScaleY, ScaleZ) *
                Matrix.CreateRotationX(RotX) * Matrix.CreateRotationY(RotY) * Matrix.CreateRotationZ(RotZ) *
                Matrix.CreateTranslation(TransX, TransY, TransZ);
        }

        public Matrix InvWVP // S2W
        {
            get
            {
                return Matrix.Invert(WVP);
            }
        }

        internal void Translate(float transX, float transY, int transZ)
        {
            TransX += transX;
            TransY += transY;
            TransZ += transZ;
        }

        internal void Zoom(Vector2 Center, float ScaleFactor)
        {
            PreTranX = -Center.X;
            PreTranY = -Center.Y;
            PreTranZ = 0;
            ScaleX = ScaleY = ScaleFactor;
            ScaleZ = 1;
            TransX = Center.X;
            TransY = Center.Y;
            TransZ = 0;
        }

        internal void Translate(Vector2 vector2)
        {
            TransX += vector2.X;
            TransY += vector2.Y;
            
            // Limiting camera's transformation
            if (TransX >= 0)
            {
                TransX = 0;
            } else if (TransX < -64 * 64 * ScaleX + Global.Width)
            {
                TransX = -64 * 64 * ScaleX + Global.Width;
            }
            if (TransY >= 0)
            {
                TransY = 0;
            }
            if (TransY < -64*64 * ScaleY + Global.Height)
            {
                TransY = -64 * 64 * ScaleY + Global.Height;
            }
        }
    }
}
