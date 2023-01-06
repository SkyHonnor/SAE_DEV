using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Tiled;

namespace TheGame
{
    internal class Joueur
    {
        private int idJoueur;
        private string speudoJoueur;
        private Vector2 positionJoueur;

        private Vector2 velociteJoueur;
        private float vitesseJoueur;
        private float graviteJoueur;
        private bool jumpJoueur;

        private bool isSword;
        private bool isTaken;
        private AnimatedSprite textureJoueur;

        private int vieJoueur;
        private int vieJoueurMax;
        private int experienceJoueur;
        private int levelJoueur;
        private int degatsDeBaseSword;

        private Keys keyHaut;
        private Keys keyBas;
        private Keys keyDroite;
        private Keys keyGauche;

        private BarreDeVieJoueur barreDeVie;
        private GraphicsDevice graphicsDevice;
        public Joueur(int idJoueur, string speudoJoueur, Vector2 positionJoueur, float vitesseJoueur, float gravite, bool isSword, bool isTaken, int vieJoueur, int vieJoueurMax, int experienceJoueur, int levelJoueur, int degatsDeBaseSword, Keys keyHaut, Keys keyBas, Keys keyDroite, Keys keyGauche, GraphicsDevice graphicsDevice)
        {
            this.IdJoueur = idJoueur;
            this.SpeudoJoueur = speudoJoueur;
            this.PositionJoueur = positionJoueur;

            this.VitesseJoueur = vitesseJoueur;
            this.GraviteJoueur = gravite;
            this.JumpJoueur = true;

            this.IsSword = isSword;
            this.IsTaken = isTaken;

            this.GraphicsDevice = graphicsDevice;

            this.VieJoueur = vieJoueur;
            this.VieJoueurMax = vieJoueurMax;

            this.ExperienceJoueur = experienceJoueur;
            this.LevelJoueur = levelJoueur;
            this.DegatsDeBaseSword = degatsDeBaseSword;
            this.KeyHaut = keyHaut;
            this.KeyBas = keyBas;
            this.KeyDroite = keyDroite;
            this.KeyGauche = keyGauche;
            barreDeVie = new BarreDeVieJoueur(this, Color.Red, new Rectangle(0, 0 + ((idJoueur - 1) * 30), 200, 20), GraphicsDevice);
        }

        public int IdJoueur
        {
            get
            {
                return this.idJoueur;
            }

            set
            {
                this.idJoueur = value;
            }
        }

        public string SpeudoJoueur
        {
            get
            {
                return this.speudoJoueur;
            }

            set
            {
                this.speudoJoueur = value;
            }
        }

        public Vector2 PositionJoueur
        {
            get
            {
                return this.positionJoueur;
            }

            set
            {
                this.positionJoueur = value;
            }
        }

        public Vector2 VelociteJoueur
        {
            get
            {
                return this.velociteJoueur;
            }

            set
            {
                this.velociteJoueur = value;
            }
        }

        public float VitesseJoueur
        {
            get
            {
                return this.vitesseJoueur;
            }

            set
            {
                this.vitesseJoueur = value;
            }
        }

        public float GraviteJoueur
        {
            get
            {
                return this.graviteJoueur;
            }

            set
            {
                this.graviteJoueur = value;
            }
        }

        public bool IsSword
        {
            get
            {
                return this.isSword;
            }

            set
            {
                this.isSword = value;
            }
        }

        public bool IsTaken
        {
            get
            {
                return this.isTaken;
            }

            set
            {
                this.isTaken = value;
            }
        }

        public AnimatedSprite TextureJoueur
        {
            get
            {
                return this.textureJoueur;
            }

            set
            {
                this.textureJoueur = value;
            }
        }

        public int VieJoueur
        {
            get
            {
                return this.vieJoueur;
            }

            set
            {
                this.vieJoueur = value;
            }
        }

        public int ExperienceJoueur
        {
            get
            {
                return this.experienceJoueur;
            }

            set
            {
                this.experienceJoueur = value;
            }
        }

        public int LevelJoueur
        {
            get
            {
                return this.levelJoueur;
            }

            set
            {
                this.levelJoueur = value;
            }
        }

        public int DegatsDeBaseSword
        {
            get
            {
                return this.degatsDeBaseSword;
            }

            set
            {
                this.degatsDeBaseSword = value;
            }
        }

        public Keys KeyHaut
        {
            get
            {
                return this.keyHaut;
            }

            set
            {
                this.keyHaut = value;
            }
        }

        public Keys KeyBas
        {
            get
            {
                return this.keyBas;
            }

            set
            {
                this.keyBas = value;
            }
        }

        public Keys KeyDroite
        {
            get
            {
                return this.keyDroite;
            }

            set
            {
                this.keyDroite = value;
            }
        }

        public Keys KeyGauche
        {
            get
            {
                return this.keyGauche;
            }

            set
            {
                this.keyGauche = value;
            }
        }

        public bool JumpJoueur
        {
            get
            {
                return this.jumpJoueur;
            }

            set
            {
                this.jumpJoueur = value;
            }
        }

        public int VieJoueurMax
        {
            get
            {
                return this.vieJoueurMax;
            }

            set
            {
                this.vieJoueurMax = value;
            }
        }

        internal BarreDeVieJoueur BarreDeVie
        {
            get
            {
                return this.barreDeVie;
            }

            set
            {
                this.barreDeVie = value;
            }
        }

        public GraphicsDevice GraphicsDevice
        {
            get
            {
                return this.graphicsDevice;
            }

            set
            {
                this.graphicsDevice = value;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(this.TextureJoueur, this.PositionJoueur);
            barreDeVie.Draw(spriteBatch);
        }

        public void Update(GameTime gametime, Map mapCollision)
        {
            barreDeVie.Update();
            PositionJoueur += VelociteJoueur;
            string animation = "idle";


            if (Keyboard.GetState().IsKeyDown(KeyDroite))
            {
                Direction("D", mapCollision, out ushort tx, out ushort ty);
                VelociteJoueur = new Vector2(VitesseJoueur, VelociteJoueur.Y);
                if (mapCollision.EstEnCollision(tx, ty))
                    VelociteJoueur = new Vector2(0, VelociteJoueur.Y);
                else
                    animation = "courseD";

            }
            else if (Keyboard.GetState().IsKeyDown(KeyGauche))
            {
                Direction("G", mapCollision, out ushort tx, out ushort ty);
                VelociteJoueur = new Vector2(-VitesseJoueur, VelociteJoueur.Y);
                if (mapCollision.EstEnCollision(tx, ty))
                    VelociteJoueur = new Vector2(0, VelociteJoueur.Y);
                else
                    animation = "courseG";
            }
            else
                VelociteJoueur = new Vector2(0, VelociteJoueur.Y);

            if (Keyboard.GetState().IsKeyDown(KeyHaut) && JumpJoueur == false)
            {
                PositionJoueur -= new Vector2(0, 10);
                VelociteJoueur = new Vector2(VelociteJoueur.X, -5);
                JumpJoueur = true;
            }

            if (JumpJoueur == true)
            {
                float multiplicateurgravity = 1;

                Direction("H", mapCollision, out ushort tx, out ushort ty);
                if (!mapCollision.EstEnCollision(tx, ty))
                {
                    VelociteJoueur += new Vector2(0, (float)GraviteJoueur * multiplicateurgravity);
                    //animation = "";
                }
            }

            Direction("B", mapCollision, out ushort gx, out ushort gy);

            if (mapCollision.EstEnCollision(gx, gy))
            {
                JumpJoueur = false;
            }
            else
                JumpJoueur = true;

            if (JumpJoueur == false)
            {
                VelociteJoueur = new Vector2(VelociteJoueur.X, 0);
            }

            TextureJoueur.Play(animation);
            TextureJoueur.Update(gametime);

        }


        public bool IsDead()
        {
            return this.VieJoueur <= 0;
        }

        public void Direction(string direction, Map mapCollision, out ushort tx, out ushort ty) //Test la tile selon la direction.
        {
            tx = (ushort)(this.PositionJoueur.X / mapCollision.TiledMap.TileWidth);
            ty = (ushort)(this.PositionJoueur.Y / mapCollision.TiledMap.TileHeight);

            switch (direction.ToUpper())
            {
                case "H":
                    {
                        ty = (ushort)(this.PositionJoueur.Y / mapCollision.TiledMap.TileHeight - 1);
                        break;
                    }
                case "B":
                    {
                        ty = (ushort)(this.PositionJoueur.Y / mapCollision.TiledMap.TileHeight + 1);
                        break;
                    }
                case "D":
                    {
                        tx = (ushort)(this.PositionJoueur.X / mapCollision.TiledMap.TileWidth + 1);
                        break;
                    }
                case "G":
                    {
                        tx = (ushort)(this.PositionJoueur.X / mapCollision.TiledMap.TileWidth - 1);
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("Erreur");
                    }
            }
        }
    }
}
