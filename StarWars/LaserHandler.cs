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

            //Spawn 2 lasers at each wing of the xwing
            lasers.Add(new Laser(texture, player.Position + new Vector2(width * 0.065f, height * 0.245f), 10, 10));
            lasers.Add(new Laser(texture, player.Position + new Vector2(width - (width * 0.09f), height * 0.245f), 10, 10));
        }
        public void Update()
        {
            //Update the laser positions
            foreach (Laser laser in lasers)
                laser.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Laser laser in lasers)
                laser.Draw(spriteBatch);
        }
    }
}
