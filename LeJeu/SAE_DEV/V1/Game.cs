using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Content;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using System.Diagnostics;

namespace TheGame
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Joueur _perso;
        private Monstre _gobelin;

        private HUD _hud;
        private Bouton[] _lesBoutons;
        public static SpriteFont _font;

        public const int _widthWindow = 1280;
        public const int _heightWindow = 720;

        private MapManager _mapManager;

        

        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = false;

            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _perso = new Joueur(1, "OwO", new Vector2(296, 105), 3, (float)0.15, false, false, 10, 10, 0, 0, 0, Keys.Z, Keys.S, Keys.D, Keys.Q,GraphicsDevice);

            _lesBoutons = new Bouton[] { new Bouton(1, "Start", new Vector2(_widthWindow / 2, _heightWindow / 2)), new Bouton(1, "Exit", new Vector2(_widthWindow / 2, _heightWindow / 2 + 220)), new Bouton(1, "?", new Vector2(_widthWindow - 150, _heightWindow / 2 + 220)) };
            _hud = new HUD(true, 1, _lesBoutons);
            _gobelin = new Monstre(new Vector2(500, 500), this, 2, 32);
            _gobelin.Init();
           
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            SpriteSheet spriteSheet = Content.Load<SpriteSheet>("animationPersoBleu.sf", new JsonContentLoader());
            _perso.TextureJoueur = new AnimatedSprite(spriteSheet);

            spriteSheet = Content.Load<SpriteSheet>("GBoutonAssetsf.sf", new JsonContentLoader());
            _lesBoutons[0].TextureBouton = new AnimatedSprite(spriteSheet);
            spriteSheet = Content.Load<SpriteSheet>("GBoutonAssetsf.sf", new JsonContentLoader());
            _lesBoutons[1].TextureBouton = new AnimatedSprite(spriteSheet);
            spriteSheet = Content.Load<SpriteSheet>("PBoutonAssetsf.sf", new JsonContentLoader());
            _lesBoutons[2].TextureBouton = new AnimatedSprite(spriteSheet);

            _font = Content.Load<SpriteFont>("font");

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _mapManager = new MapManager(this);
            _mapManager.SelectMap("default");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            float deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds; // DeltaTime

            _hud.Update(gameTime);

            if (_hud.QuiEstClicker(out Bouton boutonclicker) && boutonclicker.NomBouton == "Exit")
                Exit();
            else if (_hud.QuiEstClicker(out boutonclicker) && boutonclicker.NomBouton == "Start")
                _hud.Actif = false;


            _perso.Update(gameTime, _mapManager.CurrentMap);
            _gobelin.Update(_perso, gameTime, deltaSeconds,_mapManager.CurrentMap);
            _hud.Update(gameTime);

            _mapManager.Update(gameTime);

            base.Update(gameTime);
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _mapManager.Draw();
            _spriteBatch.Begin();

            

            _gobelin.Draw(_spriteBatch);
            _perso.Draw(_spriteBatch);
            _hud.Draw(_spriteBatch);
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}