using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public struct Matrix4
    {
        public float M00, M01, M02, M03, M10, M11, M12, M13, M20, M21, M22, M23, M30, M31, M32, M33;

        public static Matrix4 Identity
        {
            get
            {
                return new Matrix4(1, 0, 0, 0,
                                   0, 1, 0, 0,
                                   0, 0, 1, 0,
                                   0, 0, 0, 1);
            }
        }

        public Matrix4(float m00, float m01, float m02, float m03,
                       float m10, float m11, float m12, float m13,
                       float m20, float m21, float m22, float m23,
                       float m30, float m31, float m32, float m33)
        {
            M00 = m00; M01 = m01; M02 = m02; M03 = m03;
            M10 = m10; M11 = m11; M12 = m12; M13 = m13;
            M20 = m20; M21 = m21; M22 = m22; M23 = m23;
            M30 = m30; M31 = m31; M32 = m32; M33 = m33;
        }

        public static Matrix4 operator +(Matrix4 lhs, Matrix4 rhs)
        {
            //Row 1
            float _m00 = lhs.M00 + rhs.M00;
            float _m01 = lhs.M01 + rhs.M01;
            float _m02 = lhs.M02 + rhs.M02;
            float _m03 = lhs.M03 + rhs.M03;

            //Row 2
            float _m10 = lhs.M10 + rhs.M10;
            float _m11 = lhs.M11 + rhs.M11;
            float _m12 = lhs.M12 + rhs.M12;
            float _m13 = lhs.M13 + rhs.M13;

            //Row 3
            float _m20 = lhs.M20 + rhs.M20;
            float _m21 = lhs.M21 + rhs.M21;
            float _m22 = lhs.M22 + rhs.M22;
            float _m23 = lhs.M23 + rhs.M23;

            //Row 4
            float _m30 = lhs.M20 + rhs.M20;
            float _m31 = lhs.M21 + rhs.M21;
            float _m32 = lhs.M22 + rhs.M22;
            float _m33 = lhs.M23 + rhs.M23;

            return new Matrix4(_m00, _m01, _m02, _m03,
                               _m10, _m11, _m12, _m13,
                               _m20, _m21, _m22, _m23,
                               _m30, _m31, _m32, _m33);
        }

        public static Matrix4 operator -(Matrix4 lhs, Matrix4 rhs)
        {
            //Row 1
            float _m00 = lhs.M00 - rhs.M00;
            float _m01 = lhs.M01 - rhs.M01;
            float _m02 = lhs.M02 - rhs.M02;
            float _m03 = lhs.M03 - rhs.M03;

            //Row 2
            float _m10 = lhs.M10 - rhs.M10;
            float _m11 = lhs.M11 - rhs.M11;
            float _m12 = lhs.M12 - rhs.M12;
            float _m13 = lhs.M13 - rhs.M13;

            //Row 3
            float _m20 = lhs.M20 - rhs.M20;
            float _m21 = lhs.M21 - rhs.M21;
            float _m22 = lhs.M22 - rhs.M22;
            float _m23 = lhs.M23 - rhs.M23;

            //Row 4
            float _m30 = lhs.M20 - rhs.M20;
            float _m31 = lhs.M21 - rhs.M21;
            float _m32 = lhs.M22 - rhs.M22;
            float _m33 = lhs.M23 - rhs.M23;

            return new Matrix4(_m00, _m01, _m02, _m03,
                               _m10, _m11, _m12, _m13,
                               _m20, _m21, _m22, _m23,
                               _m30, _m31, _m32, _m33);
        }

        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            //Row 1
            float m00 = (lhs.M00 * rhs.M00) + (lhs.M01 * rhs.M10) + (lhs.M02 * rhs.M20) + (lhs.M03 * rhs.M30); //Column1
            float m01 = (lhs.M00 * rhs.M01) + (lhs.M01 * rhs.M11) + (lhs.M02 * rhs.M21) + (lhs.M03 * rhs.M31); //Column2
            float m02 = (lhs.M00 * rhs.M02) + (lhs.M01 * rhs.M12) + (lhs.M02 * rhs.M22) + (lhs.M03 * rhs.M32); //Column3
            float m03 = (lhs.M00 * rhs.M03) + (lhs.M01 * rhs.M13) + (lhs.M02 * rhs.M23) + (lhs.M03 * rhs.M33); //Column4

            //Row2
            float m10 = (lhs.M10 * rhs.M00) + (lhs.M11 * rhs.M10) + (lhs.M12 * rhs.M20) + (lhs.M13 * rhs.M30); //Column1
            float m11 = (lhs.M10 * rhs.M01) + (lhs.M11 * rhs.M11) + (lhs.M12 * rhs.M21) + (lhs.M13 * rhs.M31); //Column2
            float m12 = (lhs.M10 * rhs.M02) + (lhs.M11 * rhs.M12) + (lhs.M12 * rhs.M22) + (lhs.M13 * rhs.M32); //Column3
            float m13 = (lhs.M10 * rhs.M03) + (lhs.M11 * rhs.M13) + (lhs.M12 * rhs.M23) + (lhs.M13 * rhs.M33); //Column4

            //Row3
            float m20 = (lhs.M20 * rhs.M00) + (lhs.M21 * rhs.M10) + (lhs.M22 * rhs.M20) + (lhs.M23 * rhs.M30); //Column1
            float m21 = (lhs.M20 * rhs.M01) + (lhs.M21 * rhs.M11) + (lhs.M22 * rhs.M21) + (lhs.M23 * rhs.M31); //Column2
            float m22 = (lhs.M20 * rhs.M02) + (lhs.M21 * rhs.M12) + (lhs.M22 * rhs.M22) + (lhs.M23 * rhs.M32); //Column3
            float m23 = (lhs.M20 * rhs.M03) + (lhs.M21 * rhs.M13) + (lhs.M22 * rhs.M23) + (lhs.M23 * rhs.M33); //Column4

            //Row4
            float m30 = (lhs.M30 * rhs.M00) + (lhs.M31 * rhs.M10) + (lhs.M32 * rhs.M20) + (lhs.M33 * rhs.M30); //Column1
            float m31 = (lhs.M30 * rhs.M01) + (lhs.M31 * rhs.M11) + (lhs.M32 * rhs.M21) + (lhs.M33 * rhs.M31); //Column2
            float m32 = (lhs.M30 * rhs.M02) + (lhs.M31 * rhs.M12) + (lhs.M32 * rhs.M22) + (lhs.M33 * rhs.M32); //Column3
            float m33 = (lhs.M30 * rhs.M03) + (lhs.M31 * rhs.M13) + (lhs.M32 * rhs.M23) + (lhs.M33 * rhs.M33); //Column4

            return new Matrix4(m00, m01, m02, m03,
                               m10, m11, m12, m13,
                               m20, m21, m22, m23,
                               m30, m31, m32, m33);
        }

        public static Matrix4 CreateRotationX(float radians)
        {
            return new Matrix4(Identity.M00, Identity.M01, Identity.M02, Identity.M03,
                               Identity.M10, (float)Math.Cos(radians), -(float)Math.Sin(radians), Identity.M13,
                               Identity.M20, (float)Math.Sin(radians), (float)Math.Cos(radians), Identity.M23,
                               Identity.M30, Identity.M31, Identity.M32, Identity.M33);
        }

        public static Matrix4 CreateRotationY(float radians)
        {
            return new Matrix4((float)Math.Cos(radians), Identity.M01, (float)Math.Sin(radians), Identity.M03,
                                Identity.M10, Identity.M11, Identity.M12, Identity.M13,
                                -(float)Math.Sin(radians), Identity.M21, (float)Math.Cos(radians), Identity.M23,
                                Identity.M30, Identity.M31, Identity.M32, Identity.M33);
        }

        public static Matrix4 CreateRotationZ(float radians)
        {
            return new Matrix4((float)Math.Cos(radians), -(float)Math.Sin(radians), Identity.M02, Identity.M03,
                               (float)Math.Sin(radians), (float)Math.Cos(radians), Identity.M12, Identity.M13,
                               Identity.M20, Identity.M21, Identity.M22, Identity.M23,
                               Identity.M30, Identity.M31, Identity.M32, Identity.M33);
        }

        public static Matrix4 CreateTranslation(float x, float y, float z)
        {
            return new Matrix4(Identity.M00, Identity.M01, Identity.M02, x,
                               Identity.M10, Identity.M11, Identity.M12, y,
                               Identity.M20, Identity.M21, Identity.M22, z,
                               Identity.M30, Identity.M31, Identity.M32, Identity.M33);
        }

        public static Matrix4 CreateTranslation(Vector3 Position)
        {
            return new Matrix4(Identity.M00, Identity.M01, Identity.M02, Position.X,
                               Identity.M10, Identity.M11, Identity.M12, Position.Y,
                               Identity.M20, Identity.M21, Identity.M22, Position.Z,
                               Identity.M30, Identity.M31, Identity.M32, Identity.M33);
        }

        public static Matrix4 CreateScale(Vector3 Scale)
        {
            return new Matrix4(Scale.X, Identity.M01, Identity.M02, Identity.M03,
                               Identity.M10, Scale.Y, Identity.M12, Identity.M13,
                               Identity.M20, Identity.M21, Scale.Z, Identity.M23,
                               Identity.M30, Identity.M31, Identity.M32, Identity.M33);
        }
    }
}
