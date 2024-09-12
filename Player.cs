using System.Numerics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;


namespace MonoGame {
    public class Player : Sprite {
        public Player(Texture2D texture, Microsoft.Xna.Framework.Vector2 position) : base(texture, position) { }

        public override void Update()
        {
            KeyboardState kState = Keyboard.GetState();

            if(kState.IsKeyDown(Keys.W)) {
                position.Y -= 1;
            }
            if(kState.IsKeyDown(Keys.S)) {
                position.Y += 1;
            }
            if( kState.IsKeyDown(Keys.A)) {
                position.X -= 1;
            }
            if( kState.IsKeyDown(Keys.D)) {
                position.X += 1;
            }
        }
    }
}