using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public class Sprite
    {
        protected Vector2 position;
        protected Texture2D texture;

        public Sprite(Texture2D texture, Vector2 position) {
            this.texture = texture;
            this.position = position;
        }

        public virtual void Update() { }

        public virtual void Draw(SpriteBatch spriteBatch, int width, int height) {
            Rectangle spriteRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            spriteBatch.Draw(texture, spriteRectangle, Color.AliceBlue);
        }
    }
}