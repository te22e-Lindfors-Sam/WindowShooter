using System.Threading.Tasks;
using System.Numerics;
using Raylib_cs;

Vector2 window = new Vector2(800, 800);
Vector4 windowSizeToAdd = Vector4.Zero;
int shrinkSize = 2;
int shrinkEveryXFrame = 2;
int currentFramesX = 0;
int currentFramesY = 0;

Raylib.InitWindow((int)window.X, (int)window.Y, "WindowShooter");
Raylib.SetTargetFPS(60);

Player player = new Player(new Vector2(window.X / 2, window.Y / 2), 20, 5);
EnemyBoss enemyBoss = new EnemyBoss(10, 50, 20);

while (!Raylib.WindowShouldClose())
{
    Raylib.SetWindowSize((int)window.X, (int)window.Y);
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLACK);

    currentFramesX++;
    currentFramesY++;
    if (currentFramesX >= shrinkEveryXFrame && windowSizeToAdd.Z == 0 && windowSizeToAdd.W == 0)
    {
        currentFramesX = 0;
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
        if (Raylib.GetWindowPosition().X < 0)
        {
            windowSizeToAdd.Z = 0;
        }
        if (Raylib.GetWindowPosition().X + window.X > 1920)
        {
            windowSizeToAdd.W = 0;
        }


        if (windowSizeToAdd.Z != 0)
        {
            windowSizeToAdd.Z -= 3;
            if (windowSizeToAdd.Z < 0)
            {
                windowSizeToAdd.Z = 0;
            }
            window.X += 3;
            Raylib.SetWindowPosition((int)Raylib.GetWindowPosition().X - 3, (int)Raylib.GetWindowPosition().Y);
        }
        if (windowSizeToAdd.W != 0)
        {
            windowSizeToAdd.W -= 3;
            if (windowSizeToAdd.W < 0)
            {
                windowSizeToAdd.W = 0;
            }
            window.X += 3;
        }
    }

    if (currentFramesY >= shrinkEveryXFrame && windowSizeToAdd.X == 0 && windowSizeToAdd.Y == 0)
    {
        currentFramesY = 0;
        window.Y -= shrinkSize;
        Raylib.SetWindowPosition((int)Raylib.GetWindowPosition().X, (int)Raylib.GetWindowPosition().Y + 1);
        player.pos.Y -= 1;

        if (window.Y < 50)
        {
            break;
        }
    }
    else
    {
        if (Raylib.GetWindowPosition().Y < 0)
        {
            windowSizeToAdd.X = 0;
        }
        if (Raylib.GetWindowPosition().Y + window.Y > 1060)
        {
            windowSizeToAdd.Y = 0;
        }

        if (windowSizeToAdd.X != 0)
        {
            windowSizeToAdd.X -= 3;
            if (windowSizeToAdd.X < 0)
            {
                windowSizeToAdd.X = 0;
            }
            window.Y += 3;
            Raylib.SetWindowPosition((int)Raylib.GetWindowPosition().X, (int)Raylib.GetWindowPosition().Y - 3);
        }
        if (windowSizeToAdd.Y != 0)
        {
            windowSizeToAdd.Y -= 3;
            if (windowSizeToAdd.Y < 0)
            {
                windowSizeToAdd.Y = 0;
            }
            window.Y += 3;
        }
    }

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_U))
    {
        enemyBoss.spawnBoss();
    }


    player.ControllPlayer((int)window.X, (int)window.Y);
    player.RenderPlayer();
    windowSizeToAdd += Bullet.ControllBullets((int)window.X, (int)window.Y);


    Raylib.EndDrawing();
}



