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
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
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

        public static Vector4 operator *(Vector4 lhs, float scaler)
        {
            return new Vector4(lhs.X * scaler, lhs.Y * scaler, lhs.Z * scaler, lhs.W * scaler);
        }

        public static Vector4 operator /(Vector4 lhs, float scaler)
        {
            return new Vector4(lhs.X/scaler, lhs.Y/scaler, lhs.Z/scaler, lhs.W/scaler);
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

            return this / Magnitude;
        }

        public static Vector4 CrossProduct(Vector3 lhs, Vector3 rhs)
        {
            return new Vector4
            {
                X = (lhs.Z * rhs.Y) - (lhs.Y * rhs.Z),
                Y = (lhs.Z * rhs.X) - (lhs.X * rhs.Z),
                Z = (lhs.X * rhs.Y) - (lhs.Y * rhs.X),
                W = 0
            };
        }
    }
}
