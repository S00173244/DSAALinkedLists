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
        public bool Selected { get; set; }
        public int CoinValue { get; set; }
        public string TextureKey { get; private set; }
        
        public bool IsVisible = true;

        public Coin()
        {
            Selected = false;
        }

        public void Update(GameTime gameTime)
        {
            if(Selected == true && IsVisible == true)
            {
                SpritePosition = InputEngine.CurrentMouseState.Position.ToVector2();
                Bounds = new Rectangle((int)SpritePosition.X, (int)SpritePosition.Y, TextureManager.AllTextures[SpriteTextureKey].Width, TextureManager.AllTextures[SpriteTextureKey].Height);

            }else if(IsVisible && Selected == false)
            {
                var q = Helper.AllSlots.FirstOrDefault(c => c.Bounds.Intersects(Bounds) && CoinValue == c.AcceptedCoinValue);
                Console.WriteLine(q);
                if(q!= null)
                {
                    IsVisible = false;
                    q.InsertedCoins++;
                }
            }
        } 

        public void Draw(SpriteBatch spriteBatch)
        {

            if (IsVisible)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(TextureManager.AllTextures[SpriteTextureKey], SpritePosition, Color.White);
                spriteBatch.DrawString(Helper.SpriteFont, CoinValue.ToString(), SpritePosition, Color.White);
                spriteBatch.End();
            }
            
        }
    }
}
