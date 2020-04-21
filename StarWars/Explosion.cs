using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace StarWars
{
    class Explosion:GameObject
    {
        private int currentFrame = 0;
        private bool isAnimating = true;

        public bool IsAnimating { get => isAnimating; }
        public int CurrentFram { get => currentFrame; }

        public Explosion(Texture2D texture, int hitboxX, int hitboxY) :base(texture, hitboxX, hitboxY) { }

        public override void Update()
        {
            currentFrame++;
        }
    }
}
