using System.Numerics;
using Raylib_cs;

class Player
{
    public Vector2 pos;
    float rotation;
    public int hp;
    public float speed;

    int playerSize = 20;
    Texture2D gun;

    public Player(Vector2 pos, int hp, float speed)
    {
        this.pos = pos;
        this.hp = hp;
        this.speed = speed;
        gun = Raylib.LoadTexture("gun.png");
    }

    public void ControllPlayer(int windowX, int windowY)
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
        {
            if (pos.Y - speed > 0)
                pos.Y -= speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
        {
            if (pos.Y + speed < windowY)
                pos.Y += speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            if (pos.X - speed > 0)
                pos.X -= speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            if (pos.X + speed < windowX)
                pos.X += speed;
        }

        
    }

    public void renderPlayer()
    {
        Vector2 mousePos = Raylib.GetMousePosition();
        Raylib.DrawCircle((int)pos.X, (int)pos.Y, playerSize, Color.WHITE);
        double dir = MathF.Atan2(pos.Y - mousePos.Y, mousePos.X - pos.Y) * 180.0 / MathF.PI * -1 - 90;
        Raylib.DrawTextureEx(gun, new Vector2((int)pos.X, (int)pos.Y), (float)dir, 2f, Color.WHITE);
    }


}