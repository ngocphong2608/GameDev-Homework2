using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Global
    {
        static public Camera2D Camera = new Camera2D();
        static public ContentManager Content;
        static public KeyboardHelper KeyboardHelper = new KeyboardHelper();
        static public MouseHelper MouseHelper = new MouseHelper();
    }
}
