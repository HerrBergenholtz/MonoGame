using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;


namespace MonoGame {
    public class ParticleSystem {
        List<Particle> particles = new();
        Texture2D texture;
        Random random = new();

        public ParticleSystem(Texture2D texture) {
            this.texture = texture;
        }

        private void SpawnParticle() {
            if(random.Next(1, 100) < 10) {
                particles.Add(CreateParticle());
            }
        }

        private Particle CreateParticle() {
            int size = random.Next(1, 20);
            float x = random.Next(0, 800);
            Vector2 position = new Vector2(x, -20);

            return new Particle(size, Color.GhostWhite, position, texture);
        }

        public void Update() {
            foreach(Particle particle in particles) {
                particle.Update();
            }
            SpawnParticle();
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach(Particle particle in particles) {
                particle.Draw(spriteBatch);
            }
        }
    }
}