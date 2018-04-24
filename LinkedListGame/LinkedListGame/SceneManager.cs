using EasterAssignment.Classes.SceneClasses;
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

namespace EasterAssignment.Classes.ContentManagerClasses
{
    public class SceneManager
    {
        
        public Stack<IScene> AllScenes { get; set; }
        
        public IScene ActiveScene { get; set; }
        public IScene PreviousScene { get; set; }
        public static Keys ChangeSceneKey = Keys.Escape;
        


        public SceneManager()
        {
            AllScenes = new Stack<IScene>();
            
        }
        public void Update(GameTime gameTime)
        {
            ActiveScene.Update(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ActiveScene.Draw(spriteBatch);
            
            
        }


        
    }
        
       

    
}
