using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace StarWars
{
    class Player:Entity
    {
        public Player(Texture2D texture, Vector2 position, int hitboxSize, int speed):base(texture, position, hitboxSize, speed) {}

        public override void Update()
        {
            
        }
    }
}
