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
    internal class RegleMap
    {
        private Joueur perso;

        private Monstre monstre;
        private Vector2 positionCollision;
        private Vector2 gravite;
        public RegleMap(Joueur perso)
        {
            this.Perso = perso;
            this.PositionCollision = this.Perso.PositionJoueur;
        }
        public RegleMap(Monstre monstre)
        {
            this.Monstre = monstre;
            this.PositionCollision = this.Monstre.Position;

        }

        public Vector2 PositionCollision
        {
            get
            {
                return this.positionCollision;
            }

            set
            {
                this.positionCollision = value;
            }
        }

        public Vector2 Gravite
        {
            get
            {
                return this.gravite;
            }

            set
            {
                this.gravite = value;
            }
        }

        internal Joueur Perso
        {
            get
            {
                return this.perso;
            }

            set
            {
                this.perso = value;
            }
        }

        

        internal Monstre Monstre
        {
            get
            {
                return this.monstre;
            }

            set
            {
                this.monstre = value;
            }
        }

        public static void Direction(Vector2 positionCollision, string direction, Map mapCollision, out ushort tx, out ushort ty) //Test la tile selon la direction.
        {
            tx = (ushort)(positionCollision.X / mapCollision.TiledMap.TileWidth);
            ty = (ushort)(positionCollision.Y / mapCollision.TiledMap.TileHeight);

            switch (direction.ToUpper())
            {
                case "H":
                    {
                        ty = (ushort)(positionCollision.Y / mapCollision.TiledMap.TileHeight - 1);
                        break;
                    }
                case "B":
                    {
                        ty = (ushort)(positionCollision.Y / mapCollision.TiledMap.TileHeight + 1);
                        break;
                    }
                case "D":
                    {
                        tx = (ushort)(positionCollision.X / mapCollision.TiledMap.TileWidth + 1);
                        break;
                    }
                case "G":
                    {
                        tx = (ushort)(positionCollision.X / mapCollision.TiledMap.TileWidth - 1);
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

