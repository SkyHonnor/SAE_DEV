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
    internal class Monstre
    {
        private Vector2 position;
        private int id;
        private int pv;
        private Squelette squelette;
        private Goblin goblin;
        private Game game;
        

        

        public Monstre(Vector2 position, Game game, int id, int pv)
        {
            this.Position = position;
            this.Game = game;
            this.Id = id;
            this.Pv = pv;
          
        }

        public Vector2 Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.position = value;
                
                
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if(value == 1 ||value == 2)
                {
                this.id = value;

                }
                else
                {
                    throw new ArgumentException("pas de monstre avec cette ID");
                }
            }
        }

        public int Pv
        {
            get
            {
                return this.pv;
            }

            set
            {
                this.pv = value;
            }
        }

        internal Squelette Squelette
        {
            get
            {
                return this.squelette;
            }

            set
            {
                this.squelette = value;
            }
        }

        internal Goblin Goblin
        {
            get
            {
                return this.goblin;
            }

            set
            {
                this.goblin = value;
            }
        }

        public Game Game
        {
            get
            {
                return this.game;
            }

            set
            {
                this.game = value;
            }
        }

        

        public void Init()
        {
            if (this.Id == 1)
            {
                this.Squelette = new Squelette(this.Position, this.Game,this.Pv);

            }
            else
            {
                this.Goblin = new Goblin(Position, this.Game, this.Pv);
            }
        }


        public void Update(List<Joueur> joueurs,GameTime gameTime , float deltaSecond,Map map)
        {

            if (id == 1)
            {
                Squelette.Update(CiblePlusProche(joueurs), gameTime, deltaSecond,map); 
            }
            else
            {
                Goblin.Update(CiblePlusProche(joueurs), gameTime, deltaSecond,map);
            }

        }

        public Joueur CiblePlusProche(List<Joueur> listjoueurs)
        {
            Joueur joueurLePlusProche = listjoueurs[0];

            foreach (Joueur i in listjoueurs)
            {
                if (Vector2.Distance(Position, joueurLePlusProche.PositionJoueur) > Vector2.Distance(Position, i.PositionJoueur))
                {
                    joueurLePlusProche = i;
                }
            }
            return joueurLePlusProche;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (id == 1)
            {
                Squelette.Draw(spriteBatch);
            }
            else
            {
                Goblin.Draw(spriteBatch);
            }
        }

    }
}
