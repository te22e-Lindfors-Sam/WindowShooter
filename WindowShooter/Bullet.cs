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

    public static Vector4 ControllBullets(int windowX, int windowY)
    {
        Vector4 windowSizeToAdd = Vector4.Zero;
        for (int i = bullelts.Count - 1; i > 0; i--)
        {
            bullelts[i].pos.X += bullelts[i].speedX;
            bullelts[i].pos.Y += bullelts[i].speedY;
            Raylib.DrawCircle((int)bullelts[i].pos.X, (int)bullelts[i].pos.Y, 5, Color.WHITE);
            if (bullelts[i].pos.Y < 0)
            {
                bullelts.Remove(bullelts[i]);
                windowSizeToAdd.X += 50;
            }
            else if (bullelts[i].pos.Y > windowY)
            {
                bullelts.Remove(bullelts[i]);
                windowSizeToAdd.Y += 50;
            }
            else if (bullelts[i].pos.X < 0)
            {
                bullelts.Remove(bullelts[i]);
                windowSizeToAdd.Z += 50;
            }
            else if (bullelts[i].pos.X > windowX)
            {
                bullelts.Remove(bullelts[i]);
                windowSizeToAdd.W += 50;
            }
        }
        return windowSizeToAdd;
    }

}