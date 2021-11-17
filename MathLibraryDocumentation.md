|Katelyn West|
| :---          	|
| S218002   |
|Maths for Games|
|   MathLibrary|

## I. Requirements
1.  **Description of Problem**

        **Name**: 

        **Problem Statement**: 

        **Problem Specifications**:


2. **Input Information**

3. **Output Information**

    
4. **User Interface information**

### Collision and Chase Behavior
### Movement Behavior
### Win Behavior
### Lose Behavior

## II. Design

1. _System architecture_


2. _Object Information_

    - **Filename**: Matrix3.cs
        - **Class Name** Matrix3
            - Name: M00 (float)
            - Description:A float variable containing the refrence to the value of M00 in the Matrix3 object.
            - Visibility: public

            - Name: M01 (float)
            - Description:A float variable containing the refrence to the value of M01 in the Matrix3 object.
            - Visibility: public

            - Name: M02 (float)
            - Description:A float variable containing the refrence to the value of M02 in the Matrix3 object.
            - Visibility: public

            - Name: M10 (float)
            - Description:A float variable containing the refrence to the value of M10 in the Matrix3 object.
            - Visibility: public

            - Name: M11 (float)
            - Description:A float variable containing the refrence to the value of M11 in the Matrix3 object.
            - Visibility: public

            - Name: M12 (float)
            - Description:A float variable containing the refrence to the value of M12 in the Matrix3 object.
            - Visibility: public

            - Name: M20 (float)
            - Description:A float variable containing the refrence to the value of M20 in the Matrix3 object.
            - Visibility: public

            - Name: M21 (float)
            - Description:A float variable containing the refrence to the value of M21 in the Matrix3 object.
            - Visibility: public

            - Name: M22 (float)
            - Description:A float variable containing the refrence to the value of M22 in the Matrix3 object.
            - Visibility: public

            - Name: Matrix3()
            - Description: Base constructor for the Matrix3 class, sets all float values to their appropriate arguments
            - Visibility: public
            - Arguments: m00 (float), m01 (float), m02 (float), m10 (float), m11 (float), m12 (float), m20 (float), m21 (float), m22 (float)

            - Name: Identity (Matrix3)
            - Description: Returns a new Matrix3 with 1 set as the M00, M11, and M22 values, the rest of the values being set to 0
            - Visibility: public

            - Name: Overloaded Operator (+)
            - Description: Overloaded operator for addition specific to adding Matrix3's together
            - Visibility: public static
            - Arguments: lhs (Matrix3), rhs (Matrix3)

            - Name: Overloaded Operator (-)
            - Description: Overloaded operator for subtraction specific to adding Matrix3's together
            - Visibility: public static
            - Arguments: lhs (Matrix3), rhs (Matrix3)

            - Name: Overloaded Operator (*)
            - Description: Overloaded operator for multiplication specific to adding Matrix3's together
            - Visibility: public static
            - Arguments: lhs (Matrix3), rhs (Matrix3)

            - Name: CreateRotation()
            - Description: Creates a new matrix3 that has been rotated by the given value in radians. Sets values M00 and M11 to an int value using the Math.Cos() method while being casted into a float. Values M01 and M10 use the Math.Sin() method to get an int value which is casted as a float. M01 is positive and M10 is negative. 
            - Visibility: public static
            - Arguments: radians (float)

            - Name: CreateTranslation()
            - Description: Creates a new matrix3 that has been translated by the given values. Changes the M02 and M12 values to match the values given through the method.
            - Visibility: public static
            - Arguments: x (float), y (float)

            - Name: CreateTranslation()
            - Description: Creates a new matrix3 that has been translated by the given value. Changes the M02 and M12 values to match the x abd y values of the vector2 given through the method.
            - Visibility: public static
            - Arguments: position (Vector2)

            - Name: CreateScale()
            - Description: Creates a matrix3 that has been scaled by the given values through the method. Changes the values of M00 and M11 to match those of the values.
            - Visibility: public static
            - Arguments: x (float), y (float)
    - **Filename**: Matrix4.cs
        - **Class Name**: Matrix4
            - Name: M00 (float)
            - Description:A float variable containing the refrence to the value of M00 in the Matrix4 object.
            - Visibility: public

            - Name: M01 (float)
            - Description:A float variable containing the refrence to the value of M01 in the Matrix4 object.
            - Visibility: public

            - Name: M02 (float)
            - Description:A float variable containing the refrence to the value of M02 in the Matrix4 object.
            - Visibility: public

            - Name: M03 (float)
            - Description:A float variable containing the refrence to the value of M03 in the Matrix4 object.
            - Visibility: public

            - Name: M10 (float)
            - Description:A float variable containing the refrence to the value of M10 in the Matrix4 object.
            - Visibility: public

            - Name: M11 (float)
            - Description:A float variable containing the refrence to the value of M11 in the Matrix4 object.
            - Visibility: public

            - Name: M12 (float)
            - Description:A float variable containing the refrence to the value of M12 in the Matrix4 object.
            - Visibility: public

            - Name: M13 (float)
            - Description:A float variable containing the refrence to the value of M13 in the Matrix4 object.
            - Visibility: public

            - Name: M20 (float)
            - Description:A float variable containing the refrence to the value of M20 in the Matrix4 object.
            - Visibility: public

            - Name: M21 (float)
            - Description:A float variable containing the refrence to the value of M21 in the Matrix4 object.
            - Visibility: public

            - Name: M22 (float)
            - Description:A float variable containing the refrence to the value of M22 in the Matrix4 object.
            - Visibility: public

            - Name: M23 (float)
            - Description:A float variable containing the refrence to the value of M23 in the Matrix4 object.
            - Visibility: public

            - Name: M30 (float)
            - Description:A float variable containing the refrence to the value of M20 in the Matrix4 object.
            - Visibility: public

            - Name: M31 (float)
            - Description:A float variable containing the refrence to the value of M21 in the Matrix4 object.
            - Visibility: public

            - Name: M32 (float)
            - Description:A float variable containing the refrence to the value of M22 in the Matrix4 object.
            - Visibility: public

            - Name: M33 (float)
            - Description:A float variable containing the refrence to the value of M23 in the Matrix4 object.
            - Visibility: public

            - Name: Identity (Matrix4)
            - Description: Returns a new Matrix4 with 1 set as the M00, M11, M22, and M33 values, the rest of the values being set to 0
            - Visibility: public

            - Name: Matrix4()
            - Description: Base constructor for the Matrix3 class, sets all float values to their appropriate arguments
            - Visibility: public
            - Arguments: m00 (float), m01 (float), m02 (float), m03 (float), m10 (float), m11 (float), m12 (float), m13 (float), m20 (float), m21 (float), m22 (float), m23 (float), m30 (float), m31 (float), m32 (float), m33 (float)

            - Name: Overloaded Operator (+)
            - Description: Overloaded operator for addition specific to adding Matrix4's together
            - Visibility: public static
            - Arguments: lhs (Matrix4), rhs (Matrix4)

            - Name: Overloaded Operator (-)
            - Description: Overloaded operator for subtraction specific to adding Matrix4's together
            - Visibility: public static
            - Arguments: lhs (Matrix4), rhs (Matrix4)

            - Name: Overloaded Operator (*)
            - Description: Overloaded operator for multiplication specific to adding Matrix4's together
            - Visibility: public static
            - Arguments: lhs (Matrix4), rhs (Matrix4)

            - Name: CreateRotationX()
            - Description: Creates a new matrix4 that's x values have been rotated by the given value in radians. Sets values M11 and M22 to an int value using the Math.Cos() method while being casted into a float. Values M12 and M21 use the Math.Sin() method to get an int value which is casted as a float. M12 is negative and M21 is positive. 
            - Visibility: public static
            - Arguments: radians (float)

            - Name: CreateRotationY()
            - Description: Creates a new matrix4 that's Y values have been rotated by the given value in radians. Sets values M00 and M22 to an int value using the Math.Cos() method while being casted into a float. Values M02 and M20 use the Math.Sin() method to get an int value which is casted as a float. M02 is positive and M20 is negative. 
            - Visibility: public static
            - Arguments: radians (float)

            - Name: CreateRotationZ()
            - Description: Creates a new matrix4 that's Z values have been rotated by the given value in radians. Sets values M00 and M11 to an int value using the Math.Cos() method while being casted into a float. Values M01 and M10 use the Math.Sin() method to get an int value which is casted as a float. M01 is negative and M10 is positive. 
            - Visibility: public static
            - Arguments: radians (float)

            - Name: CreateTranslation()
            - Description: Creates a new Matrix4 thats been translated by the given value. Setting the M03, M13, and M23 values to the values passed through the method.
            - Visibility: public static
            - Arguments: x (float), y (float), z (float)

            - Name: CreateTranslation()
            - Description: Creates a new Matrix4 thats been translated by the given value. Setting the M03, M13, and M23 values to the X, Y, and Z values of the value passed through the method
            - Visibility: public static
            - Arguments: Position (Vector3)

            - Name: CreateScale()
            - Description: Creates a new Matrix4 thats been Scaled by the given value. Setting the M00, M11, and M22 values to the X, Y, and Z values of the value passed through the method
            - Visibility: public static
            - Arguments: Position (Vector3)
    - **Filename**: Vector2.cs
        - **Class Name**: Vector2
            - Name: x (float)
            - Description: A float variable that holds the x value of the Vector2 object
            - Visibility: public

            - Name: y (float)
            - Description: A float variable that holds the y value of the Vector2 object
            - Visibility: public

            - Name: Magnitude (float)
            - Description: gets the length of the vector2 by using the Math.Sqrt() method casted into a float to find the square root of X time X added to Y times Y
            - Visibility: public

            - Name: Normalized (Vector2)
            - Description: Creates a new Vector2 that is equal to this instance of a Vector2, then normalizes it and returns the output
            - Visibility: public

            - Name: Vetcor2()
            - Description: Base constructor of the Vector2 class, sets the X value to the xValue argument and the Y value to the yValue argument.
            - Visibility: xValue (float), yValue (float)

            - Name: DotProduct()
            - Description: Returns the dotproduct of the first vector2 on to the second vector2
            - Visibility: public (static)
            - Arguments: lhs (Vector2), rhs (Vector2)

            - Name: Distance()
            - Description: Finds the distance from the first vector to the second
            - Visibility: Public (static)
            - Arguments: lhs (Vector2), rhs (Vector2)

            - Name: Overloaded Operator (+)
            - Description: Returns a Vector2 that contains x and y values that are sums of two Vector2 x and Y values
            - Visibility: public static
            - Arguments: lhs (Vector2), rhs (Vector2)

            - Name: Overloaded Operator (-)
            - Description: Returns a Vector2 that contains x and y values that are differences of two Vector2 x and Y values
            - Visibility: public static
            - Arguments: lhs (Vector2), rhs (Vector2)

            - Name: Overloaded Operator (*)
            - Description: Multiplies the x and y values of a given vector by a scaler, returning new a new vector 2 with those values as the x and y coordinates
            - Visibility: public static
            - Arguments: lhs (Vector2), Scaler (float)

            - Name: Overloaded Operator (/)
            - Description: Divides the x and y values of a given vector by a scaler, returning new a new vector 2 with those values as the x and y coordinates
            - Visibility: public static
            - Arguments: lhs (Vector2), Scaler (float)

            - Name: Overloaded Operator (==)
            - Description: Checks if one Vector2 is exactly the same as the other, returns true if there are no differences spotted
            - Visibility: public static
            - Arguments: lhs (Vector2), rhs (Vetcor2)

            - Name: Overloaded Operator (!=)
            - Description: Checks if one Vector2 is not exactly the same as the other, returns true if a difference is spotted
            - Visibility: public static
            - Arguments: lhs (Vector2), rhs (Vetcor2)

            - Name: Normalize()
            - Description: Returns a vector2 containg an instance of a vector divided by the magnitude
            - Visibility: public
            - Arguments: none
    - **FileName**: Vector3.cs
        - **Class Name**: Vetcor3.cs
            - Name: x (float)
            - Description: A float variable that holds the x value of the Vector3 object
            - Visibility: public

            - Name: y (float)
            - Description: A float variable that holds the y value of the Vector3 object
            - Visibility: public

            - Name: z (float)
            - Description: A float variable that holds the z value of the Vector3 object
            - Visibility: public

            - Name: Magnitude (float)
            - Description: gets the length of the vector2 by using the Math.Sqrt() method casted into a float to find the square root of X times X added to Y times Y added to Z times Z
            - Visibility: public

            - Name: Normalized (Vector3)
            - Description: Creates a new Vector3 that is equal to this instance of a Vector3, then normalizes it and returns the output
            - Visibility: public

            - Name: Vetcor3()
            - Description: Base constructor of the Vector3 class, sets the X value to the xValue argument, the Y value to the yValue argument, and the Z value to the zValue argument.
            - Visibility: xValue (float), yValue (float), zValue (float)

            - Name: DotProduct()
            - Description: Returns the dotproduct of the first vector3 on to the second vector3
            - Visibility: public (static)
            - Arguments: lhs (Vector3), rhs (Vector3)

            - Name: Distance()
            - Description: Finds the distance from the first vector3 to the second
            - Visibility: Public (static)
            - Arguments: lhs (Vector3), rhs (Vector3)

            - Name: Overloaded Operator (+)
            - Description: Returns a Vector3 that contains x, y, and z values that are sums of two Vector3 x, y, and z values
            - Visibility: public static
            - Arguments: lhs (Vector3), rhs (Vector3)

            - Name: Overloaded Operator (-)
            - Description: Returns a Vector3 that contains x, y, and z that are differences of two Vector3 x, y, and z
            - Visibility: public static
            - Arguments: lhs (Vector3), rhs (Vector3)

            - Name: Overloaded Operator (*)
            - Description: Multiplies the x, y, and z values of a given vector by a scaler, returning new a new vector3 with those values as the x, y, and z coordinates
            - Visibility: public static
            - Arguments: lhs (Vector3), Scaler (float)

            - Name: Overloaded Operator (*)
            - Description: Multiplies the x, y, and z values of a given vector by a scaler, returning new a new vector3 with those values as the x, y, and z coordinates. In reverse order (scaler * Vector3)
            - Visibility: public static
            - Arguments: Scaler (float), rhs (Vector3)

            - Name: Overloaded Operator (*)
            - Description: Multiplication of a Matrix3 and a Vector3 using matrix multiplication
            - Visibility: public static
            - Arguments: lhs (Matrix3), rhs (Vector3)

            - Name: Overloaded Operator (/)
            - Description: Divides the x, y, and z values of a given vector by a scaler, returning new a new vector3 with those values as the x, y, and z coordinates
            - Visibility: public static
            - Arguments: lhs (Vector3), Scaler (float)

            - Name: Overloaded Operator (==)
            - Description: Checks if one Vector3 is exactly the same as the other, returns true if there are no differences spotted
            - Visibility: public static
            - Arguments: lhs (Vector3), rhs (Vetcor3)

            - Name: Overloaded Operator (!=)
            - Description: Checks if one Vector3 is not exactly the same as the other, returns true if a difference is spotted
            - Visibility: public static
            - Arguments: lhs (Vector3), rhs (Vetcor3)

            - Name: Normalize()
            - Description: Returns a vector3 containg an instance of a vector divided by the magnitude
            - Visibility: public
            - Arguments: none

            - Name: CrossProduct()
            - Description: Returns a vector3 containg an instance of a vector divided by the magnitude
            - Visibility: public
            - Arguments: none
    - **FileName** Vector4.cs
        - **Class Name**: Vector4
            - Name: x (float)
            - Description: A float variable that holds the x value of the Vector3 object
            - Visibility: public

            - Name: y (float)
            - Description: A float variable that holds the y value of the Vector3 object
            - Visibility: public

            - Name: z (float)
            - Description: A float variable that holds the z value of the Vector3 object
            - Visibility: public

            - Name: w (float)
            - Description: A float variable that holds the z value of the Vector3 object
            - Visibility: public

            - Name: Magnitude (float)
            - Description: gets the length of the vector2 by using the Math.Sqrt() method casted into a float to find the square root of X times X added to Y times Y added to Z times Z added to W times W
            - Visibility: public

            - Name: Normalized (Vector4)
            - Description: Creates a new Vector4 that is equal to this instance of a Vector4, then normalizes it and returns the output
            - Visibility: public

            - Name: Vetcor4()
            - Description: Base constructor of the Vector3 class, sets the X value to the x argument, the Y value to the y argument, the Z value to the z argument, and the W value to the w argument.
            - Visibility: x (float), y (float), z (float), w (float)

            - Name: Overloaded Operator (+)
            - Description: Returns a Vector4 that contains x, y, z, and w values that are sums of two Vector3 x, y, z, and w values
            - Visibility: public static
            - Arguments: lhs (Vector4), rhs (Vector4)

            - Name: Overloaded Operator (-)
            - Description: Returns a Vector4 that contains x, y, z, and w that are differences of two Vector3 x, y, z, and w
            - Visibility: public static
            - Arguments: lhs (Vector4), rhs (Vector4)

            - Name: Overloaded Operator (*)
            - Description: Multiplies the x, y, z, and w values of a given vector by a scaler, returning new a new vector4 with those values as the x, y, z, and w coordinates
            - Visibility: public static
            - Arguments: lhs (Vector4), Scaler (float)

            - Name: Overloaded Operator (*)
            - Description: Multiplies the x, y, z, and w values of a given vector by a scaler, returning new a new vector4 with those values as the x, y, z, and w coordinates. In reverse order (scaler * Vector4)
            - Visibility: public static
            - Arguments: Scaler (float), rhs (Vector4)

            - Name: Overloaded Operator (*)
            - Description: Multiplication of a Matrix4 and a Vector4 using matrix multiplication
            - Visibility: public static
            - Arguments: lhs (Matrix4), rhs (Vector4)

            - Name: Overloaded Operator (/)
            - Description: Divides the x, y, and z values of a given vector by a scaler, returning new a new vector4 with those values as the x, y, and z coordinates
            - Visibility: public static
            - Arguments: lhs (Vector4), Scaler (float)

            - Name: DotProduct()
            - Description: Returns the dotproduct of the first vector4 on to the second vector2
            - Visibility: public (static)
            - Arguments: lhs (Vector4), rhs (Vector4)

            - Name: Distance()
            - Description: Finds the distance from the first vector4 to the second
            - Visibility: Public (static)
            - Arguments: lhs (Vector4), rhs (Vector4)

            - Name: Normalize()
            - Description: Returns a vector4 containg an instance of a vector divided by the magnitude
            - Visibility: public
            - Arguments: none

            

            


            



            
