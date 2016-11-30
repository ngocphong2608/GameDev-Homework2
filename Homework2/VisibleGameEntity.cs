using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2
{
    public abstract class VisibleGameEntity : GameEntity
    {
        public abstract void Draw(GameTime gameTime, object helper);
    }
}