using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace TextBox
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont font;
        private string input = string.Empty;
        private List<InputBox> inputButtons;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            inputButtons = new List<InputBox>();
            //Window.TextInput += TextInputHandler;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D box = Content.Load<Texture2D>("Square1");
            font = Content.Load<SpriteFont>("font");
            inputButtons.Add(new InputBox(new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), box, "", Color.Green, false));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            Input.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            for (int i = 0; i < inputButtons.Count; i++)
            {
                inputButtons[i].Selected(Window);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            for (int i = 0; i < inputButtons.Count; i++)
            {
                inputButtons[i].Draw(_spriteBatch, font);
            }
            // TODO: Add your drawing code here
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        //private void TextInputHandler(object sender, TextInputEventArgs args)
        //{
        //    var pressedKey = args.Key;
        //    var character = args.Character;
        //    input += character;
        //    for (int i = 0; i < inputButtons.Count; i++)
        //    {
        //        if (inputButtons[i].Selected(Window))
        //        {
        //            inputButtons[i].AddText(character);
        //        }
        //    }
        //    // do something with the character (and optionally the key)
        //    // ...
        //}
    }
}