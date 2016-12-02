using System;
using Microsoft.Xna.Framework;

namespace Homework2
{
    public class Ship : VisibleGameEntity
    {
        MyTexture texture;

        public Ship()
        {
            texture = new MyTexture("Ship", 0, 0, 0, 0);
        }

        public override void Draw(GameTime gameTime, object helper)
        {
            texture.Draw(gameTime, helper);
        }
    }
}