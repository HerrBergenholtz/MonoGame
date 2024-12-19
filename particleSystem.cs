using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

namespace MonoGame {
    public class ParticleSystem {
        List<Particle> particles = new();
        Texture2D texture;
        Random random = new();
        float windPower = 20;

        public ParticleSystem(Texture2D texture) {
            this.texture = texture;
        }

        private void SpawnParticle() {
            if(random.Next(1, 101) < 30) {
                particles.Add(CreateParticle());
            }
        }

        private void RemoveParticles() {
            for (int i = 0; i < particles.Count; i++) {
                if(particles[i].Position.Y > 500) {
                    particles.RemoveAt(i);
                    i--;
                }
            }
        }

        private Particle CreateParticle() {
            int size = random.Next(5, 25);
            float x = random.Next(-100, 800);
            Vector2 position = new Vector2(x, -20);

            return new Particle(size, Color.GhostWhite, position, texture);
        }

        public void Update() {
            foreach(Particle particle in particles) {
                particle.Velocity = new Vector2(windPower * 0.01666666f, 0);
                particle.Update();
            }
            SpawnParticle();
            RemoveParticles();
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach(Particle particle in particles) {
                particle.Draw(spriteBatch);
            }
        }
    }
}