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


namespace NinjaSlice
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MainGame : Game
    {
        /* הגדרת משתנים */
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        HamasSprite startgame,exit,zenmode;
        Sword sword;
        List<Bomb> bombs = new List<Bomb>();
        List<HamasSprite> Menu = new List<HamasSprite>();
        List<HamasSprite> Sprites = new List<HamasSprite>();
        Gun gun;
        List<Shpritz> blood=new List<Shpritz>();
        Texture2D Background,gameback;
        XNAButton btnstart, btnexit, btnstore;
        Random rnd = new Random();
        SpriteFont font;
        public static int scoreval=0;
        public static bool startg = false;
        string score = "0";
        ClockTimer timer = new ClockTimer();
        float counter = 60;
        enum GameState
        {
            MainMenu,
            Store,
            Playing,
        }
        GameState CurrGame = GameState.MainMenu;
        public MainGame()
            : base()
        {
            /*אתחול גראפיקה */
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
        }
        
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            /*טעינת תוכן*/
            //mainCrusor = new MainCursor(Content.Load<Texture2D>("cursorgreen"), Content.Load<Texture2D>("cursorred"), Content.Load<Song>("M16Sound"));
           // ObjectCreated();
            sword = new Sword(Content);
            gun = new Gun(Content);
            gameback = Content.Load<Texture2D>("back");
            font = Content.Load<SpriteFont>("font");
            startgame = new HamasSprite(Content,1);
            btnexit = new XNAButton(Content.Load<Texture2D>("exit"), new Vector2(420, 512), Content.Load<Texture2D>("exithover"),this);
            btnstart = new XNAButton(Content.Load<Texture2D>("startmenu"), new Vector2(500, 500), Content.Load<Texture2D>("startmenuhover"), this);
            Background = Content.   Load<Texture2D>("NEWBACK");
            Song song = Content.Load<Song>("music");  // Put the name of your song in instead of "song_title"
       //     MediaPlayer.Play(song);
            zenmode = new HamasSprite(Content, 2);
            Menu.Add(zenmode);
            Menu.Add(startgame);
    MediaPlayer.IsRepeating = true;
            // TODO: use this.Content to load your game content here
        }
        public void ObjectCreated()
        {
 
             Sprites.Add(new HamasSprite(Content,0));
        }
        public void BombCreate()
        {
            bombs.Add(new Bomb(Content));
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        double val=0;
        protected override void Update(GameTime gameTime)
        {
            switch (CurrGame)
            {
                case GameState.MainMenu:
                 //   gun.Update(gameTime,startgame);
                    startgame.Update(gameTime);
                    zenmode.Update(gameTime);
                    sword.Update(gameTime, Menu, Content);
                    btnexit.Update(1);

                    btnstart.Update(2);
                    if (startg==true&&startgame.Wait())
                    {
                        
                        CurrGame = GameState.Playing;
                    }
                    break;
                case GameState.Playing:
                    bool added=false;
                    for (int i = 0; i <  Sprites.Count; i++)
                    {
                        if(Sprites[i]!=null)
                            Sprites[i].Update(gameTime);
                            
                        if(Sprites[i].Removing()==true)
                        {
                           Sprites.Remove(Sprites[i]);
                           i--;
                        }
                        

                    }
                    foreach (Bomb item in bombs)
                    {
                        item.Update(gameTime);
                    }

                    if (timer.isRunning == false)
                    {
                        //count 10 seconds down 
                        timer.start(60);
                    }
                    else
                    {
                        timer.checkTime(gameTime);
                    }   
                //foreach (HamasSprite item in Sprites)
                    //{
                    //    if(item!=null)
                    //    item.Update(gameTime);
                    //    if (item.GetState())
                    //        Sprites.Remove(item);

                    //}

                    score = scoreval.ToString();
                    sword.Update(gameTime,Sprites,Content);
                    if (val % 50 == 0)
                        {
                           ObjectCreated();
                           val = 0;
                        }
                 
                        val += 1;
                    //sprites=rnd.Next(5);
                    break;
                case GameState.Store:
                    break;
            }
            base.Update(gameTime);
        }
     
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            spriteBatch.Begin();
            switch (CurrGame)
            {
                case GameState.MainMenu:
                  
                    spriteBatch.Draw(Background, new Vector2(0, 0), Color.White);

              //      btnexit.Draw(spriteBatch);
             //       btnstart.Draw(spriteBatch);
                    zenmode.Draw(spriteBatch);
                    startgame.Draw(spriteBatch);
                    sword.Draw(spriteBatch);
               //     gun.Draw(spriteBatch);
                    break;

                /* 
                 * 
                 *Playing Game Code
                 * 
                 */
                case GameState.Playing:
                    spriteBatch.Draw(gameback, new Vector2(0), Color.White);
                                blood = sword.send();
                    foreach (Shpritz item in blood)
                    {
                        if (item != null)
                        {
                            item.Draw(spriteBatch);
                        }
                    }
                    foreach (HamasSprite item in Sprites)
                    {
                        if (item != null)
                            item.Draw(spriteBatch);
                    }
                    foreach (Bomb item in bombs)
                    {
                        if (item != null)
                            item.Draw(spriteBatch);
                    }
        
                    Vector2 FontOrigin = font.MeasureString(score) / 2;
                    spriteBatch.Draw(Content.Load<Texture2D>("score"), new Vector2(5, 10), Color.White);
                    spriteBatch.DrawString(font, score, new Vector2(200,40), Color.White, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
                    spriteBatch.DrawString(font,timer.displayClock, new Vector2(500, 40), Color.White, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
                    sword.Draw(spriteBatch);
                     
                     //for (int i = 0; i < sprites; i++)
                     //{
                       
                     //}
                        
                    break;
                /*Weapon Choose*/
                case GameState.Store:
                  
                    break;
            }
            
       //     mainCrusor.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}