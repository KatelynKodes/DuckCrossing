using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public struct Vector4
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z) + (W * W));
            }
        }

        public Vector4 Normalized
        {
            get 
            {
                Vector4 value = this;
                return value.Normalize();
            }
        }

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z, lhs.W + rhs.W);
        }

        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z, lhs.W - rhs.W);
        }

        public static Vector4 operator *(Vector4 lhs, float rhs)
        {
            return new Vector4(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs, lhs.W * rhs);
        }

        /// <summary>
        /// Multiplication of a vector 4 and a float
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector4 operator *(float lhs, Vector4 rhs)
        {
            return new Vector4(lhs * rhs.X, lhs * rhs.Y, lhs * rhs.Z, lhs * rhs.W);
        }

        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            float newX = (lhs.M00 * rhs.X) + (lhs.M01 * rhs.Y) + (lhs.M02 * rhs.Z) + (lhs.M03 * rhs.W);
            float newY = (lhs.M10 * rhs.X) + (lhs.M11 * rhs.Y) + (lhs.M12 * rhs.Z) + (lhs.M13 * rhs.W);
            float newZ = (lhs.M20 * rhs.X) + (lhs.M21 * rhs.Y) + (lhs.M22 * rhs.Z) + (lhs.M23 * rhs.W);
            float newW = (lhs.M30 * rhs.X) + (lhs.M31 * rhs.Y) + (lhs.M32 * rhs.Z) + (lhs.M33 * rhs.W);

            return new Vector4(newX, newY, newZ, newW);
        }

        public static Vector4 operator /(Vector4 lhs, float scalar)
        {
            return new Vector4(lhs.X/scalar, lhs.Y/scalar, lhs.Z/scalar, lhs.W/scalar);
        }

        public static float DotProduct(Vector4 lhs, Vector4 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y) + (lhs.Z * rhs.Z) + (lhs.W * rhs.W);
        }

        public static float Distance(Vector4 lhs, Vector4 rhs)
        {
            return (lhs-rhs).Magnitude;
        }

        public Vector4 Normalize()
        {
            if (Magnitude == 0)
            {
                return new Vector4();
            }

            return this /= Magnitude;
        }

        public static Vector4 CrossProduct(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4
            {
                X = (lhs.Y * rhs.Z) - (lhs.Z * rhs.Y),
                Y = (lhs.Z * rhs.X) - (lhs.X * rhs.Z),
                Z = (lhs.X * rhs.Y) - (lhs.Y * rhs.X),
                W = 0
            };
        }
    }
}
