﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Content;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using System.Collections.Generic;
using System.Diagnostics;

namespace TheGame
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Joueur _perso1;
        private Joueur _perso2;

        private List<Joueur> _listJoueur;

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
            _perso1 = new Joueur(1, "OwO", new Vector2(296, 105), 3, (float)0.15, false, false, 10, 10, 0, 0, 0, Keys.Z, Keys.S, Keys.D, Keys.Q, GraphicsDevice);
            _perso2 = new Joueur(2, "UwU", new Vector2(296, 105), 3, (float)0.15, false, false, 10, 10, 0, 0, 0, Keys.Up, Keys.Down, Keys.Right, Keys.Left, GraphicsDevice);

            _listJoueur = new List<Joueur>();
            _listJoueur.Add(_perso1);
            _listJoueur.Add(_perso2);

            _lesBoutons = new Bouton[] { new Bouton(1, "Start", new Vector2(_widthWindow / 2, _heightWindow / 2)), new Bouton(1, "Exit", new Vector2(_widthWindow / 2, _heightWindow / 2 + 220)), new Bouton(1, "?", new Vector2(_widthWindow - 150, _heightWindow / 2 + 220)), new Bouton(2, "Pause", new Vector2(_widthWindow / 2, _heightWindow / 2)), new Bouton(2, "Exit", new Vector2(_widthWindow / 2, _heightWindow / 2 + 220)) };
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
            _perso1.TextureJoueur = new AnimatedSprite(spriteSheet);
            spriteSheet = Content.Load<SpriteSheet>("animationPersoBleu.sf", new JsonContentLoader());
            _perso2.TextureJoueur = new AnimatedSprite(spriteSheet);

            spriteSheet = Content.Load<SpriteSheet>("GBoutonAssetsf.sf", new JsonContentLoader());
            _lesBoutons[0].TextureBouton = new AnimatedSprite(spriteSheet);
            spriteSheet = Content.Load<SpriteSheet>("GBoutonAssetsf.sf", new JsonContentLoader());
            _lesBoutons[1].TextureBouton = new AnimatedSprite(spriteSheet);
            spriteSheet = Content.Load<SpriteSheet>("PBoutonAssetsf.sf", new JsonContentLoader());
            _lesBoutons[2].TextureBouton = new AnimatedSprite(spriteSheet);
            spriteSheet = Content.Load<SpriteSheet>("GBoutonAssetsf.sf", new JsonContentLoader());
            _lesBoutons[3].TextureBouton = new AnimatedSprite(spriteSheet);
            spriteSheet = Content.Load<SpriteSheet>("GBoutonAssetsf.sf", new JsonContentLoader());
            _lesBoutons[4].TextureBouton = new AnimatedSprite(spriteSheet);

            _font = Content.Load<SpriteFont>("font");

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _mapManager = new MapManager(this);
            _mapManager.SelectMap("default");
        }

        protected override void Update(GameTime gameTime)
        {
            _hud.Update(gameTime);

            
            
            float deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds; // DeltaTime

            _hud.Update(gameTime);

            if (_hud.QuiEstClicker(out Bouton boutonclicker) && boutonclicker.NomBouton == "Exit" && _hud.Actif == true)
                Exit();
            else if (_hud.QuiEstClicker(out boutonclicker) && boutonclicker.NomBouton == "Start" && _hud.Actif == true && _hud.NumMenu == 1)
                _hud.Actif = false;
            else if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) && _hud.Actif == false)
            {
                _hud.NumMenu = 2;
                _hud.Actif = true;
            }
            else if (_hud.QuiEstClicker(out boutonclicker) && boutonclicker.NomBouton == "Pause") 
            {
                _hud.Actif = false;
            }
            


            if (!_hud.Actif == true)
            {
                _perso1.Update(gameTime, _mapManager.CurrentMap);
                _perso2.Update(gameTime, _mapManager.CurrentMap);

                _gobelin.Update(_listJoueur, gameTime, deltaSeconds, _mapManager.CurrentMap);


                _mapManager.Update(gameTime);
            }

            

            base.Update(gameTime);
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _mapManager.Draw();
            _spriteBatch.Begin();

            

            _gobelin.Draw(_spriteBatch);

            _perso1.Draw(_spriteBatch);
            _perso2.Draw(_spriteBatch);

            _hud.Draw(_spriteBatch);
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}