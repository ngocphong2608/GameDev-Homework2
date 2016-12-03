using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Homework2
{
    public class Ship : VisibleGameEntity
    {
        MyTexture main, left, right, up, down;

        // pivot position
        int x, y;
        int step = 100;

        public Ship()
        {
            left = new MyTexture("ShipLeft", 0, 0, 0, 0);
            right = new MyTexture("ShipRight", 0, 0, 0, 0);
            up = new MyTexture("ShipUp", 0, 0, 0, 0);
            down = new MyTexture("ShipDown", 0, 0, 0, 0);
            main = down;
            x = main.GetWidth() / 2;
            y = main.GetHeight() / 2;
        }

        public override void Draw(GameTime gameTime, object helper)
        {
            main.Draw(gameTime, helper);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                x -= step;
                main = left;
            } else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                x += step;
                main = right;
            } else if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                y -= step;
                main = up;
            } else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                y += step;
                main = down;
            }
            main.SetPositionBaseOnPivot(x, y);


            //base.Update(gameTime);
        }
    }
}