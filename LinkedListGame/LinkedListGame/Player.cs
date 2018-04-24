using EasterAssignment.Classes.SpriteClasses;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using EasterAssignment.Classes.ServiceClasses;
using EasterAssignment.Classes.ContentManagerClasses;

namespace LinkedListGame
{
    public class Player : ISpriteWithBounds
    {
        public string SpriteID { get; set; }
        public Vector2 SpritePosition { get; set; }
        public string SpriteTextureKey { get; set; }
        public Rectangle Bounds { get; set; }
        
        public bool HoldingACoin = false;
        public void Update(GameTime gameTime)
        {
            SpritePosition = InputEngine.CurrentMouseState.Position.ToVector2();
            Bounds = new Rectangle((int)SpritePosition.X, (int)SpritePosition.Y, TextureManager.AllTextures[SpriteTextureKey].Width, TextureManager.AllTextures[SpriteTextureKey].Height);

            if (InputEngine.IsMouseLeftHeld() && HoldingACoin == false)
            {
                var q = Helper.AllCoins.FirstOrDefault(c => c.Bounds.Intersects(Bounds));

                if(q!= null && HoldingACoin == false)
                {
                    q.Selected = true;
                    HoldingACoin = true;

                }


            }
            else if(!InputEngine.IsMouseLeftHeld())
            {
                HoldingACoin = false;
                var q = Helper.AllCoins.FirstOrDefault(c => c.Selected == true);

                if (q != null)
                {
                    q.Selected = false;
                   

                }


            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(TextureManager.AllTextures[SpriteTextureKey], SpritePosition, Color.White);
            
            spriteBatch.End();
        }
    }
}
