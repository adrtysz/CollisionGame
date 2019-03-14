using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Texture2D enemy;
        Texture2D character;
        Texture2D background;
        Rectangle characterBound;
        Rectangle enemyBound;
        Vector2 characterPosition;
        Vector2 enemyPosition;
        string komunikat;


        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

      
        protected override void Initialize()
        {
            characterPosition = new Vector2(100, 150);
            enemyPosition= new Vector2(350, 150);

            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("background"); 
            character = Content.Load<Texture2D>("character");  
            enemy = Content.Load<Texture2D>("enemy");
            font = Content.Load<SpriteFont>("font");


        }


        protected override void UnloadContent()
        {
           
        }

        
       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();




            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Up))
                characterPosition.Y = characterPosition.Y - 1;

            if (keyboard.IsKeyDown(Keys.Down))
                characterPosition.Y = characterPosition.Y + 1;

            if (keyboard.IsKeyDown(Keys.Left))
                characterPosition.X = characterPosition.X - 1;

            if (keyboard.IsKeyDown(Keys.Right))
                characterPosition.X = characterPosition.X + 1;


        // ruchy wroga
            if (keyboard.IsKeyDown(Keys.W))
                enemyPosition.Y = enemyPosition.Y - 1;

            if (keyboard.IsKeyDown(Keys.S))
                enemyPosition.Y = enemyPosition.Y + 1;

            if (keyboard.IsKeyDown(Keys.A))
                enemyPosition.X = enemyPosition.X - 1;

            if (keyboard.IsKeyDown(Keys.D))
                enemyPosition.X = enemyPosition.X + 1;

            characterBound = new Rectangle((int)characterPosition.X, (int)characterPosition.Y, character.Width, character.Height);
            enemyBound = new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, enemy.Width, enemy.Height);

            if (characterBound.Intersects(enemyBound))
            {
                komunikat = "KOLIZJA";
                
            }
            else {
                komunikat = "BRAK KOLIZJI";
            
            }

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            spriteBatch.DrawString(font, komunikat, new Vector2(20, 20), Color.Purple);
            spriteBatch.Draw(character, characterPosition, Color.White);
            spriteBatch.Draw(enemy, enemyPosition, Color.White);


            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
