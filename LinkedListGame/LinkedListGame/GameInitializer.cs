using EasterAssignment.Classes;
using EasterAssignment.Classes.ContentManagerClasses;
using EasterAssignment.Classes.SceneClasses;
using EasterAssignment.Classes.ServiceClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGame
{
    public class GameInitializer
    {
        
       
        public GameInitializer(Game currentGame)
        {
            Helper.CurrentGame = currentGame;

        }
        public void InitializeGame(ref SceneManager sceneManager)
        {
                       
            LoadContents();
            LoadSpriteFont();
            CreateMap();
            CreateCoins();
            CreateSlots();
            CreatePlayScene(ref sceneManager);
        }

        public void CreatePlayScene(ref SceneManager sceneManager)
        {
            try
            {
                PlayScene playScene = new PlayScene();                
                playScene.BackgroundTextureKey = "play";
                playScene.AllTheSpritesWithinTheScene.AddRange(CreateCoins());
                playScene.AllTheSpritesWithinTheScene.AddRange(CreateSlots());
                sceneManager.ActiveScene = playScene;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while creating Play Scene : {0}", e.Message);

            }

        }

        public LinkedList<Coin> CreateCoins()
        {
            LinkedList<Coin> allCoins = new LinkedList<Coin>();
            for (int i = 0; i < 10; i++)
            {
                Coin coin = new Coin();
                coin.SpriteTextureKey = "coin";
                coin.SpritePosition = new Vector2(Helper.random.Next(0, (int)Map.MapSize.X), Helper.random.Next(150, (int)Map.MapSize.Y));
                coin.Bounds = new Rectangle((int)coin.SpritePosition.X, (int)coin.SpritePosition.Y, TextureManager.AllTextures[coin.SpriteTextureKey].Width, TextureManager.AllTextures[coin.SpriteTextureKey].Height);
                coin.CoinValue = Helper.random.Next(1, 5);
                allCoins.AddFirst(coin);
            }
            return allCoins;
        }

        public LinkedList<Slot> CreateSlots()
        {
            LinkedList<Slot> allSlots = new LinkedList<Slot>();
            for (int i = 0; i < 5; i++)
            {
                Slot slot = new Slot();
                slot.SpriteTextureKey = "slot";
                slot.SpritePosition = new Vector2((i*100)+50,100);
                slot.AcceptedCoinValue = i + 1;
                allSlots.AddFirst(slot);
            }


            return allSlots;


        }

        public void LoadContents()
        {
            try
            {
                TextureManager.AllTextures = Loader.ContentLoad<Texture2D>(Helper.CurrentGame.Content, "Images");
            }
            catch (Exception e)
            {

                Console.WriteLine("Error while loading textures : {0}", e.Message);
            }

           
        }

        public void CreateMap()
        {
            try
            {
                Map.MapSize = new Vector2(1000, 1000);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while creating Map : {0}", e.Message);

            }


        }
        public void LoadSpriteFont()
        {
            Helper.SpriteFont = Helper.CurrentGame.Content.Load<SpriteFont>("Fonts/font");
        }
    }
}
