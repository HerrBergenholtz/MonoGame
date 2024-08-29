using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    public class Player
    {
        Vector2 position = new Vector2(400, 240);
        Texture2D texture;

        public Player(Texture2D texture) {
            this.texture = texture;
        }

        public void Update() {
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

        public void Draw(SpriteBatch spriteBatch) {
            Rectangle playerRectangle = new Rectangle((int)position.X, (int)position.Y, 100, 100);
            spriteBatch.Draw(texture, playerRectangle, Color.AliceBlue);
        }
    }
}