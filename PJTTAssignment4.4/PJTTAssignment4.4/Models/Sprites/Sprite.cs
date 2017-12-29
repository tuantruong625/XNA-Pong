using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PJTTAssignment4._4.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PJTTAssignment4._4.Sprites
{
    public class Sprite
    {
        protected Texture2D _texture;

        public Vector2 position;
        public Vector2 velocity;
        public float speed;
        public Input input;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, _texture.Width, _texture.Height);
            }
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, position, Color.White);
        }
        /// <summary>
        /// Collision for the rectangles aka the bat, passes the sprite(rectangle)
        /// #region can specify a block of code that you can expand or collapse
        /// </summary>
        #region Collision
        protected bool IsTouchingLeft(Sprite sprite)
        {
            return this.Rectangle.Right + this.velocity.X > sprite.Rectangle.Left &&
                   this.Rectangle.Left < sprite.Rectangle.Left &&
                   this.Rectangle.Bottom > sprite.Rectangle.Top &&
                   this.Rectangle.Top < sprite.Rectangle.Bottom;
        }

        protected bool IsTouchingRight(Sprite sprite)
        {
            return this.Rectangle.Left + this.velocity.X < sprite.Rectangle.Right &&
                   this.Rectangle.Right > sprite.Rectangle.Right &&
                   this.Rectangle.Bottom > sprite.Rectangle.Top &&
                   this.Rectangle.Top < sprite.Rectangle.Bottom;
        }

        protected bool IsTouchingTop(Sprite sprite)
        {
            return this.Rectangle.Bottom + this.velocity.Y > sprite.Rectangle.Top &&
                   this.Rectangle.Top < sprite.Rectangle.Top &&
                   this.Rectangle.Right > sprite.Rectangle.Left &&
                   this.Rectangle.Left < sprite.Rectangle.Right;
        }
        protected bool IsTouchingBottom(Sprite sprite)
        {
            return this.Rectangle.Top + this.velocity.Y < sprite.Rectangle.Bottom &&
                   this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
                   this.Rectangle.Right > sprite.Rectangle.Left &&
                   this.Rectangle.Left < sprite.Rectangle.Right;
        }
        #endregion
    }
}
