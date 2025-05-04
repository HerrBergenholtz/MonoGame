using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private ParticleSystem particleSystem;
    private Weather weatherState;
    private SnowBlower snowBlower;
    
    public Game1()
    {
        _graphics = new(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Texture2D pixel = Content.Load<Texture2D>("snowFlake");
        weatherState = new Calm();
        particleSystem = new ParticleSystem(pixel, weatherState);
    }

    protected override void Update(GameTime gameTime)
    {
        KeyboardState keys = Keyboard.GetState();
        MouseState mouse = Mouse.GetState();

        if (keys.IsKeyDown(Keys.Right)) {
            particleSystem.WindSpeedControl(true);
        }
        if (keys.IsKeyDown(Keys.Left)) {
            particleSystem.WindSpeedControl(false);
        }

        if (keys.IsKeyDown(Keys.D1)) {
            particleSystem.SetWeather(new Calm());
        }
        if (keys.IsKeyDown(Keys.D2)) {
            particleSystem.SetWeather(new Windy());
        }
        if (keys.IsKeyDown(Keys.D3)) {
            particleSystem.SetWeather(new Blizzard());
        }

        if (mouse.LeftButton == ButtonState.Pressed) {
            Vector2 mousePos = new(mouse.X, mouse.Y);
            snowBlower = new(40, mousePos, particleSystem.GetFallenParticleList);
        }

        particleSystem.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        particleSystem.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
