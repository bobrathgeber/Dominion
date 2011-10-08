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
        Store store;
        List<Player> players;
        public int currentPlayer;
        List<Button> StoreButtons;

        SpriteFont font;
        Texture2D coinIcon;
        Button endTurnButton;
        EndTurnAction bAction;
        Texture2D endTurnTexture;


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
            font = Content.Load<SpriteFont>("gameFont");
            coinIcon = Content.Load<Texture2D>("images/coin_sm");
            bAction = new EndTurnAction();
            
            endTurnTexture = Content.Load<Texture2D>("images/endturnbutton");
            endTurnButton = new Button(endTurnTexture, font, spriteBatch, bAction);
            endTurnButton.Location(550, 20);

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
                updateStoreStock();
                updateCards();
                updateButtons(players[currentPlayer]);
                endTurnButton.Update();
                checkEndGameConditions();
            }
            else if (gameState == 3)
            {
                
            }

            // TODO: Add your update logic here

            
            UpdateMouse();
            base.Update(gameTime);
        }

        private void drawResults()
        {            
            int deckSize = players[currentPlayer].getTotalCards();
            int totalVP = players[currentPlayer].getVP();
            string text = "Player " + currentPlayer.ToString() + " : You won! You have " + deckSize.ToString() + 
                " cards in your deck and " + totalVP.ToString() + " VICTORY POINTS!";
            Vector2 size = font.MeasureString(text);
            Vector2 textLocation = new Vector2();
            textLocation.Y = (screenHeight / 2) - (size.Y / 2);
            textLocation.X = (screenWidth / 2) - ((size.X / 2));
            spriteBatch.DrawString(font, text, textLocation, Color.White);
        }

        private void checkEndGameConditions()
        {
            if (store.checkEndGame())
            {
                gameState = 3;
            }
        }

        private void updateCards()
        {
            int count = players[currentPlayer].hand.Count-1;
            for (int i = count; i >= 0; i--)
            {
                players[currentPlayer].hand[i].Update();                
            }
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
                for (int i=0; i<players[currentPlayer].hand.Count; i++)
                {
                    players[currentPlayer].hand[i].position.X = ((i * 140) + 20);
                    players[currentPlayer].hand[i].position.Y = 600;
                    players[currentPlayer].hand[i].Draw(spriteBatch); 
                }
                


                // Draw the infobar
                spriteBatch.Draw(coinIcon, new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X+5, GraphicsDevice.Viewport.TitleSafeArea.Y), Color.White);
                spriteBatch.DrawString(font, ": " + players[currentPlayer].Coins, new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X+33, GraphicsDevice.Viewport.TitleSafeArea.Y), Color.White);
                spriteBatch.DrawString(font, "actions: " + players[currentPlayer].Actions, new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 120, GraphicsDevice.Viewport.TitleSafeArea.Y), Color.White);
                spriteBatch.DrawString(font, "buys: " + players[currentPlayer].Buys, new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X+270, GraphicsDevice.Viewport.TitleSafeArea.Y), Color.White);
                endTurnButton.Draw();
                drawButtons();
                             
            }
            else if (gameState == 3)
            {
                drawResults();
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
            int PlayerCount = 1; //TEMPORARY!!*****
            store = new Store();


            //adds players to game
            for (int i = 0; i < PlayerCount; i++)
            {
                Player p = new Player();
                p.Buys = 10;
                p.Coins = 6;
                for (int j = 0; j < 7; j++)
                {
                    CopperCard cc = new CopperCard(p);
                    store.buyCard(p, cc);
                }

                for (int k = 0; k < 3; k++)
                {

                    EstateCard ec = new EstateCard(p);
                    store.buyCard(p, ec);                    
                }

                p.name = ("Player " + (i+1).ToString());
                players.Add(p);
            }

            foreach (Player p in players)
            {
                p.shuffleDeck();
                p.endTurn();
            }            
            currentPlayer = 0;
            bAction.player = (players[currentPlayer]);
            GenerateStoreButtons();
        }

        public void GenerateStoreButtons()
        {
            
            Texture2D buttonTexture;
            StoreButtons = new List<Button>();
            for (int i = 0; i < store.stock.Count; i++)
            {
                BuyCardAction bAction = new BuyCardAction();
                bAction.store = store;
                bAction.player = players[currentPlayer];
                bAction.setCard((store.stock[i].Copy(players[currentPlayer])));
                
                buttonTexture = store.stock[i].cardImage;
                Button cardButton = new Button(buttonTexture, font, spriteBatch, bAction);
                if (i > 8)
                {
                    cardButton.Location((40 + ((i-9) * buttonTexture.Width / 2)), 250);
                }
                else
                {
                    cardButton.Location((40 + (i * buttonTexture.Width / 2)), 100);
                }
                cardButton.Text = store.stockAmount[i].ToString();
                cardButton.Scale(buttonTexture.Width / 2, buttonTexture.Height / 2);
                StoreButtons.Add(cardButton);
            }
        }
        public void updateStoreStock()
        {
            for (int i = 0; i < StoreButtons.Count; i++)
            {
                StoreButtons[i].Text = store.stockAmount[i].ToString();
            }
        }

        public void drawButtons()
        {
            for (int i = 0; i < StoreButtons.Count; i++)
            {
                StoreButtons[i].Draw();
            }
        }
        public void updateButtons(Player p)
        {
            for (int i = 0; i < StoreButtons.Count; i++)
            {
                StoreButtons[i].Update();
            }
        }
    }
}
