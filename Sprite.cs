using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CommNetPong
{
    public class Sprite
    {

        public Texture2D texture;
        public Vector2 position;
        public Vector2 size;
        public Vector2 screenSize;

        // Constructor to handle sprites with sphere and boxes
        public Sprite(Texture2D t, Vector2 p, Vector2 s, int ScreenWidth, int ScreenHeight)
        {
            texture = t;
            position = p;
            size = s;
            screenSize = new Vector2(ScreenWidth, ScreenHeight);
        }

        //Update 
        public void Update(Vector2 pos)
        {
            position = pos;
        }

    }
}
