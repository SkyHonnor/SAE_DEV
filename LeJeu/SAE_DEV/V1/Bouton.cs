using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Sprites;
using System.Diagnostics;

namespace TheGame
{
    internal class Bouton
    {

        private int nummenuBouton;
        private string nomBouton;
        private AnimatedSprite textureBouton;
        private Vector2 positionBouton;

        public Bouton(int nummenuBouton, string nomBouton, Vector2 positionBouton)
        {
            this.nummenuBouton = nummenuBouton;
            this.nomBouton = nomBouton;
            this.positionBouton = positionBouton;
        }

        public int NummenuBouton
        {
            get
            {
                return this.nummenuBouton;
            }

            set
            {
                this.nummenuBouton = value;
            }
        }

        public string NomBouton
        {
            get
            {
                return this.nomBouton;
            }

            set
            {
                this.nomBouton = value;
            }
        }

        public AnimatedSprite TextureBouton
        {
            get
            {
                return this.textureBouton;
            }

            set
            {
                this.textureBouton = value;
            }
        }

        public Vector2 PositionBouton
        {
            get
            {
                return this.positionBouton;
            }

            set
            {
                this.positionBouton = value;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.TextureBouton, this.PositionBouton);
            spriteBatch.DrawString(Game._font, $"{NomBouton}", EstSurvole() ? new Vector2(PositionBouton.X - Game._font.MeasureString(NomBouton).X / 2, PositionBouton.Y - Game._font.MeasureString(NomBouton).Y / 2 + 5) : new Vector2(PositionBouton.X - Game._font.MeasureString(NomBouton).X / 2, PositionBouton.Y - Game._font.MeasureString(NomBouton).Y / 2 - 10), Color.Black);

        }

        public bool EstClicker()
        {
            MouseState mouse = Mouse.GetState();
            return mouse.LeftButton == ButtonState.Pressed && EstSurvole();
        }

        public bool EstSurvole()
        {
            MouseState mouse = Mouse.GetState();
            Rectangle hitboxBouton = new Rectangle((int)PositionBouton.X - TextureBouton.TextureRegion.Width / 2, (int)PositionBouton.Y - TextureBouton.TextureRegion.Height / 2, TextureBouton.TextureRegion.Width, TextureBouton.TextureRegion.Height);
            return hitboxBouton.Contains(mouse.X, mouse.Y);
        }

        public void Update(GameTime gametime)
        {
            if (EstSurvole())
            {
                TextureBouton.Play("true");

            }
            else
            {
                TextureBouton.Play("false");
            }

            TextureBouton.Update(gametime);
        }

    }
}
