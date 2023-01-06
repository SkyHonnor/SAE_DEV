using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Animations;
using MonoGame.Extended;
using MonoGame.Extended.Sprites;
using AnimatedSprite = MonoGame.Extended.Sprites.AnimatedSprite;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Content;
namespace TheGame
{
    internal class BarreDeVieJoueur
    {
        private Rectangle grandeurBarreDeVie;
        private Rectangle contenance;
        private Color couleurBarreDeVie;
        private Joueur personnage;
        private Texture2D rectangleVie;
        private Texture2D rectangleContenant;
        private int pvMax;
        private int largeur;


        public BarreDeVieJoueur(Joueur personnage,Color couleurBarreDeVie,Rectangle grandeurBarreDevie, GraphicsDevice graphicsDevice)
        {
            this.Personnage = personnage;
            this.CouleurBarreDeVie = couleurBarreDeVie;
            this.GrandeurBarreDeVie = grandeurBarreDevie;
            this.Contenance = new Rectangle(this.GrandeurBarreDeVie.X + 1, this.GrandeurBarreDeVie.Y + 1, this.GrandeurBarreDeVie.Width -2, grandeurBarreDevie.Height -2 );
            this.RectangleVie = new Texture2D(graphicsDevice,this.Contenance.Width,this.Contenance.Height);
            this.rectangleContenant = new Texture2D(graphicsDevice, this.GrandeurBarreDeVie.Width,this.GrandeurBarreDeVie.Height);
            this.PvMax = personnage.VieJoueur ;
            this.Largeur = rectangleVie.Width;

            Color[] dataVie = new Color[this.RectangleVie.Width * this.rectangleVie.Height];
            for (int i = 0; i < dataVie.Length; ++i) dataVie[i] = couleurBarreDeVie;
            rectangleVie.SetData(dataVie);

            Color[] dataCont = new Color[this.RectangleContenant.Width * this.RectangleContenant.Height];
            for (int i = 0; i < dataCont.Length; ++i) dataCont[i] = Color.Black;
            rectangleContenant.SetData(dataCont);

        }





        public Rectangle GrandeurBarreDeVie
        {
            get
            {
                return this.grandeurBarreDeVie;
            }

            set
            {
                this.grandeurBarreDeVie = value;
            }
        }

        public Rectangle Contenance
        {
            get
            {
                return this.contenance;
            }

            set
            {
                this.contenance = value;
            }
        }

        public Color CouleurBarreDeVie
        {
            get
            {
                return this.couleurBarreDeVie;
            }

            set
            {
                this.couleurBarreDeVie = value;
            }
        }

        public Texture2D RectangleVie
        {
            get
            {
                return this.rectangleVie;
            }

            set
            {
                this.rectangleVie = value;
            }
        }

        public Texture2D RectangleContenant
        {
            get
            {
                return this.rectangleContenant;
            }

            set
            {
                this.rectangleContenant = value;
            }
        }

            

        public int PvMax
        {
            get
            {
                return this.pvMax;
            }

            set
            {
                this.pvMax = value;
            }
        }

        public int Largeur
        {
            get
            {
                return this.largeur;
            }

            set
            {
                this.largeur = value;
            }
        }

        

        internal Joueur Personnage
        {
            get
            {
                return this.personnage;
            }

            set
            {
                this.personnage = value;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Color[] dataVie = new Color[this.RectangleVie.Width * this.rectangleVie.Height];
            for (int i = 0; i < dataVie.Length; ++i) dataVie[i] = couleurBarreDeVie;
            rectangleVie.SetData(dataVie);

            Color[] dataCont = new Color[this.RectangleContenant.Width * this.RectangleContenant.Height];
            for (int i = 0; i < dataCont.Length; ++i) dataCont[i] = Color.Black;
            rectangleContenant.SetData(dataCont);
            spriteBatch.Draw(this.RectangleContenant, this.GrandeurBarreDeVie, Color.White);
            spriteBatch.Draw(this.RectangleVie, this.Contenance, Color.White);

        }
        public void Update()
        {
            
            this.contenance.Width = Largeur * Personnage.VieJoueur / PvMax;
        }
        

    }
}
