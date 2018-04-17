using EasterAssignment.Classes.SpriteClasses;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using EasterAssignment.Classes.ContentManagerClasses;
using EasterAssignment.Classes.ServiceClasses;

namespace LinkedListGame
{
    public class Coin : ISpriteWithBounds
    {
        public string SpriteID { get; set; }
        public Vector2 SpritePosition { get; set; }
        public string SpriteTextureKey { get; set; }
        public Rectangle Bounds { get; set; }

        public int CoinValue { get; set; }
        public string TextureKey { get; private set; }

        public Coin()
        {
           
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();
            spriteBatch.Draw(TextureManager.AllTextures[SpriteTextureKey], SpritePosition, Color.White);
            spriteBatch.DrawString(Helper.SpriteFont, CoinValue.ToString(), SpritePosition, Color.White);
            spriteBatch.End();
        }
    }
}
