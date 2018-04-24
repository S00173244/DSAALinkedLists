using EasterAssignment.Classes.ContentManagerClasses;
using EasterAssignment.Classes.ServiceClasses;
using EasterAssignment.Classes.SpriteClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterAssignment.Classes.SceneClasses
{
    public class PlayScene : IScene
    {
        public string BackgroundTextureKey { get; set; }
        public List<IBaseSprite> AllTheSpritesWithinTheScene { get; set; }
        public Keys SceneActivateKey { get; set; }
        public bool IsActive { get; set; }
       
        public bool Gameover { get; set; }

        public PlayScene()
        {
            AllTheSpritesWithinTheScene = new List<IBaseSprite>();
            Gameover = false;
        }
        public void Update(GameTime gameTime)
        {
            AllTheSpritesWithinTheScene.ForEach(c => c.Update(gameTime));
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(TextureManager.AllTextures[BackgroundTextureKey], Vector2.Zero, Color.White);


            spriteBatch.End();
            AllTheSpritesWithinTheScene.ForEach(c => c.Draw(spriteBatch));
           
            
        }


    }
    
}
