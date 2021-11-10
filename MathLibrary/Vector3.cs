using System;

namespace MathLibrary
{
    public struct Vector3
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3(float xvalue, float yvalue, float zvalue)
        {
            X = xvalue;
            Y = yvalue;
            Z = zvalue;
        }

        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public Vector3 Normalized
        {
            get
            {
                Vector3 value = this;
                return value.Normalize();
            }
        }

        public static float DotProduct(Vector3 lhs, Vector3 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y) + (lhs.Z * rhs.Z);
        }

        /// <summary>
        /// Checks the distance between two vector 3's
        /// </summary>
        /// <param name="lhs">lefthand side of the equation</param>
        /// <param name="rhs">righthand side of the equation</param>
        /// <returns>The magnitude of the subtraction between both vector3's</returns>
        public static float Distance(Vector3 lhs, Vector3 rhs)
        {
            return (rhs - lhs).Magnitude;
        }

        /// <summary>
        /// Adds two vector3's together
        /// </summary>
        /// <param name="lhs">The lefthand side of the equation</param>
        /// <param name="rhs">The righthand side of the equation</param>
        /// <returns>A new vector3 containing X, Y, and Z values that were added together between two
        /// vector3's</returns>
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
        }

        /// <summary>
        /// Subtracts a vector3 from another
        /// </summary>
        /// <param name="lhs">The lefthand side of the equation</param>
        /// <param name="rhs">The righthand side of the equation</param>
        /// <returns>A new vector3 containing X, Y, and Z values that were created by subtracting each value
        /// from it's correlating value</returns>
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        }

        /// <summary>
        /// Multiplication with a scaler
        /// </summary>
        /// <param name="lhs"> The lefthand side of the equation</param>
        /// <param name="scaler"> The righthand side of the equation</param>
        /// <returns> A new vector3 who's values consist of the solutions to multiplying a vector3 to a scaler
        /// </returns>
        public static Vector3 operator *(Vector3 lhs, float scaler)
        {
            return new Vector3(lhs.X * scaler, lhs.Y * scaler, lhs.Z * scaler);
        }

        /// <summary>
        /// Division with a scaler
        /// </summary>
        /// <param name="lhs"> The lefthand side of the equation</param>
        /// <param name="scaler"> The righthand side of the equation</param>
        /// <returns> A new vector3 who's values consist of the solutions to dividing a vector3 by a scaler
        /// </returns>
        public static Vector3 operator /(Vector3 lhs, float scaler)
        {
            return new Vector3(lhs.X / scaler, lhs.Y / scaler, lhs.Z / scaler);
        }

        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            if (lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            if (lhs.X != rhs.X || lhs.Y != rhs.Y || lhs.Z != rhs.Z)
            {
                return true;
            }

            return false;
        }

        public Vector3 Normalize()
        {
            if (Magnitude == 0)
            {
                return new Vector3();
            }
            return this / Magnitude;
        }
    }
}
