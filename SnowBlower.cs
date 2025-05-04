using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MonoGame {
    public class SnowBlower {
        private Vector2 position;
        private float radius;
        private List<FallenParticle> particles;

        public SnowBlower(float radius, Vector2 position, List<FallenParticle> particles) {
            this.position = position;
            this.radius = radius;
            this.particles = particles;

            SearchList();
        }

        private void SearchList() {
            foreach (FallenParticle particle in particles) {
                float distance = Vector2.Distance(particle.Position, position);
                if (distance < radius) {
                    particle.BlownAway();
                }
            }
        }
    }
}