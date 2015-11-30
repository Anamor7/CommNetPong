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
    public class Ball
    {

        public Sprite sprite;
        public Vector2 position;
        public BoundingBox boundingBox;
        public Vector2 velocity;
        public Vector2 prevVelocity;

        public Ball(Sprite s)
        {
            this.sprite = s;
            this.position = sprite.position;
            boundingBox = new BoundingBox(new Vector3(position.X, position.Y, 0), new Vector3(position.X + 7, position.Y + 7, 0));
            velocity.X = -1;
            velocity.Y = 1;
        }

        public void Update(Player p1, Player p2){
            Move(p1, p2);
            boundingBox.Min = new Vector3(position.X, position.Y, 0);
            boundingBox.Max = new Vector3(position.X + 6, position.Y + 60, 0);
            sprite.Update(position);
        }

        public void Move(Player p1, Player p2)
        {
            if (outOfBounds()){
                velocity.Y = -velocity.Y;
            }
            if (playerCollision(p1, p2)){
                velocity.X = -velocity.X;
            }
            position.X += velocity.X;
            position.Y += velocity.Y;
        }

        public bool outOfBounds()
        {
            if (position.Y <= 0 || position.Y + 7 >= 480)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool playerCollision(Player p1, Player p2)
        {
            if (boundingBox.Intersects(p1.boundingBox) || boundingBox.Intersects(p2.boundingBox))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void changeWallDirections()
        {
            //moving down and right
            if (velocity.X > 0 && velocity.Y > 0){
                velocity.Y = -velocity.Y;
            }
            //moving down and left
            else if (velocity.X > 0 && velocity.Y < 0){

            }
            //moving up and right
            else if (velocity.X < 0 && velocity.Y > 0)
            {

            }
            //moving up and left
            else
            {

            }
        }
    }
}
