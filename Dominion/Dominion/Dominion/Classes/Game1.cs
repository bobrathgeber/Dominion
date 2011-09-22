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
using System.Text;
using Dominion.Classes;

namespace Dominion
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        int screenWidth;
        int screenHeight;
        SpriteBatch spriteBatch;
        int gameState;

        Texture2D mousePointer;
        Vector2 mousePosition;
        MouseState mouseState;

        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        Texture2D backgroundTexture;
        List<Player> players;
        int currentPlayer;

        /*
        Card cardCopper;
        Card cardSilver;
        Card cardGold;

        Card cardEstate;
        Card cardDuchy;
        Card cardProvince;

        Card cardCellar;
        Card cardChapel;
        Card cardMoat;
        Card cardChancellor;
        Card cardVillage;
        Card cardWoodcutter;
        Card cardWorkshop;
        Card cardBureaucrat;
        Card cardFeast;
        Card cardGardens;
        Card cardMilitia;
        Card cardMoneylender;
        Card cardRemodel;
        Card cardSmithy;
        Card cardSpy;
        Card cardThief;
        Card cardThroneRoom;
        Card cardCouncilRoom;
        Card cardFestival;
        Card cardLaboratory;
        Card cardLibrary;
        Card cardMarket;
        Card cardMine;
        Card cardWitch;
        Card cardAdventurer;
        */

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            ServiceLocator.ContentManager = this.Content;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 800;
            //IsMouseVisible = true;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Dominion";
            gameState = 1;
            

            //test player
            players = new List<Player> ();
           

          //LEAVE THIS LAST!!!
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mousePointer = Content.Load<Texture2D>("images/MouseCursor");
            screenHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;
            screenWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
            backgroundTexture = Content.Load<Texture2D>("images/background800x800");            

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            if (gameState == 1) //start menu
            {
                if (currentKeyboardState.IsKeyDown(Keys.Space))
                {
                    gameState = 2;
                    startGame();
                }
            }
            else if (gameState == 2) // game running
            {
                
       
            }

            // TODO: Add your update logic here
           

            UpdateMouse();
            base.Update(gameTime);
        }

        private void drawCardsInHand()
        {
            players[(currentPlayer - 1)].getHand();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            drawBackground();
            
            if (gameState == 2)
            {
                //draw cards in hand
                for (int i=0; i<players[currentPlayer-1].hand.Count; i++)
                {

                    players[currentPlayer-1].hand[i].position = new Vector2(((i*140)+20), 600);
                    players[currentPlayer-1].hand[i].Draw(spriteBatch); 
                }
                             
            }

            spriteBatch.Draw(this.mousePointer, this.mousePosition, Color.White);
            
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }


        private void drawBackground()
        {
            Rectangle screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
            spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);
        }

        private void UpdateMouse()
        {
            mouseState = Mouse.GetState();
            mousePosition.X = mouseState.X;
            mousePosition.Y = mouseState.Y;
            
        }

        public void startGame()
        {
            int PlayerCount = 1; //temp

            //adds players to game
            for (int i = 0; i < PlayerCount; i++)
            {
                Player p = new Player();
                for (int j = 0; j < 7; j++)
                {
                    CopperCard cc = new CopperCard();
                    p.addCardToDiscard(cc);
                }

                for (int k = 0; k < 3; k++)
                {
                    EstateCard ec = new EstateCard();
                    p.addCardToDiscard(ec);
                }

                p.name = ("Player " + (i+1).ToString());
                players.Add(p);
            }

            foreach (Player p in players)
            {
                p.shuffleDeck();
                p.drawCard(5);
            }
            currentPlayer = 1;
        }

        public void loadCards()
        {
            //Name, Cost, Actions, Buys, Coins, VictoryPoints, Effect, image
            
            /*

            cardTexture = Content.Load<Texture2D>("images/duchy");
            cardDuchy.Initialize("Duchy", 5, 0, 0, 0, 3, false, cardTexture);

            cardTexture = Content.Load<Texture2D>("images/province");
            cardProvince.Initialize("Province", 8, 0, 0, 0, 6, false, cardTexture);

            cardTexture = Content.Load<Texture2D>("images/village");
            cardVillage.Initialize("Village", 3, 2, 0, 0, 0, false, cardTexture);

            cardTexture = Content.Load<Texture2D>("images/cellar");
            cardCellar.Initialize("Cellar", 2, 1, 0, 0, 0, true, cardTexture);

            cardTexture = Content.Load<Texture2D>("images/market");
            cardMarket.Initialize("Market", 5, 1, 1, 1, 0, true, cardTexture);

            cardTexture = Content.Load<Texture2D>("images/militia");
            cardMilitia.Initialize("Militia", 4, 0, 0, 2, 0, true, cardTexture);

            cardTexture = Content.Load<Texture2D>("images/Mine");
            cardMine.Initialize("Mine", 5, 0, 0, 0, 0, true, cardTexture);

            cardTexture = Content.Load<Texture2D>("images/remodel");
            cardRemodel.Initialize("Remodel", 4, 0, 0, 0, 0, true, cardTexture);

            cardTexture = Content.Load<Texture2D>("images/smithy");
            cardSmithy.Initialize("Smithy", 4, 0, 0, 0, 0, true, cardTexture);

            cardTexture = Content.Load<Texture2D>("images/woodcutter");
            cardWoodcutter.Initialize("Wood Cutter", 3, 0, 1, 2, 0, false, cardTexture);

            cardTexture = Content.Load<Texture2D>("images/workshop");
            cardWorkshop.Initialize("Workshop", 3, 0, 0, 0, 0, true, cardTexture);

            cardTexture = Content.Load<Texture2D>("images/moat");
            cardMoat.Initialize("Moat", 2, 0, 0, 0, 0, true, cardTexture);
            */
        }
    }
}
