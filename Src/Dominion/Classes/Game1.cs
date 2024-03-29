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
        public int currentPlayerIndex;

        SpriteFont font;
        Texture2D coinIcon;
        Button endTurnButton;
        EndTurnAction bAction;
        Texture2D endTurnTexture;

        Texture2D menuButtonTexture;
        Button newGameButton;
        Button exitButton;
        Button onePlayerButton;
        Button twoPlayerButton;
        Button threePlayerButton;
        Button fourPlayerButton;

        Controller _controller;

        // store all entity instances in one place.
        // this way we can perform operations on the entire set (or subset) easily.
        List<Entity> _entities;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Registry.ContentManager = this.Content;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 800;
            //IsMouseVisible = true;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Dominion";
            gameState = 1;
                        
            //test player
            players = new List<Player> ();

            _entities = new List<Entity>();
            Registry.GameEntities = _entities;

          //LEAVE THIS LAST!!!
            base.Initialize();
        }

        private void initializeMainMenu()
        {
            menuButtonTexture = Content.Load<Texture2D>("images/playerButton");
            //newGameButton = new Button(menuButtonTexture, font, spriteBatch, EndTurnAction) ;
            //exitButton = new Button(menuButtonTexture, font, spriteBatch, EndTurnAction);
            //onePlayerButton = new Button(menuButtonTexture, font, spriteBatch, EndTurnAction);
            //twoPlayerButton = new Button(menuButtonTexture, font, spriteBatch, EndTurnAction);
            //threePlayerButton = new Button(menuButtonTexture, font, spriteBatch, EndTurnAction);
            //fourPlayerButton = new Button(menuButtonTexture, font, spriteBatch, EndTurnAction);
            
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
            initializeMainMenu();

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        private Player CurrentPlayer
        {
            get
            {
                return players[currentPlayerIndex];
            }
             
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
                _controller.UpdateState();

                foreach (var ss in _entities.OfType<StoreSlot>())
                {
                    //players[currentPlayerIndex].buy
                }

                // detect controller events
                foreach (var inputObserver in _entities.OfType<IInputObserver>())
                {
                    inputObserver.Update(_controller);
                }

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
            int deckSize = players[currentPlayerIndex].getTotalCards();
            int totalVP = players[currentPlayerIndex].getVP();
            string text = "Player " + currentPlayerIndex.ToString() + " : You won! You have " + deckSize.ToString() + 
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

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            drawBackground();
            if (gameState == 1)
            {

            }
            else if (gameState == 2)
            {
                //CurrentPlayer.Draw(spriteBatch);

                // Draw the infobar
                spriteBatch.Draw(coinIcon, new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X+5, GraphicsDevice.Viewport.TitleSafeArea.Y), Color.White);
                spriteBatch.DrawString(font, ": " + players[currentPlayerIndex].Coins, new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X+33, GraphicsDevice.Viewport.TitleSafeArea.Y), Color.White);
                spriteBatch.DrawString(font, "actions: " + players[currentPlayerIndex].Actions, new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 120, GraphicsDevice.Viewport.TitleSafeArea.Y), Color.White);
                spriteBatch.DrawString(font, "buys: " + players[currentPlayerIndex].Buys, new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X+270, GraphicsDevice.Viewport.TitleSafeArea.Y), Color.White);
                endTurnButton.Draw();

                foreach (var renderable in _entities.OfType<IRenderable>())
                {
                    renderable.Draw(spriteBatch);
                } 
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
                p.Store = store;
                _controller = new Controller(p);
                p.Buys = 10;
                p.Coins = 6;
                for (int j = 0; j < 7; j++)
                {
                    CopperCard cc = new CopperCard();
                    store.buyCard(p, cc);
                }

                for (int k = 0; k < 3; k++)
                {

                    EstateCard ec = new EstateCard();
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
            currentPlayerIndex = 0;
            bAction.player = (players[currentPlayerIndex]);

        }

    }
}
