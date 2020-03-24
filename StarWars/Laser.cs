using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarWars
{
    class Laser:Entity
    {
        public Laser(Texture2D texture, Vector2 position, int hitboxSize, int speed):base(texture, position, hitboxSize, speed) { }

        public override void Update()
        {

        }
    }
}
