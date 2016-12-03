using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public class TilingMap: Map
    {
        private int[,] HeightData;
        protected MyTexture[,] MapFragments;
        protected int nRows;
        protected int nCols;
        protected int Left; // c1: hoanh do cua goc toa do man hinh so voi World
        protected int Top; // r1: tung do cua goc toa do man hinh so voi World
        protected int FragmentWidth;
        protected int FragmentHeight;

        public TilingMap(string strHeighMapResource, int Left, int Top, int FragmentWidth, int FragmentHeight)
        {
            // TODO: Complete member initialization
            // MainModel = null;
            LoadHeightDataFromHeightMap(strHeighMapResource);

            this.Left = Left;
            this.Top = Top;
            this.FragmentHeight = FragmentHeight;
            this.FragmentWidth = FragmentWidth;
            CreateAllMapFragments();
        }

        private void CreateAllMapFragments()
        {
            MapFragments = new MyTexture[nRows, nCols];
            for (int r=0; r<nRows; r++)
                for (int c=0; c<nCols; c++)
                {
                    MapFragments[r, c]= new MyTexture(GetTexturesResourceNameFromHeight(HeightData[r,c]),
                        Left + c * FragmentWidth,
                        Top + r * FragmentHeight,
                        FragmentWidth,
                        FragmentHeight);

                }
        }

        private string GetTexturesResourceNameFromHeight(int h)
        {
            string strFilename = "Snow";
            if (h < 64)
                strFilename = "Water";
            else if (h < 128)
                strFilename = "Grass";
            else if (h < 192)
                strFilename = "Highland";
            else if (h < 210)
                strFilename = "Red";
            // 193 -> 210 special

            return strFilename;

        }

        private void LoadHeightDataFromHeightMap(string strHeighMapResource)
        {
            
            Texture2D temp = Global.Content.Load<Texture2D>(strHeighMapResource);
            this.nRows = temp.Height;
            this.nCols = temp.Width;

            HeightData = new int[nRows, nCols];
            Color[] colorData = new Color[nRows * nCols];
            temp.GetData<Color>(colorData);

            for (int r = 0; r < nRows; r++)
            {
                for (int c = 0; c < nCols; c++)
                {
                    HeightData[r, c] = colorData[r * nCols + c].R;
                }
            }

        }

        public override void Update(GameTime gameTime)
        {
            for (int r = 0; r < nRows; r++)
                for (int c = 0; c < nCols; c++)
                    MapFragments[r, c].Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, object helper)
        {
            for (int r = 0; r < nRows; r++)
                for (int c = 0; c < nCols; c++)
                    if (IsVisible(r, c))
                        MapFragments[r, c].Draw(gameTime, helper);
        }

        private bool IsVisible(int r, int c)
        {
            return true;
        }

        public void Translate(Vector2 vector2)
        {
            Left += (int)vector2.X;
            Top += (int)vector2.Y;
            Global.Camera.Translate(vector2);
        }
    }
}
