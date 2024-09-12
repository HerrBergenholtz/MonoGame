using System.Numerics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonoGame {
    public class Enemy : Sprite {
        public Enemy(Texture2D texture, Microsoft.Xna.Framework.Vector2 position) : base(texture, position) { }

        public void Move() {

        }

        public override void Draw(SpriteBatch spriteBatch, int width, int height) {
            Rectangle spriteRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            spriteBatch.Draw(texture, spriteRectangle, Color.Red);
        }
    }
}