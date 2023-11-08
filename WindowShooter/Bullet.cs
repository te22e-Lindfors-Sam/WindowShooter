using System.Numerics;
using Raylib_cs;

class Bullet
{
    public Vector2 pos;
    int speedX;
    int speedY;

    public static List<Bullet> bullelts = new List<Bullet>();

    public Bullet(Vector2 pos, int speedX, int speedY)
    {
        this.pos = pos;
        this.speedX = speedX;
        this.speedY = speedY;
    }

    public static void ControllBullets()
    {
        for (int i = 0; i < bullelts.Count; i++)
        {   
            bullelts[i].pos.X += bullelts[i].speedX;
            bullelts[i].pos.Y += bullelts[i].speedY;
            Raylib.DrawCircle((int)bullelts[i].pos.X, (int)bullelts[i].pos.Y, 5, Color.WHITE);
        }
    }

}