using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public struct Matrix3
    {
        public float M00, M01, M02, M10, M11, M12, M20, M21, M22;

        public Matrix3(float m00, float m01, float m02, //x-axis
                       float m10, float m11, float m12, //y-axis
                       float m20, float m21, float m22) //z-axis
        {
            M00 = m00;
            M01 = m01;
            M02 = m02;
            M10 = m10;
            M11 = m11;
            M12 = m12;
            M20 = m20;
            M21 = m21;
            M22 = m22;

        }

        public static Matrix3 Identity
        {
            get 
            {
                return new Matrix3(1, 0, 0,
                                   0, 1, 0,
                                   0, 0, 1);
            }
        }

        public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
        {
            //Add the rhs values to the lhs values and create new floats to contain these values
            float m00 = lhs.M00 + rhs.M00;
            float m01 = lhs.M01 + rhs.M01;
            float m02 = lhs.M02 + rhs.M02;
            float m10 = lhs.M10 + rhs.M10;
            float m11 = lhs.M11 + rhs.M11;
            float m12 = lhs.M12 + rhs.M12;
            float m20 = lhs.M20 + rhs.M20;
            float m21 = lhs.M21 + rhs.M21;
            float m22 = lhs.M22 + rhs.M22;

            //Create a new matrix3 containing these values
            Matrix3 AddedMatrix = new Matrix3(m00, m01, m02, 
                                              m10, m11, m12, 
                                              m20, m21, m22);

            //Return new matrix3
            return AddedMatrix;
        }

        public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
        {
            //Subtract the rhs variables from the lhs variables and place them into new float variables
            float m00 = lhs.M00 - rhs.M00;
            float m01 = lhs.M01 - rhs.M01;
            float m02 = lhs.M02 - rhs.M02;
            float m10 = lhs.M10 - rhs.M10;
            float m11 = lhs.M11 - rhs.M11;
            float m12 = lhs.M12 - rhs.M12;
            float m20 = lhs.M20 - rhs.M20;
            float m21 = lhs.M21 - rhs.M21;
            float m22 = lhs.M22 - rhs.M22;

            //Create a new matrix3 containing these new values
            Matrix3 SubtractedMatrix = new Matrix3(m00, m01, m02, 
                                                   m10, m11, m12, 
                                                   m20, m21, m22);

            //Return new matrix3
            return SubtractedMatrix;
        }

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            //Row 1
            float m00 = (lhs.M00 * rhs.M00) + (lhs.M01 * rhs.M10) + (lhs.M02 * rhs.M20); //Column1
            float m01 = (lhs.M00 * rhs.M01) + (lhs.M01 * rhs.M11) + (lhs.M02 * rhs.M21); //Column2
            float m02 = (lhs.M00 * rhs.M02) + (lhs.M01 * rhs.M12) + (lhs.M02 * rhs.M22); //Column3

            //Row2
            float m10 = (lhs.M10 * rhs.M00) + (lhs.M11 * rhs.M10) + (lhs.M12 * rhs.M20); //Column1
            float m11 = (lhs.M10 * rhs.M01) + (lhs.M11 * rhs.M11) + (lhs.M12 * rhs.M21); //Column2
            float m12 = (lhs.M10 * rhs.M02) + (lhs.M11 * rhs.M12) + (lhs.M12 * rhs.M22); //Column3

            //Row3
            float m20 = (lhs.M20 * rhs.M00) + (lhs.M21 * rhs.M10) + (lhs.M22 * rhs.M20); //Column1
            float m21 = (lhs.M20 * rhs.M01) + (lhs.M21 * rhs.M11) + (lhs.M22 * rhs.M21); //Column2
            float m22 = (lhs.M20 * rhs.M02) + (lhs.M21 * rhs.M12) + (lhs.M22 * rhs.M22); //Column3

            Matrix3 MultipliedMatrix = new Matrix3(m00, m01, m02, 
                                                   m10, m11, m12, 
                                                   m20, m21, m22);

            return MultipliedMatrix;
        }

        /// <summary>
        /// Creates a new matrix that has been rotated by the given value in radians
        /// </summary>
        /// <param name="radians">The result of the rotation</param>
        public static Matrix3 CreateRotation(float radians)
        {
            Matrix3 RotatedMatrix3 = new Matrix3((float)Math.Cos(radians), (float)Math.Sin(radians), Identity.M02,
                                                 -(float)Math.Sin(radians), (float)Math.Cos(radians), Identity.M12,
                                                 Identity.M20, Identity.M21, Identity.M22);
            return RotatedMatrix3;
        }

        /// <summary>
        /// Creates a new matrix that has been translated by the given value
        /// </summary>
        /// <param name="x">The x position of the new matrix</param>
        /// <param name="y">The y position of the new matrix</param>
        public static Matrix3 CreateTranslation(float x, float y)
        {
            Matrix3 TranslatedMatrix3 = new Matrix3(Identity.M00, Identity.M01, x,
                                                    Identity.M10, Identity.M11, y,
                                                    Identity.M20, Identity.M21, Identity.M22);
            return TranslatedMatrix3;
        }

        /// <summary>
        /// Creates a new matrix that has been scaled by the given value
        /// </summary>
        /// <param name="x">The value to use to scale the matrix in the x axis</param>
        /// <param name="y">The value to use to scale the matrix in the y axis</param>
        /// <returns>The result of the scale</returns>
        public static Matrix3 CreateScale(float x, float y)
        {
            Matrix3 ScaledMatrix3 = new Matrix3(x, Identity.M01, Identity.M02,
                                                Identity.M10, y, Identity.M12,
                                                Identity.M20, Identity.M21, Identity.M22);
            return ScaledMatrix3;
        }
    }
}
