using System.Numerics;
using Raylib_cs;

Vector2 window = new Vector2(800, 800);
Vector4 windowSizeToAdd = Vector4.Zero;
int shrinkSize = 2;
int shrinkEveryXFrame = 2;
int currentFrames = 0;

Raylib.InitWindow((int)window.X, (int)window.Y, "WindowShooter");
Raylib.SetTargetFPS(60);
Player player = new Player(new Vector2(window.X / 2, window.Y / 2), 20, 5);

while (!Raylib.WindowShouldClose())
{
    Raylib.SetWindowSize((int)window.X, (int)window.Y);
    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.BLACK);

    currentFrames++;
    if (currentFrames >= shrinkEveryXFrame && windowSizeToAdd.Z == 0 && windowSizeToAdd.W == 0)
    {
        currentFrames = 0;
        window.X -= shrinkSize;
        Raylib.SetWindowPosition((int)Raylib.GetWindowPosition().X + 1, (int)Raylib.GetWindowPosition().Y);
        player.pos.X -= 1;

        if (window.X < 50)
        {
            break;
        }
    }
    else
    {
        if (windowSizeToAdd.Z != 0)
        {
            window.X += windowSizeToAdd.Z;
            Console.WriteLine("right");
            Raylib.SetWindowPosition((int)Raylib.GetWindowPosition().X - (int)windowSizeToAdd.Z, (int)Raylib.GetWindowPosition().Y);
            windowSizeToAdd.Z = 0;
        }
        if (windowSizeToAdd.W != 0)
        {
            window.X += windowSizeToAdd.W;
            Console.WriteLine("öeft");
            windowSizeToAdd.W = 0;
        }
    }

    if (currentFrames >= shrinkEveryXFrame && windowSizeToAdd.Z == 0 && windowSizeToAdd.W == 0)
    {
        currentFrames = 0;
        window.Y -= shrinkSize;
        Raylib.SetWindowPosition((int)Raylib.GetWindowPosition().X, (int)Raylib.GetWindowPosition().Y + 1);
        player.pos.Y -= 1;

        if (window.Y < 50)
        {
            break;
        }
    }




    player.ControllPlayer((int)window.X, (int)window.Y);
    player.RenderPlayer();
    windowSizeToAdd += Bullet.ControllBullets((int)window.X, (int)window.Y);


    Raylib.EndDrawing();
}

