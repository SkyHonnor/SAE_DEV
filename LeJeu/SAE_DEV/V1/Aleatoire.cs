using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Tiled;

namespace TheGame
{
    internal class Aleatoire
    {
        public int Hasard(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max);
        }
        public Vector2 Hasard(int minX, int maxX, int minY, int maxY)
        {
            Random x = new Random();
            Random y = new Random();
            return new Vector2(x.Next(minX, maxX), y.Next(minY, maxY));

        } 
    }
}
