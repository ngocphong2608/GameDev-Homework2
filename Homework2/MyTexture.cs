using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2
{
    public class MyTexture : VisibleGameEntity
    {
        private Texture2D texture = null;
        private int left = 0;
        private int top = 0;
        private int width = 0;
        private int height = 0;

        public MyTexture()
        {

        }

        public MyTexture(string name)
        {
            LoadContent(name);
        }

        public MyTexture(string name, int l, int t, int w, int h)
        {
            left = l;
            top = t;
            width = w;
            height = h;
            LoadContent(name);
        }

        public void LoadContent(string name)
        {
            texture = Global.Content.Load<Texture2D>(name);
            if (width == 0)
                width = texture.Width;
            if (height == 0)
                height = texture.Height;
        }

        public override void Draw(GameTime gameTime, object helper)
        {
            SpriteBatch spriteBatch = (SpriteBatch)helper;

            spriteBatch.Draw(texture, new Vector2(left, top), Color.White);

            //if (State == 0)
            //    spriteBatch.Draw(texture, new Vector2(left, top), Color.White);
            //else
            //    spriteBatch.Draw(texture, new Vector2(left, top), Color.Black);
        }

        //public override bool IsSelected(float x, float y)
        //{
        //    if (x >= left && x < left + width
        //        && y >= top && y < top + height)
        //        return true;
        //    else
        //        return false;
        //}
    }
}