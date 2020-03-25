using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarWars
{
    class Laser:Entity
    {
        public Laser(Texture2D texture, int hitboxSize, int speed):base(texture, hitboxSize, speed) { }

        public override void Update()
        {

        }
    }
}
