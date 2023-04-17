using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame3D;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Model model;

    

    private Matrix world = Matrix.CreateTranslation(new Vector3(0, 0, 0));
    private Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 20), new Vector3(0, 0, 0), Vector3.UnitY);
    private Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 100f);



    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        model = Content.Load<Model>("potions_0");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        

        DrawModel(model, world, view, projection);


        
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }

    

    private void DrawModel(Model model, Matrix world, Matrix view, Matrix projection)
    {
        foreach (ModelMesh mesh in model.Meshes)
        {
            foreach (BasicEffect effect in mesh.Effects)
            {
                effect.World = world;
                effect.View = view;
                effect.Projection = projection;
            }
    
            mesh.Draw();
        }
    }


}
