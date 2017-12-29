using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace PJTTAssignment4._4
{
    public class Score
    {
        public int Score1;
        public int Score2;
        
        private SpriteFont _font;

        public Score(SpriteFont font)
        {
            _font = font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, "PJ : " + Score1.ToString(), new Vector2(70, 50), Color.White);
            spriteBatch.DrawString(_font, "Tuan : " + Score2.ToString(), new Vector2(500, 50), Color.White);

            //spriteBatch.DrawString(_font, "You are the winner" , new Vector2(2, 2), Color.White);
        }
    }
}
