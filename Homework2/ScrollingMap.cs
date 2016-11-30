using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Homework2
{
    public class ScrollingMap : Map
    {
        protected MyTexture[,] MapFragments;
        protected int nRows;
        protected int nCols;
        protected int Left; // c1: hoanh do cua goc toa do man hinh so voi World
        protected int Top; // r1: tung do cua goc toa do man hinh so voi World
        protected int FragmentWidth;
        protected int FragmentHeight;

        public ScrollingMap()
        {

        }
        public ScrollingMap(string strResourceName, int nRows, int nCols, int Left, int Top, int FragmentWidth, int FragmentHeight)
        {
            // TODO: Complete member initialization
            
            this.nRows = nRows;
            this.nCols = nCols;
            this.Left = Left;
            this.Top = Top;
            this.FragmentHeight = FragmentHeight;
            this.FragmentWidth = FragmentWidth;
            CreateAllMapFragments(strResourceName, nRows, nCols, Left, Top, FragmentWidth, FragmentHeight);            
        }

        private void CreateAllMapFragments(string strResourceName, int nRows, int nCols, int Left, int Top, int FragmentWidth, int FragmentHeight)
        {
            MapFragments = new MyTexture[nRows, nCols];
            for (int r =0; r<nRows; r++)
                for (int c = 0; c < nCols; c++)
                {
                    MapFragments[r, c] = new MyTexture(
                        strResourceName+r.ToString("00")+"_"+c.ToString("00"), 
                        Left + c * FragmentWidth, 
                        Top + r * FragmentHeight, 
                        FragmentWidth, 
                        FragmentHeight);
                }
        }

        protected List<Texture2D> LoadTexturesFromSingleImage(string strResource)
        {
            List<Texture2D> result = new List<Texture2D>();
            result.Add(Global.Content.Load<Texture2D>(strResource));

            return result;

        }

        public override void Update(GameTime gameTime)
        {
            for (int r = 0; r < nRows; r++)
                for (int c = 0; c < nCols; c++)
                    MapFragments[r, c].Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, object Params)
        {
            for (int r = 0; r < nRows; r++)
                for (int c = 0; c < nCols; c++)
                    if (IsVisible(r, c))
                        MapFragments[r, c].Draw(gameTime, Params);
//            base.Draw(gameTime, Params);
        }

        private bool IsVisible(int r, int c)
        {
            return true;
        }

        internal void Translate(Vector2 vector2)
        {
            Left += (int)vector2.X;
            Top += (int)vector2.Y;
            Global.Camera.Translate(vector2);
        }
    }
}
