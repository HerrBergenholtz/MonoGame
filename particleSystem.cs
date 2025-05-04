using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

namespace MonoGame {
    public class ParticleSystem {
        List<Particle> particles = new();
        List<FallenParticle> fallenParticles = new();
        Texture2D texture;
        Random random = new();
        Weather weatherState;
        float windPower;
        int snowRate;

        public List<FallenParticle> GetFallenParticleList {
            get { return fallenParticles; }
        }

        public ParticleSystem(Texture2D texture, Weather weatherState) {
            this.texture = texture;
            this.weatherState = weatherState;

            UpdateControls();
        }

        private void UpdateControls() {
            windPower = weatherState.GetWindPower();
            snowRate = weatherState.GetSnowRate();
        }

        private void SpawnParticle() {
            if(random.Next(1, 101) < snowRate) {
                particles.Add(CreateParticle());
            }
        }

        private void RemoveParticles() {
            for (int i = 0; i < particles.Count; i++) {
                if(particles[i].CheckCollisions()) {
                    Particle p = particles[i];
                    particles.RemoveAt(i);
                    FallenParticle fp = new(p.Size, p.Color, p.Position, p.Texture);
                    fallenParticles.Add(fp);
                    OrderFallenParticles(ref fp);
                    i--;
                }
            }
        }

        public void SetWeather(Weather newWeather) {
            weatherState = newWeather;
            UpdateControls();
        }

        private void OrderFallenParticles(ref FallenParticle particle) {
            int range = 5;
            int increment = 5;

            bool needsAdjustment;
            do {
                needsAdjustment = false;

                foreach (FallenParticle other in fallenParticles) {
                    if (other != particle) {
                        float distance = Vector2.Distance(particle.Position, other.Position);
                        if (distance < range) {
                            particle.Position = new Vector2(particle.Position.X, particle.Position.Y - increment);

                            needsAdjustment = true;
                            break;
                        }
                    }
                }
            }
            while (needsAdjustment);
        }

        public void WindSpeedControl(bool increase) {
            if(increase & windPower < 100) {
                windPower += 2;
            }
            else if (!increase & windPower > -80) {
                windPower -= 2;
            }
        }

        private Particle CreateParticle() {
            int size = random.Next(5, 15);
            float x = random.Next(-650, 700);
            Vector2 position = new(x, -20);

            return new Particle(size, Color.GhostWhite, position, texture);
        }

        public void Update() {
            foreach(Particle particle in particles) {
                particle.Velocity = new Vector2(windPower * 0.01666666f, 0);
                particle.Update();
            }
            foreach(FallenParticle particle in fallenParticles) {
                particle.Update();
            }
            SpawnParticle();
            RemoveParticles();
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach(Particle particle in particles) {
                particle.Draw(spriteBatch);
            }
            foreach(FallenParticle particle in fallenParticles) {
                particle.Draw(spriteBatch);
            }
        }
    }
}