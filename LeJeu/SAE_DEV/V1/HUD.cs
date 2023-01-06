using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    internal class HUD
    {
        private bool actif;
        private Bouton[] lesBoutons;
        private int numMenu;

        public HUD(bool actif, int numMenu, Bouton[] boutons)
        {
            this.Actif = actif;
            this.NumMenu = numMenu;
            this.LesBoutons = boutons;
        }

        public bool Actif
        {
            get
            {
                return this.actif;
            }

            set
            {
                this.actif = value;
            }
        }

        public int NumMenu
        {
            get
            {
                return this.numMenu;
            }

            set
            {
                this.numMenu = value;
            }
        }

        internal Bouton[] LesBoutons
        {
            get
            {
                return this.lesBoutons;
            }

            set
            {
                this.lesBoutons = value;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Actif == true) { 
            foreach (Bouton i in lesBoutons)
            {
                if (i.NummenuBouton == NumMenu)
                {
                    i.Draw(spriteBatch);
                }
            }
            }
        }

        public bool QuiEstClicker(out Bouton boutonclicker)
        {
            foreach (Bouton i in LesBoutons)
            {
                if (i.EstClicker() && i.NummenuBouton == NumMenu)
                {
                    boutonclicker = i;
                    return true;
                }
            }
            boutonclicker = null;
            return false;
        }

        public void Update(GameTime gametime)
        {
            foreach (Bouton i in LesBoutons)
            {
                i.Update(gametime);
            }
        }


    }

}
