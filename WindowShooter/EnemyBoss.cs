using Raylib_cs;
using System.Threading.Tasks;

class EnemyBoss
{
    public int hp;
    public int windowSize;
    public int radius;

    public EnemyBoss(int hp, int windowSize, int radius)
    {
        this.hp = hp;
        this.windowSize = windowSize;
        this.radius = radius;
    }

    public void spawnBoss()
    {
        Task enemy = Task.Run(RegularWork);
    }

    static void RegularWork()
    {
        Raylib.InitWindow(100, 100, "Boss");
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.WHITE);

            Raylib.DrawCircle(100, 100, 100, Color.MAGENTA);

            Raylib.EndDrawing();
        }
    }
}

