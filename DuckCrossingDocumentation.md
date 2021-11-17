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
### Lose Behavior

## II. Design

1. _System architecture_

    The game is divided up into objects known as Scenes, these scenes are where parts of the game take place. This includes title screens, certain points in gameplay, or screens that show the user whether they won or lost the game. Every object in every scene derives from an Actor class, placed into an Actor array and placed inside the an instance if the Scene class itself. Actors may derive from children of the Actor class, which are specific subclasses that have distinct differences to one another and don't behave in the same way. Collider objects, also inherit from one parent class, the Collider class. There are two types of colliders, CircleColliders and AABB Colliders (also known as Box-Colliders), this was done to give a bit of variety to the types of colliders an object can have as well as fit certain object shapes if needed. The reason there are so many classes and children of some classes in this program is to attempt to make building a bigger program easier for the developer and make it so where the Engine class is only responsible for handling engine related activities, such as changing scenes when need be and checking win/lose conditions every time the game updates.

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
    - **Filename**: Car.cs
        - **Class Name**: Car : Actor
            - Name: _speed (float)
            - Description: a float variable containing the speed variable of the car.   
            - Visibility: private

            - Name: _startPosition (Vector2)
            - Description: A vector2 variable containing the start position of the car.
            - Visibility: private

            - Name:_frequency (float)
            - Description: A float variable containing the frequency of the cars movement 
            - Visibility: private

            - Name: _offset (float)
            - Description: A float variable containing the offset of the car
            - Visibility: private

            - Name: _magnitude (float)
            - Description: A float variable containing the magnitude of the car movement.
            - Visibility: private

            - Name: _val (float)
            - Description: A float variable containing a variable that should be increased by deltaTime every time the car moves
            - Visibility: private

            - Name: Speed (float)
            - Description: A property that returns and sets the value of _speed.
            - Visibility: Public

            - Name: Car() : base()
            - Description: Base constructor of the Car class    
            - Visibility: Public
            - Arguments: x (float), y (float), speed (string), path (string)

            - Name: Update()
            - Description: Takes the LocalPosition of the car and sets it to the _startposition plus a Vector2 that has a 30 in the y position, multiplied by the Sin of the value of _val being added to by DeltaTime then multiplied by the _frequency variable added to the _offset variable. This is then multiplied by the _magnitude and _speed variables. This causes the car objects to hover in a vertical motion upwards and downwards.    
            - Visibility: Public (override)
            - Arguments: DeltaTime (float)

            - Name: Draw()
            - Description: Draws the car to the screen, calls the base.Draw() method and the Collider().Draw() method. 
            - Visibility: Public (override)
            - Arguments: none
    - **Filename**: CircleCollider.cs
        - **Class Name**: CircleCollider : Collider
            - Name: _collisionRadius (float)
            - Description: A float variable containing the collision radius of the circle collider.
            - Visibility: private

            - Name: CollisionRadius (float)
            - Description: Gets and sets the value of the _collisionRadius variable
            - Visibility: Public

            - Name: CircleCollider() : base()
            - Description: base constructor, setting _collisionRadius to collisionRadius
            - Visibility: Public
            - Arguments: collisionRadius (float), owner (Actor)

            - Name: Draw()
            - Description: calls the base Draw() method and draws circle lines to the raylib window representing the circle collider, allowing the collider to be visible on the user interface.  
            - Visibility: Public 
            - Arguments: none

            - Name: CheckCollisionCircle()
            - Description: Checks if the collider is colliding to another circle collider by first checking to make sure the collider passed into the method isn't it's own collider and returns true if the distance between the two circle colliders is less than or equal to the combined radii of the two circle colliders. 
            - Visibility: Public (override)
            - Arguments: other (CircleCollider)

            - Name: CheckCollisionAABB()
            - Description: Checks if there is a collision between a circle collider and a AABB collider by first checking if the collider passed into the method isn't itself then getting the direction from the circlecollider to the AABB collider. Then clamp the direction vector to be within the bounds of the AABB collider. The closest point is then determined by adding the direction vector to the AABB center, then uses Vector.Distance() method to track the distance from the closest point. returns true if the distance from closest point is less than or equal to the collision radius
            - Visibility: Public (override)
            - Arguments: other (AABBCollider)
    - **Filename**: Collectable.cs
        - **Class Name**: Collectable : Actor
            - Name: _speed (float)
            - Description: A float variabe containing the speed of the collectable.
            - Visibility: private

            - Name: _velocity (Vector2)
            - Description: A vector2 variable containing the velocity of the collectable
            - Visibility: private

            - Name: Speed (float)
            - Description: A property variable that gets and sets the value of the _speed variable
            - Visibility: Public

            - Name: Velocity (Vector2)
            - Description: A property variable that gets and sets the value of the _velocity variable
            - Visibility: Public

            - Name: Update()
            - Description: If the collectable has a parent, and that parent is a Player object, the collectable follows the player
            - Visibility: Public (override)
            - Arguments: deltaTime (float)

            - Name: Draw()
            - Description: Draws the collectable to the Raylib window, making it visible to the user. Calls the base and the Collider's Draw() method.
            - Visibility: Public (override)
            - Arguments: none
    - **FileName**: Collider.cs
        - Name: ColliderType (enum)
        - Description: Contains the types of shapes a collider can be, holds values of CIRCLE and AABB
        - Visibility: private

        - **Class Name**: Collider
            - Name: _owner (Actor)
            - Description: A variable that contains an Actor object, considered to be the owner of the collider.
            - Visibility: private

            - Name: _colliderType (ColliderType)
            - Description: A variable containing a value from the ColliderType enum, represents the collider type of the collider.
            - Visibility: private

            - Name: Owner (Actor)
            - Description: A property that returns and sets the value of the _owner variable.
            - Visibility: public

            - Name: ColliderType (ColliderType Enum)
            - Description: A property that returns the value of the _colliderType value.
            - Visibility: public

            - Name: Collider()
            - Description: Base constructor for the collider class, sets _owner variable to the owner argument and the _colliderType variable to the colliderType argument.
            - Visibility: public
            - Arguments: owner (Actor), colliderType (ColliderType Enum)

            - Name: Draw()
            - Description: Empty virtual method used in child classes
            - Visibility: public (virtual)
            - Arguments: none

            - Name: CheckCollider()
            - Description: Checks whether the actors collider is either a Circle or an AABB collider. Then calls appropriate method, returning the bool output it returns.
            - Visibility: public
            - Arguments: other (Actor)

            - Name: CheckCollisionCircle()
            - Description: An empty virtual void method only used in child classes
            - Visibility: Public (virtual)
            - Arguments: other (CircleCollider)

            - Name: CheckCollisionAABB()
            - Description: An empty virtual void method only used in child classes
            - Visibility: Public (virtual)
            - Arguments: other (AABBCollider)
    - **FileName**: Engine.cs
        - **Class Name** Engine
            - Name: _applicationShouldClose (bool)
            - Description: A boolean variable referencing when it is okay for the program to close the application
            - Visibility: private (static)

            - Name: _currentSceneIndex (int)
            - Description: An integer variable containing the current index in the scene array.
            - Visibility: private (static)

            - Name: _Scenes (Scene[])
            - Description: An array containing scene objects
            - Visibility: private (static)

            - Name: _stopwatch (Stopwatch)
            - Description: A variable containing a Stopwatch, a System.Diagnostics variable type that provides a set of methods and properties that can be used to measure elapsed time.
            - Visibility: private

            - Name: _maxChicks (int)
            - Description: An integer variable containing the maximum number of chicks the player can capture in the game.
            - Visibility: private

            - Name: Run()
            - Description: Controls the entire game loop, calls start method then calls the update and draw method until the Raylib.WindowShould close or if _application should close returns true
            - Visibility: public 
            - Arguments: none

            - Name: Start()
            - Description: Initializes all starting variables as well as actors and UI elements, adding them to scene actor arrays.
            - Visibility: private 
            - Arguments: none

            - Name: Update()
            - Description: Calls the Update and UpdateUI methods in the current scene, then checks to see if player has collected all they needed to collect or if they have died
            - Visibility:  private
            - Arguments: deltaTime (float)

            - Name: End()
            - Description: Calls the end function in the current scene, closes the Raylib window, and clears the console.
            - Visibility:  private
            - Arguments: none

            - Name: Draw()
            - Description:
            - Visibility: private 
            - Arguments: none

            - Name: AddScene()
            - Description: Adds a new scene object that is passed into the method to the Engine's Scene object array.
            - Visibility: Public
            - Arguments: scene (Scene)

            - Name: CloseApplication()
            - Description: Sets _applicationShouldClose to be true
            - Visibility: Public
            - Arguments: none

            - Name: AllChicksCaught()
            - Description: Finds the player in the current scene array and returns true if the player's amount of chick's caught is equal to the _maxChicks variable
            - Visibility: private
            - Arguments: none

            - Name: CheckPlayerStatus()
            - Description: Finds the player in the current scene array and returns true if the player's IsDead bool is equal to true.
            - Visibility: private
            - Arguments: none
    - **Filename**: Player.cs
        - **Class Name**: Player : Actor
            - Name: _velocity (Vector2)
            - Description: A vector2 variable containing values that represent the players velocity
            - Visibility: private

            - Name: _speed (float)
            - Description: a float variable containing a value representing the players speed.
            - Visibility: private

            - Name: _defaultSpeed (float)
            - Description: a float variable containing a value representing the players default speed.
            - Visibility: private

            - Name: _isDead (bool)
            - Description: a bool variable that returns true if the player is dead, false if the player is alive.
            - Visibility: private

            - Name: _currChildren (int)
            - Description: an int variable representing how many children the player has in their children array.
            - Visibility: private

            - Name: IsDead (bool)
            - Description: a property that returns and privately sets the value of _isDead
            - Visibility: public

            - Name: CurrChildren (int)
            - Description: a property that returns and privately sets the value of _currChildren
            - Visibility: public

            - Name: Speed (float)
            - Description: a property that returns and sets the value of _speed
            - Visibility: public

            - Name: Velocity (Vector2)
            - Description: a property that returns and sets the value of _velocity
            - Visibility: public

            - Name: Player()
            - Description: Constructor of Player class, also calls the base constructor, sets _speed to speed argument, sets _defaultSpeed to _speed, and sets _isDead to false
            - Visibility: public
            - Arguments: x (float), y (float), speed (float), name (string), path (string)

            - Name: Update()
            - Description: Checks which button is pressed by the player, then moves the player object to that position. Also checks if player is holding shift before increasing the speed, Updates every frame
            - Visibility: public
            - Arguments: deltaTime (float)

            - Name: OnCollision()
            - Description: Detects if the object the player collided with is a Collectable or a Car object. If it's a collectable, the object is added to the players children and the CurrChildren value is increased. If it's a Car object, the player's IsDead bool is set to true.
            - Visibility: public (override)
            - Arguments: collider (Actor)

            - Name: Darw()
            - Description: Draws Player object to the screen so it is visible to the user by calling the base.Draw() method and drawing the collider object to the screen using Collider.Draw() method.
            - Visibility: public
            - Arguments: none
    - **Filename**: Scene.cs
        - **Class Name**: Scene
            - Name: _actors (Actor[])
            - Description: An array containing all the actors in a given scene.
            - Visibility: private

            - Name: _UIElements (Actor[])
            - Description: An array containing all the UI Elements in a given scene.
            - Visibility: private

            - Name: _backgroundColor (Color)
            - Description: A variable containing the color of the background in the current scene.
            - Visibility: private

            - Name: Actors (Actor[])
            - Description: A property that returns the value of the variable _actors
            - Visibility: public

            - Name: Scene()
            - Description: Base constuctor of the class, sets _actors and _UIElements to a new Actor array, and sets the background color to the backgroundColor Argument passed through the constructor. 
            - Visibility: public
            - Arguments: backgroundColor (Color)

            - Name: Start()
            - Description: Calls start for all the actors in the _actors array
            - Visibility: Public (virtual)
            - Arguments: none

            - Name: Update()
            - Description: Calls start for the actors in _actors array if the actor hasn't called it already, then calls the Update method for every actor. Also checks for collision for every Actor in the array.
            - Visibility: public
            - Arguments: deltaTime

            - Name: UpdateUI()
            - Description: Calls the start method for every actor in _UIElements array if it hasn't started already, then calls the Update method on every actor in the array.
            - Visibility: public
            - Arguments: deltaTime (float)

            - Name: End()
            - Description: Calls End for all the actors in the _actors array
            - Visibility: public (virtual)
            - Arguments: none

            - Name: Draw()
            - Description: Calls draw for all the actors in the _actors array
            - Visibility: public (virtual)
            - Arguments: none

            - Name: DrawUI()
            - Description: Calls draw for all the actors in the _UIElements array
            - Visibility: public (virtual)
            - Arguments: none

            - Name: AddActor()
            - Description: Adds a specified actor passed into the method to the _actors array by creating a temporary array that's one space longer, adding values of the _actors array to that temporary array, setting the empty space in the array to the actor being passed through, then setting the _actors array to the temporary array.
            - Visibility: public
            - Arguments: actor (Actor)

            - Name: AddUIElement()
            - Description: Adds a specified actor passed into the method to the _UIElements array by creating a temporary array that's one space longer, adding values of the _UIElements array to that temporary array, setting the empty space in the array to the actor being passed through, then setting the _UIElements array to the temporary array.
            - Visibility: public
            - Arguments: UIElement (Actor)

            - Name: RemoveActor()
            - Description: Removes a specified actor from the _actors array by creating a new, temporary array that is one unit shorter than the _actors array then adding elements from the _actors array as long as those elements are not equal to the actor trying to be removed. Will set an ActorRemoved variable to true if the actor is found in the _actors array and the _actors array is set to the new temporary array.
            - Visibility: public
            - Arguments: actor (Actor)
    - **Filename**: ScoreHolder.cs
        - **Class Name**: ScoreHolder : Actor
            - Name: _player (Player)
            - Description: A Player variable containing a refrence to a Player object
            - Visibility: private

            - Name: _counter (UIText)
            - Description: A UIText variable containing a refrence to a UIText object
            - Visibility: private

            - Name: Scoreholder()
            - Description: Base constructor of the ScoreHolder object, sets _player to the player argument, and sets the _counter to the counter argument. Uses other arguments to fill out base class.
            - Visibility: private
            - Arguments: x (float), y (float), name (string), path (string),  player (Player), counter (UIText)

            - Name: Start()
            - Description: Calls the base.Start() method and the _counter.Start() method
            - Visibility: public
            - Arguments: none

            - Name: Update()
            - Description: updates the counter text based on how many chicks were caught
            - Visibility: public
            - Arguments: deltaTime (float)

            - Name: Draw()
            - Description: calls the _counter.Draw() method
            - Visibility: public
            - Arguments: none
    - **FileName**: Sprite.cs
        - **Class Name**: Sprite
            - Name: _texture (Texture2D)
            - Description: A Texture2D variable containing the flat, two-dimensional texture of the sprite
            - Visibility: private

            - Name: Width (int)
            - Description: A property that returns and privately sets the _texture.width variable.
            - Visibility: public

            - Name: Height (int)
            - Description: A property that returns and privately sets the _texture.height variable.
            - Visibility: public

            - Name: Sprite()
            - Description: Base constructor for the Sprite class, sets the _texture to the path argument by using the Raylib.LoadTexture() method
            - Visibility: private
            - Arguments: path (string)

            - Name: Draw()
            - Description: Draws the sprite onto the raylib window so that it is part of the user interface and is visible to the user.
            - Visibility: Public
            - Arguments: transform (matrix3)
    - **FileName**: UIText.cs
        - **Class Name** UIText : Actor
            - Name: _text (string)
            - Description: A string variable holding the text element of the UIText object
            - Visibility: private

            - Name: _width (int)
            - Description: An int variable that refrences the width of the UIText object
            - Visibility: private

            - Name: _height (int)
            - Description: An int variable that refrences the height of the UIText object
            - Visibility: private

            - Name: _fontSize (int)
            - Description: An int variable that refrences the number representing the UIText object text's font size
            - Visibility: private

            - Name: _font (Font)
            - Description: A Font type variable that represents the font the UIText object text will be displayed in
            - Visibility: private

            - Name: _textboxColor (Color)
            - Description: A Color type variable that represents the Color of the textbox used to display text clearly
            - Visibility: private

            - Name: Text (string)
            - Description: A property returning and setting the _text variable 
            - Visibility: public

            - Name: Width (string)
            - Description: A property returning and setting the _width variable 
            - Visibility: public

            - Name: Height (string)
            - Description: A property returning and setting the _height variable 
            - Visibility: public

            - Name: UIText()
            - Description: constructor for the UIText object, sets Text to text argument, Width to width argument, Height to height argument, _fontsize to fontsize argument, _font to a font from Raylib.LoadFont() method, and _textboxColor is set to textboxColor argument. Any other arguments are sent to the base class.
            - Visibility: public
            - Arguments: x (float), y (float), name (string), path (string), text (string), width (int), height (int), fontsize (int), textboxColor (Color)

            - Name: Draw()
            - Description: Draws the text within the bounds of an assigned rectangle using the Raylib.DrawTextRec() method and also drawing a texbox behind the text using the Raylib.DrawRectangleRec() method.
            - Visibility: public (override)
            - Arguments: none
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

            
            

            

            

            








    
            