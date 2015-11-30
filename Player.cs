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
    public class Player
    {
        public Sprite sprite;
        public BoundingBox boundingBox;
        public Vector2 position;
        public Vector2 velocity;
        public bool isLocal;

        public Player(Sprite s, bool local)
        {
            this.sprite = s;
            this.isLocal = local;

            this.position = sprite.position;
            boundingBox = new BoundingBox(new Vector3(position.X, position.Y, 0), new Vector3(position.X+6, position.Y+60, 0));
        }

        public void Update(KeyboardState ks){
            if (isLocal)
            {
                localUpdate(ks);
            }
            else
            {
                remoteUpdate();
            }
            boundingBox.Min = new Vector3(position.X, position.Y, 0);
            boundingBox.Max = new Vector3(position.X + 6, position.Y + 60, 0);
            sprite.Update(position);
        }

        public void localUpdate(KeyboardState ks)
        {
            if (ks.IsKeyDown(Keys.Up) && ks.IsKeyUp(Keys.Down))
            {
                if(position.Y > 0){
                    position.Y -=5 ;
                }
            }
            else if (ks.IsKeyDown(Keys.Down) && ks.IsKeyUp(Keys.Up))
            {
                if (position.Y + 60 < 480)
                {
                    position.Y += 5;
                }
            }
            
        }

        public void remoteUpdate()
        {

        }
    }
}
