using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace MonoGame {
    public class Particle {
        private int size;
        private Color color;
        private float minFallSpeed = 20;
        private float maxFallSpeed = 70;
        private float fallSpeed = 0;
        private Vector2 position;
        private Texture2D texture;
        private float time = 0;
        private Vector2 velocity = new();

        public Vector2 Position {
            get{ return position; }
        }

        public Vector2 Velocity {
            set{ velocity = value; }
        }

        public Particle(int size, Color color, Vector2 position, Texture2D texture) {
            this.size = size;
            this.color = color;
            this.position = position;
            this.texture = texture;
            Random random = new();
            time = (float)(random.NextDouble() * MathF.Tau);

            float fallSpeedDiff = maxFallSpeed - minFallSpeed;
            float sizePercent = size / 20f;
            fallSpeed = minFallSpeed + (fallSpeedDiff * sizePercent);
        }

        public void Update() {
            float dt = 1f / 60f;
            time += dt;
            velocity.Y = fallSpeed * dt;
            velocity.X += MathF.Sin(time * 3);
            position += velocity;
        }

        public void Draw(SpriteBatch spriteBatch) {
            Rectangle r = new Rectangle((int)position.X, (int)position.Y, size, size);
            spriteBatch.Draw(texture, r, color);
        }
    }
}