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
    internal class Squelette
    {
        const String PATH = "Monstre\\Squelette\\";
        private int pv;
        static Vector2 DIRECTION_DROITE = new Vector2(1, 0);
        static Vector2 DIRECTION_GAUCHE = new Vector2(-1, 0);
        private Vector2 position;
        const int VITESSE_SQUELETTE = 10;
        private bool estMort;
        private AnimatedSprite idle;
        private AnimatedSprite walk;
        private AnimatedSprite attack;
        private AnimatedSprite takeHit;
        private AnimatedSprite death;
        private SpriteSheet idleT;
        private SpriteSheet walkT;
        private SpriteSheet attackT;
        private SpriteSheet takeHitT;
        private SpriteSheet deathT;
        private AnimatedSprite animationPrincipal;
    

        private Vector2 direction;
        private Game game;


        public Squelette(Vector2 position, Game game, int pv)
        {
            this.Position = position;
            this.Game = game;
            this.IdleT = this.Game.Content.Load<SpriteSheet>(PATH + "Idle.sf", new JsonContentLoader());
            this.WalkT = this.Game.Content.Load<SpriteSheet>(PATH + "Walk.sf", new JsonContentLoader());
            this.AttackT = this.Game.Content.Load<SpriteSheet>(PATH + "Attack.sf", new JsonContentLoader());
            this.TakeHitT = this.Game.Content.Load<SpriteSheet>(PATH + "Take_Hit.sf", new JsonContentLoader());
            this.DeathT = this.Game.Content.Load<SpriteSheet>(PATH + "Death.sf", new JsonContentLoader());
            this.AnimationPrincipal = Idle;
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

        public AnimatedSprite Idle  
        {
            get
            {
                return this.idle;
            }

            set
            {
                this.idle = value;
            }
        }

        public SpriteSheet IdleT
        {
            get
            {
                return this.idleT;
            }

            set
            {
                this.idleT = value;
                this.Idle = new AnimatedSprite(value);
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

        public AnimatedSprite Walk
        {
            get
            {
                return this.walk;
            }

            set
            {
                this.walk = value;
            }
        }

        public AnimatedSprite Attack
        {
            get
            {
                return this.attack;
            }

            set
            {
                this.attack = value;
            }
        }

        public AnimatedSprite TakeHit
        {
            get
            {
                return this.takeHit;
            }

            set
            {
                this.takeHit = value;
            }
        }

        public AnimatedSprite Death
        {
            get
            {
                return this.death;
            }

            set
            {
                this.death = value;
            }
        }

        public SpriteSheet WalkT
        {
            get
            {
                return this.walkT;
            }

            set
            {
                this.walkT = value;
                this.Walk = new AnimatedSprite(value);
            }
        }

        public SpriteSheet AttackT
        {
            get
            {
                return this.attackT;
            }

            set
            {
                this.attackT = value;
                this.Attack = new AnimatedSprite(value);
            }
        }

        public SpriteSheet DeathT
        {
            get
            {
                return this.deathT;
            }

            set
            {
                this.deathT = value;
                this.Death = new AnimatedSprite(value);
            }
        }

        public SpriteSheet TakeHitT
        {
            get
            {
                return this.takeHitT;
            }

            set
            {
                this.takeHitT = value;
                this.TakeHit = new AnimatedSprite(value);
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

        public Joueur EstProcheDe(Joueur[] joueurs)
        {
           Joueur min = joueurs[0];
            for(int i = 0; i < joueurs.Length; i++)
            {
                if (Math.Abs(min.PositionJoueur.X) > Math.Abs(joueurs[i].PositionJoueur.X))
                {
                    min = joueurs[i];
                }
            }
            return min;
        }
        
        public void Update(Joueur cible, GameTime gameTime,float deltaSecond,Map map)
        {
            Avance(cible, gameTime,map);
            JouerUneAnimation(deltaSecond);
                
        }
        public void Avance(Joueur cible,GameTime gameTime, Map map)
        {
            float second = gameTime.GetElapsedSeconds();
            ushort tx, ty;
            RegleMap.Direction(this.Position, "B", map, out tx, out ty);
            if (!map.EstEnCollision(tx, ty))
            {
                Gravite(second);
            }
            
            this.direction = Vector2.Zero;
            if(cible.PositionJoueur.X < this.position.X)
            {
                this.direction = new Vector2(-1, 0);
            }
            else if(cible.PositionJoueur.X > this.position.X)
            {
                this.direction = new Vector2(1, 0);
            }
            this.position += direction * second * VITESSE_SQUELETTE;
            
        }
        public void Gravite(float second)
        {
            this.Position += new Vector2(0, 1) * second * 100;
        }
        public void JouerUneAnimation(float deltasecond)
        {
            if(this.direction == DIRECTION_DROITE)
            {
                this.AnimationPrincipal = this.Walk;
                this.AnimationPrincipal.Play("walk");
                this.AnimationPrincipal.Update(deltasecond);
                
            }
            else
            {
                this.AnimationPrincipal = this.idle;
                this.AnimationPrincipal.Play("idle");
                this.AnimationPrincipal.Update(deltasecond);

            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.AnimationPrincipal, this.Position);
            
        }
    }
}
