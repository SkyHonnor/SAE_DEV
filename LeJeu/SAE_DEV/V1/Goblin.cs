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
    internal class Goblin
    {
        const String PATH = "Monstre\\Goblin\\";
        static Vector2 DIRECTION_DROITE = new Vector2(1, 0);
        static Vector2 DIRECTION_GAUCHE = new Vector2(-1, 0);
        private Vector2 position;
        const int VITESSE_GOBLIN = 20;
        private bool estMort;

        private int pv;
       
        private AnimatedSprite animationPrincipal;
        private SpriteSheet animation; 
        private Vector2 direction;
        private Game game;
        public Goblin(Vector2 position, Game game, int pv)
        {
            this.Position = position;
            this.Game = game;
           
            this.Animation = this.Game.Content.Load<SpriteSheet>(PATH + "animations.sf", new JsonContentLoader());
            this.Pv = pv;
        }
        public bool EstMort
        {
            get
            {
                return this.estMort;
            }

            set
            {
                this.estMort = value;
            }
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

        public Vector2 Direction
        {
            get
            {
                return this.direction;
            }

            set
            {
                this.direction = value;
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

        public AnimatedSprite AnimationPrincipal
        {
            get
            {
                return this.animationPrincipal;
            }

            set
            {
                this.animationPrincipal = value;
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

        public SpriteSheet Animation
        {
            get
            {
                return this.animation;
            }

            set
            {
                this.animation = value;
                this.AnimationPrincipal = new AnimatedSprite(this.Animation);
            }
        }

      

        public Joueur EstProcheDe(Joueur[] joueurs)
        {
            Joueur min = joueurs[0];
            for (int i = 0; i < joueurs.Length; i++)
            {
                if (Math.Abs(min.PositionJoueur.X) > Math.Abs(joueurs[i].PositionJoueur.X))
                {
                    min = joueurs[i];
                }
            }
            return min;
        }
        public Vector2 Avance(Joueur cible, GameTime gameTime, Map map)
        {
            float second = gameTime.GetElapsedSeconds();
            ushort tx, ty; 
            RegleMap.Direction(this.Position, "B", map, out tx, out ty);
            if (!map.EstEnCollision(tx, ty)){
                Gravite(second);
            }
            this.direction = Vector2.Zero;
            if (cible.PositionJoueur.X +5 <= this.position.X)
            {
                this.direction = new Vector2(-1, 0);
            }
            else if (cible.PositionJoueur.X -5  >= this.position.X)
            {
                this.direction = new Vector2(1, 0);
            }
            else 
            {
                this.direction = new Vector2(0, 0);
            }
            
            this.position += direction * second * VITESSE_GOBLIN;
            return direction;
        }
        public void JouerUneAnimation(float deltasecond)
        {
            
            if (this.direction == DIRECTION_DROITE)
            {
                
                this.AnimationPrincipal.Play("run_right");
                this.AnimationPrincipal.Update(deltasecond);

            }
            else if(this.Direction == DIRECTION_GAUCHE)
            {
                
                this.AnimationPrincipal.Play("run_left");
                this.AnimationPrincipal.Update(deltasecond);

            }
            else
            {
                this.AnimationPrincipal.Play("idle");
                this.AnimationPrincipal.Update(deltasecond);
            }
            

        }
        public void Gravite(float second)
        {
            this.Position += new Vector2(0, 1) *second * 100;
        }
        public void Update(Joueur cible, GameTime gameTime,float deltaSecond,Map map)
        {
            Avance(cible, gameTime,map);
            JouerUneAnimation(deltaSecond);
        }
        

        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.AnimationPrincipal, this.Position);

        }
    }
}
