using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJTTAssignment4._4.Sprites
{
    public class Ball : Sprite
    {
   
        private Vector2? _startPosition = null;
        private float? _startSpeed;
        private bool _isPlaying;
        public string winner;
        public Score Score;
       
        public Ball(Texture2D texture)
            : base(texture)
        {
            speed = 2.0f;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (_startPosition == null)
            {
                _startPosition = position;
                _startSpeed = speed;

                Restart();
            }

            //To release the ball from the middle
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                _isPlaying = true;

            if (!_isPlaying)
                return;

            

            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;

                if (this.velocity.X > 0 && this.IsTouchingLeft(sprite))
                    this.velocity.X = -this.velocity.X;
                if (this.velocity.X < 0 && this.IsTouchingRight(sprite))
                    this.velocity.X = -this.velocity.X;

                if (this.velocity.Y > 0 && this.IsTouchingTop(sprite))
                    this.velocity.Y = -this.velocity.Y;
                if (this.velocity.Y < 0 && this.IsTouchingBottom(sprite))
                    this.velocity.Y = -this.velocity.Y;
            }

            if (position.Y <= 0 || position.Y + _texture.Height >= Game1.ScreenHeight)
                velocity.Y = -velocity.Y;

            if(position.X <= 0)
            {
                Score.Score2++;
                Restart();
            }

            if (position.X + _texture.Width >= Game1.ScreenWidth)
            {
                Score.Score1++;
                Restart();
            }

            
            position += velocity * speed;
        }
        public void Restart()
        { 
            var direction = Game1.Random.Next(0, 4);

            var randomSpeed = Game1.Random.Next(3, 9);

            switch (direction)
            {
                case 0:
                    velocity = new Vector2(1, 1);
                    break;
                case 1:
                    velocity = new Vector2(1, -1);
                    break;
                case 2:
                    velocity = new Vector2(-1, -1);
                    break;
                case 3:
                    velocity = new Vector2(-1, 1);
                    break;
            }
            

            position = (Vector2)_startPosition;
            speed = randomSpeed; 
            _isPlaying = false;
        }

    }
}
