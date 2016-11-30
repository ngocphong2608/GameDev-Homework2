using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Homework2
{
    public class MouseHelper: InvisibleGameEntity
    {
        private MouseState PreviousState, CurrentState;

        public override void Update(GameTime gameTime)
        {
            PreviousState = CurrentState;
            CurrentState = Mouse.GetState();
            base.Update(gameTime);
        }

        public bool IsBeginToClickLeftButton()
        {
            return PreviousState.LeftButton == ButtonState.Released &&
                CurrentState.LeftButton == ButtonState.Pressed;
        }

        public bool IsEndToClickLeftButton()
        {
            return PreviousState.LeftButton == ButtonState.Pressed &&
                CurrentState.LeftButton == ButtonState.Released;
        }


        internal float GetCurrentX()
        {
            return CurrentState.X;
        }

        internal float GetCurrentY()
        {
            return CurrentState.Y;
        }

        internal bool IsLeftButtonPressed()
        {
            return CurrentState.LeftButton == ButtonState.Pressed;
        }

        internal Vector2 GetMousePositionDifference()
        {
            return new Vector2(CurrentState.X - PreviousState.X,
                CurrentState.Y - PreviousState.Y);
        }
    }
}