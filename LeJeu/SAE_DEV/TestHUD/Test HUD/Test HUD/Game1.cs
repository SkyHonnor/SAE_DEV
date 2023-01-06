using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Content;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using System.Diagnostics;

namespace Test_HUD
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private HUD _hud;
        private Bouton[] _lesBoutons;
        public static SpriteFont _font;

        public const int _widthWindow = 1280;
        public const int _heightWindow = 720;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _lesBoutons = new Bouton[] {new Bouton(1, "Start", new Vector2(_widthWindow/2, _heightWindow/2)), new Bouton(1, "Exit", new Vector2(_widthWindow/2, _heightWindow/2+220)), new Bouton(1, "?", new Vector2(_widthWindow-150, _heightWindow / 2 + 220))};
            _hud = new HUD(true, 1, _lesBoutons);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _graphics.PreferredBackBufferWidth = _widthWindow;
            _graphics.PreferredBackBufferHeight = _heightWindow;
            _graphics.ApplyChanges();

            SpriteSheet spriteSheet = Content.Load<SpriteSheet>("GBoutonAssetsf.sf", new JsonContentLoader());
            _lesBoutons[0].TextureBouton = new AnimatedSprite(spriteSheet);
            spriteSheet = Content.Load<SpriteSheet>("GBoutonAssetsf.sf", new JsonContentLoader());
            _lesBoutons[1].TextureBouton = new AnimatedSprite(spriteSheet);
            spriteSheet = Content.Load<SpriteSheet>("PBoutonAssetsf.sf", new JsonContentLoader());
            _lesBoutons[2].TextureBouton = new AnimatedSprite(spriteSheet);

            _font = Content.Load<SpriteFont>("font");
            

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            _hud.Update(gameTime);

            MouseState mouse = Mouse.GetState();

            if (_hud.QuiEstClicker(out Bouton boutonclicker) && boutonclicker.NomBouton == "Exit")
                Exit();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _hud.Draw(_spriteBatch);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}