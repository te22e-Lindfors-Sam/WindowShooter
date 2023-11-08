using Raylib_cs;
using System.Numerics;
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
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            Vector2 mousePos = Raylib.GetMousePosition();
            //float k = ((int)pos.Y-(int)mousePos.Y) * -1/ ((int)pos.X-(int)mousePos.X) * -1;

            // float bullety = ((int)pos.Y-(int)mousePos.Y) * -1;

            Vector2 bulletVelocity = new Vector2(
                ((int)pos.X - (int)mousePos.X) * -1,
                ((int)pos.Y - (int)mousePos.Y) * -1
                );
            bulletVelocity = Vector2.Normalize(bulletVelocity) * 5;
            Bullet bullet = new Bullet(pos, (int)bulletVelocity.X, (int)bulletVelocity.Y);
            Bullet.bullelts.Add(bullet);
        }
    }

    public void RenderPlayer()
    {
        Vector2 mousePos = Raylib.GetMousePosition();
        Raylib.DrawCircle((int)pos.X, (int)pos.Y, playerSize, Color.WHITE);
        double dir = MathF.Atan2(pos.Y - mousePos.Y, mousePos.X - pos.Y) * 180.0 / MathF.PI * -1 - 90;
        Raylib.DrawTextureEx(gun, new Vector2((int)pos.X, (int)pos.Y), (float)dir, 2f, Color.WHITE);
    }



}