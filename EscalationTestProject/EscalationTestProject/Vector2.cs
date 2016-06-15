using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalationTestProject
{
    class Vector2
    {

        public float x;
        public float y;

        public Vector2() { }
        public Vector2(float _x, float _y)
        {
            x = _x;
            y = _y;
        }
        public Vector2(Vector2 v)
        {
            x = v.x;
            y = v.y;
        }

        public float Magnitude
        {
            get
            {
                return Math.Abs((float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));
            }
        }

        public Vector2 Normal
        {
            get
            {
                return this / Magnitude;
            }
        }

        public static float DotPoduct(Vector2 a, Vector2 b)
        {
            return (a.x * b.x) + (a.y * b.y);
        }

        public static Vector2 operator -(Vector2 vec, Vector2 other)
        {
            return new Vector2(vec.x - other.x, vec.y - other.y);
        }

        public static Vector2 operator *(Vector2 vec, float other)
        {
            return new Vector2(vec.x * other, vec.y * other);
        }
        public static Vector2 operator /(Vector2 vec, float other)
        {
            return new Vector2(vec.x / other, vec.y / other);
        }

        public static double DegToRad
        {
            get
            {
                return Math.PI / 180;
            }
        }
    }
}
