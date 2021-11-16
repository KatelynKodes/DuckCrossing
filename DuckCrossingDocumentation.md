|Katelyn West|
| :---          	|
| S218002   |
|Maths for Games|
|   Graphical Test Application|

## I. Requirements
1.  **Description of Problem**

        **Name**: Graphical Test Application

        **Problem Statement**: 

        Creation of a test application that makes use of my Maths classes.

        **Problem Specifications**:
        -   Impliments an example of Matrix Heirarchy to manipulate visible elements.
        -   Impliments an example of Gameobjects using velocity and acceleration with vectors
        -   Example of collision detection


2. **Input Information**

    'W' - Allows the player to move upwards on the Y-Axis when trying to move their character.

    'A' - Allows the player to move downwards on the Y-Axis when trying to move their character.

    'S' - Allows the player to move to the right on the X-Axis when trying to move their character.

    'D' - Allows the player to move to the left on the X-Axis when trying to move their character.

    'Left-Shift' - Allows the player to increase their speed, giving the illusion of running.
3. **Output Information**

    - The program displays a graphical interpretation of the inputs by displaying the players character moving towards a specified location, giving the illusion of movement.
    
4. **User Interface information**

    - UI displays instructions as a renminder of how to play and it also displays how many children the Player Gameobject contains, indicating the amount of chicks the player has already collected.
### Collision and Chase Behavior
### Movement Behavior
### Win Behavior
## Lose Behavior

## II. Design

1. _System architecture_

    Every object in every scene derives from an Actor class, placed into an Actor array and placed inside the an instance if the Scene class itself, rather than having more than one scene in the engine class alone. 

2. _Object Information_ 

    - **Filename**: AABBCollider.cs
        - **Class Name**: AABBCollider : Collider
             - Name: _width (float)
             - Description: A variable containing the width of the collider box
             - Visibility: private.
             
             - Name: _height (float)
             - Description: A variable containing the height of the collider box
             - Visibility: private 

             - Name: Width (float)
             - Description: A property that allows any class to read and set the _width variable.
             - Visibility: public

             - Name: Height (float)
             - Description: A property that allows any class to read and set the _height variable.
             - Visibility: public

             - Name: Left (float)
             - Description: A property that gets the collider's left value by dividing _width by 2 and subtracting from the owner of the collider's x-position
             - Visibility: public

             - Name: Right (float)
             - Description: A property that gets the collider's right value by dividing _width by 2 and adding from the owner of the collider's x-position
             - Visibility: Public

             - Name: Top (float)
             - Description: A property that gets the collider's top value by dividing _height by 2 and subtracting from the owner of the collider's y-position
             - Visibility: Public

             - Name: Bottom (float)
             - Description: A property that gets the collider's bottom value by dividing _height by 2 and adding from the owner of the collider's y-position
             - Visibility: Public

             - Name: AABBCollider() : base()
             - Description: The constructor for the AABBCollider class, also fills values for the base Collider Class constructor.
             - Visibility: Public
             - Arguments: width(float), hieght(float), owner(Actor)

             - Name: Draw()
             - Description: Draws the AABB collider to the Raylib window using Raylib.DrawRectangleLines() making it visible to the user interface. 
             - Visibility: Public
             - Arguments: None

             - Name: CheckCollisionCircle
             - Description: Calls the CheckCollisionAABB method from the circlecollider passed into the method.
             - Visibility: Public (override)
             - Arguments: other (CircleCollider)

             - Name: CheckCollisionAABB()
             - Description: Checks for a collision with another AABBCollider object by checking if the object is not itself. Then checks if the other colliders Left is less than or equal to the colliders Right, The other colliders Top is less than or equal to the collider's Bottom, The colliders left is less than or equal to the other collider's Right, and the collider's Top is less than or equal to the other colliders bottom.
             - Visibility: public
             - Arguments: other(AABBCollider)
    - **Filename**: Actor.cs
        - **Class Name**: Actor
            - Name: _name (string)
             - Description: A variable that holds the name of the actor object.
             - Visibility: private.

             - Name: _started (bool)
             - Description: A variable that holds whether the Actor object has started or not.
             - Visibility: private

             - Name: _sprite (sprite)
             - Description: A bool that contains a sprite object that contains a string, representing the path to the image being used as an image to represent the actor object onscreen
             - Visibility: private

             - Name: _collider (Collider)
             - Description: A variable holding a collider that can be used to detect an actors collision with another actor.
             - Visibility: private

             - Name: _localTransform (Matrix3)
             - Description: A variable that holds the matrix3 object containing the transform of the Actor object in regards to it's local position. 
             - Visibility: private

             - Name: _globalTransform (Matrix3) 
             - Description: A variable that olds the Matrix3 object containing the transform of the actor object in regards to it's relation to the world
             - Visibility: private

             - Name: _translate (Matrix3)
             - Description: A variable that contains the matrix3 value representing the Actors translation (position) in the world.
             - Visibility: private

             - Name: _rotation (Matrix3)
             - Description: A variable containing the matrix3 value representing the Actor's rotation in the world.
             - Visibility: private

             - Name: _scale (Matrix3)
             - Description: A variable that contains the matrix3 value representing the Actors scale in the world.
             - Visibility: private

             - Name: _children (Actor[])
             - Description: Contains an array of actors that are children of the parent
             - Visibility: private

             - Name: _parent (Actor)
             - Description: An actor variable contaning the parent of the actor, if the actor has a parent. Will otherwise return null.
             - Visibility: private

             - Name: Started (bool)
             - Description: A property that returns the _started variable.
             - Visibility: public

             - Name: LocalPosition (Vector2)
             - Description: A property that returns a new Vector2 containing _translate.M02 for the x and _translate.M12 for the y. sets the value to SetTranslation(value.x, value.y).
             - Visibility: public

             - Name: WorldPosition (Vetcor2)
             - Description: A property that returns a new Vector2 with _globaltransform.M02 as the x and _globaltransform.M12 as the y. If the _parent of the actor isn't null, it returns a new vector2 containing value.X subtracted by _parent.LocalTransform.M02 divided by _parent._scale.M00 and value.y subtracted by _parent.LocalTransform.M12 divided by _parent._scale.M11. If there is no parent, the local position is set to value. 
             - Visibility: public

             - Name: LocalTransform (Matrix3)
             - Description: A property that returns the _localTransform variable and privately sets _localTransform variable to value.
             - Visibility: Public

             - Name: GlobalTransform (Matrix3)
             - Description: A property that returns the _globalTransform variable and privately sets the _globalTransform to value
             - Visibility: Public

             - Name: Parent (Actor)
             - Description:  A property that returns the _parent variable and sets the _parent variable to value
             - Visibility: public

             - Name: Children (Actor[])
             - Description:  A property that returns the _children variable
             - Visibility: public

             - Name: Size (Vector2)
             - Description:  A property that returns a new vector2 of a float called xScale that contains the magnitude of a vector2 with _scale.M00 and _scale.M10 as the x, and a float called yScale that contains the magnitude of a vector2 with _scale.M01 and _scale.M11 as the y. The property also sets using the method SetScale(value.x, value.y)
             - Visibility: public

             - Name: Sprite (Sprite)
             - Description: A property that returns and sets the value of _sprite
             - Visibility: public

             - Name: Name (string)
             - Description:  A property that returns the _name variable.
             - Visibility: public

             - Name: Collider (Collider)
             - Description:  A property that returns and sets the value of _collider
             - Visibility: public

             - Name: Forward (Vector2)
             - Description: A property that returns a new Vector2 containing the _rotation.M00 as the x and _rotation.M10 as the y. is set by creating a new Vector2 called point that is equal to value.Normalized + LocalPosition and calls the LookAt method passing in the point variable.
             - Visibility: public

             - Name: Actor() : this()
             - Description: Constructor for the actor class, calling the base constructor as well
             - Visibility: public
             - Arguments: x (float), y (float), name (string), path (string)

             - Name: Actor()
             - Description: Base constructor for actor class. Sets LocalPosition to position, _name to name, and if the path argument is not empty sets _sprite to a new Sprite object containing path.
             - Visibility: public
             - Arguments: position (Vector2), name (string), path (string)

             - Name: Start()
             - Description: Sets the _started variable to true when called
             - Visibility: public
             - Arguments: None

             - Name: Update()
             - Description: Calls the UpdateTransforms() method when called.
             - Visibility: public (virtual)
             - Arguments: deltaTime (float)

             - Name: Draw()
             - Description: if the _sprite variable is not null, calls the Draw() method from the _sprite variable.  
             - Visibility: Public (virtual)
             - Arguments: None

             - Name: End()
             - Description: Empty method  
             - Visibility: public
             - Arguments: none

             - Name: UpdateTransforms()
             - Description: Updates both the local and global transforms of the actor. The GlobalTransform is equal to the LocalTransform as long as the Parent variable is null, otherwise it's equal to the Parent._globalTransform times the _localTransform variable. 
             - Visibility: public 
             - Arguments: none

             - Name: AddChild()
             - Description: Adds an Actor object to the Children array by creating a temporary Actor array that is 1 space longer than the Children array. Filling the temporary array up with the Children array values then setting the null variable at the end of the array to the child passed through the method. Then the _children array is set to the temporary array.
             - Visibility: public
             - Arguments: childToAdd (Actor)

             - Name: RemoveChildren()
             - Description: Removes an Actor object from the Children array by creating a temporary Actor array that is 1 space shorter than the Children array. Filling the temporary array up with the Children array values as long as the Actor in the array is not equal to the Actor the method is trying to remove. Then a bool called childRemoved returns true if the Actor in the Children array is equal to the Actor the array is trying to remove, the _children array is set to the temporary array and the childToRemove.Parent is set to null.
             - Visibility: public
             - Arguments: childToRemove (Actor)

             - Name: CheckForCollision() 
             - Description: Checks if the Collider of either actor is null before returning false if true, then returning the Collider.CheckCollider() method.
             - Visibility: public (virtual)
             - Arguments: other (Actor other)

             - Name: OnCollision()
             - Description: An empty method, used to preform an action when one actor collides with another.
             - Visibility: Public (virtual)
             - Arguments: actor (Actor)

             - Name: SetScale()
             - Description: Sets the scale of the actor by setting the _scale value to the output of Matrix3.CreateScale() method.
             - Visibility: public
             - Arguments: x (float), y (float)

             - Name: Scale()
             - Description: Sets the scale of the actor by multiplying the _scale value to the output of Matrix3.CreateScale() method.
             - Visibility: public
             - Arguments: x (float), y (float)

             - Name: SetTranslation()
             - Description: Sets the translation of the actor by setting the _translate value to the output of Matrix3.CreateTranslation() method.
             - Visibility: public
             - Arguments: Translationx (float), Translationy (float)

             - Name: Translate()
             - Description: Sets the translation of the actor by multiplying the _translate value to the output of Matrix3.CreateTranslation() method.
             - Visibility: public
             - Arguments: Translationx (float), Translationy (float)

             - Name: SetRotation()
             - Description: Sets the rotation of the actor by setting the _rotation value to the output of Matrix3.CreateRotation() method.
             - Visibility: public
             - Arguments: radians (float)

             - Name: Rotate()
             - Description: Sets the rotation of the actor by multiplying the _rotation value to the output of Matrix3.CreateRotation() method.
             - Visibility: public
             - Arguments: radians (float)

             - Name: LookAt()
             - Description: Finds the direction the actor should look in, uses dotProduct to find the angle the actor needs to rotate towards, finds a perpendicular vector to the distance, and finds the dotProduct of the perpendicular vector and the current forward. I the result isn't 0, change the sign of the angle to either positive or negative, then rotate according to the angle variable. 
             - Visibility: public
             - Arguments: Position (Vector2)

             - Name: ContainsChild()
             - Description: Returns a bool of childFound, iterates through the _children array and childFound is set to true if the Actor in _children is equal to the child passed through the method.
             - Visibility: public
             - Arguments: child (Actor)

             