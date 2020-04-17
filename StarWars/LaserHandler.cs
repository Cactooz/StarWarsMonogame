using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarWars
{
    class LaserHandler
    {
        private Texture2D texture;
        private List<Laser> lasers = new List<Laser>();
        private Player player;

        private float speed = 10f;
        private int hitboxX = 5;
        private int hitboxY = 10;
         
        public List<Laser> Lasers { get => lasers; set => lasers = value; }

        public LaserHandler(Texture2D texture, Player player)
        {
            this.texture = texture;

            this.player = player;
        }

        public void Spawn()
        {
            //Get the width and height of the player hitbox
            float width = player.Hitbox.Width;
            float height = player.Hitbox.Height;

            //Spawn 1 laser at each wing of the xwing
            lasers.Add(new Laser(texture, player.Position + new Vector2(width * 0.035f, height * 0.25f), hitboxX, hitboxY, speed));
            lasers.Add(new Laser(texture, player.Position + new Vector2(width - (width * 0.065f), height * 0.25f), hitboxX, hitboxY, speed));
        }
        public void Update()
        {
            //Update the laser positions
            foreach (Laser laser in lasers)
                laser.Update();

            //Check if the lasers are outside of the screen
            CheckIfOutside();

            //Remove the lasers
            RemoveLasers();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw the lasers
            foreach (Laser laser in lasers)
                laser.Draw(spriteBatch);
        }
        private void CheckIfOutside()
        {
            //Set laser alive state to false if the laser is ouside of the screen
            foreach (Laser laser in lasers)
            {
                if (laser.Position.Y <= -10)
                    laser.Alive = false;
            }
        }
        private void RemoveLasers()
        {
            //Make a new temp list to fill with lasers
            List<Laser> tempLasers = new List<Laser>();

            //For each laser that is alive, add it to the temp list
            foreach (Laser laser in lasers)
            {
                if (laser.Alive)
                    tempLasers.Add(laser);
            }
            //Overwrite lasers with the temp list
            lasers = tempLasers;
        }
    }
}
