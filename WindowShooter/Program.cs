using System.Numerics;
using Raylib_cs;

int windowX = 800, windowY = 800;
Raylib.InitWindow(windowX, windowY, "WindowShooter");
Raylib.SetTargetFPS(60);
Player player = new Player(new Vector2(windowX/2,windowY/2), 20, 5);

while (!Raylib.WindowShouldClose())
{
  Raylib.BeginDrawing();
  
  Raylib.ClearBackground(Color.BLACK);
  

    player.ControllPlayer(windowX, windowY);
    player.renderPlayer();


  Raylib.EndDrawing();
}