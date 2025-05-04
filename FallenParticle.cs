using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace MonoGame {
    public class FallenParticle {
        private int size;
        private Color color;
        private Vector2 position;
        private Texture2D texture;
        private float time = 0;
        private Vector2 velocity = new();

        public Vector2 Position {
            get{ return position; }
            set { position = value; }
        }

        public Vector2 Velocity {
            set{ velocity = value; }
        }

        public FallenParticle(int size, Color color, Vector2 position, Texture2D texture) {
            this.size = size;
            this.color = color;
            this.position = position;
            this.texture = texture;
            Random random = new();
            time = (float)(random.NextDouble() * MathF.Tau);
        }

        public void BlownAway() {
            velocity.Y -= 0.25f;
            if(position.X > 400) {
                velocity.X += 2;
            }
            else {
                velocity.X -= 2;
            }
        }

        public void Update() {
            float dt = 1f / 60f;
            time += dt;
            position += velocity;
        }

        public void Draw(SpriteBatch spriteBatch) {
            Rectangle r = new Rectangle((int)position.X, (int)position.Y, size, size);
            spriteBatch.Draw(texture, r, color);
        }
    }
}