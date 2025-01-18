[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/MjLLqDcN)
# HW1
## W1L2 In-Class Activity
"How would you desribe this game world in objects?"

There is a Player object that the user will control. There are Plant objects that a Player object can place within the world. 
There is a Camera object that will determine the angle that we are playing the game in. There are dynamic scoring objects that 
detail the amount of seeds a player has and the amount of plants that are on screen. And there is an Environment object that
determines the background of the game.

"What attributes and actions do these objects have?"

A Player has a static character design that can be moved using WASD keys. The player can also press SPACE to plant seeds. 
Once a plant has been placed, the plant is unable to be moved or removed. When a player reaches 5 total plants placed, then 
the player can continue pressing SPACE but no more plants will appear. The environment object itself as well as the camera 
can not do anything.

"How do these objects act on or affect each other?"

Players can place plants which in turn affects the scoring objects. When the player places one plant, the "Seeds Remaining" 
decreases by 1 while "Seeds Planted" increases by 1.

## Devlog
**PLAN**
*Step 1)* First, it is important to prepare all the objects so that we can do all the testing later when it is time to code. We need to
havce a player object and a plant object to ensure we can validate the basic functionality of using WASD to move the Player object
around and using SPACE to plant the seeds.

Step 1 will produce a PLAYER object and a PLANT object.

*Step 2)* AFter the creation of the objects, then it is important to begin creating the scripts. To start simple, we should start by
coding the movement of the player. The Player script must be attached to the Player object to ensure we can do testing/debugging.

Step 2 will produce methods move_up, move_down, move_left, and move_right.

*Step 3}* Next, we can code what happens when the user presses the SPACE key. When the user presses it, a Plant object should 
be created into the environment.

Step 3 will produce the methods place_plant.

*Step 4)* Finally, once we have ensured that a user properly places a plant into the environment, then we can create the scoring object
and update the "Seeds Remaining" and "Seeds Planted" variables accordingly within the code.

Step 4 will produce the object SCORES and the methods update_scores.

**CONNECTION**
My execution of the code was slightly different than what I had originally planned. At first, I thought I would have to create a Plant object
into the environment, when it turned out that using a Prefab was going to be the way to go if I wanted the Plant object to only appear in the
scene when a player interacts with the SPACE key. (*Step 1 Done*) After creating the Plant Prefab (and since the Player object was already created), I moved
on to assigning the SerializedFields in the Player script within Unity's UI. I realized that there was a field for the PlantCountUI and struggled
a bit wondering how to use that section. I later realized that I could just attach the the PlantCountUI to the Canvas and drag the text's with "num" in
their name into their corresponding SerializedFields, and then drag the Canvas object (which was now a PlantCountUI object) into the PlantCountUI field
on my Player script. (*Extra part for Step 1 and part of Step 4 done*) After filling in all the fields, I began coding the movement for the player.
After doing some research, I found it wasn't completely necessary to create 4 separate methods for the movement and decided to keep it
all within the Update function of the Player script. (*Step 2 finished*) Then, after ensuring that the speed was set accurately and the player moved
correcty, I moved on to the SPACE action. I used a logging statement within the if statement for the SPACE key and noticed that when a key was being pressed
once, it would log multiple times. I later realized that it was important not to use Get.Key and instead use Get.KeyDown as this prevents the key from being
read more than once within the Update function. This was also not it's own function and its logic was instead just kept inside the Update function.
(*Step 3 finished*) Finally, when I new the space button worked, it was time to connect the variables between the Player script and the PlantCountUI script. 
Since the Canvas object is a PlantCountUI that I dragged into the SerializedField for PlantCountUI, it was as simple as first checking if there were greater 
than 0 seeds left, insantiate the Plant prefab into the scene given the player's location, and then updating the seedsLeft and seedsPlanted values according 
before updating the UI. (*Step 4 finished*) One final step and detail that I noticed from the original game project was that the Plant objects would be
insantiated above the Player object, which was not happening on my original version. To fix this, I just had to mody the Plant Prefab's "Order In Layer" to 2
since the "Order In Layer" for the Player was 1. Overall, my process was a similar to the original plan I had set but I was jumping around different areas of
code a bit more frequently so it wasn't completely linear like the plan above.

**CLASS NAMES, METHODS, and GAMEOBJECTS**
*Classes*
- Player
- PlantCountUI

*GameObjects*
- MainCamera
- Player
- Canvas
    - Text_SeedsPlanted
    - Text_SeedsPlantedNum
    - Text_SeedsRemaining
    - Text_SeedsRemainingNum
- EventSystem
- Plant (Appear when SPACE is pressed down)

*Player.cs*
`private void Start()`: Initiates the default values for the PlantCountUI

`private void Update()`: Checks every frame if a player has pressed WASD (using Get.Key) and/or SPACE (Using Get.KeyDown). WASD moves
the player up, left, down, right, respectively. The value at which the player moves is determined by the _speed variable multipled by 
deltaTime. The keys W and S modify the Player's "pos.y" while the keys A and D modify the Player's "pos.x".
Pressing SPACE down insantiates a Plant Prefab object into the scene respective to the Player's respective position. The Get.KeyDown
method must be used for space so that the key is only read ONCE rather than multiple times within one frame.

`public void PlantSeed()`: Only called when it has been determined that there are enough seeds to plant a seed. This function updates the values
for the variables _numSeedsLeft and _numSeedsPlanted and then updates the UI accordingly.

*PlantCountUI.cs*
`public void UpdateSeeds (int seedsLeft, int seedsPlanted)`: Updates the text for Text_SeedsPlantedNum and Text_SeedsRemainingNum by assigning
their text into a stringified seedsPlanted and seedsLeft, respectively.

## Open-Source Assets
If you added any other outside assets, list them here!
- [Sprout Lands sprite asset pack](https://cupnooble.itch.io/sprout-lands-asset-pack) - character and item sprites

## Prof comments
Thank you for writing such a detailed Devlog, and for clearly connecting the plans that you wrote to your code! I hope that this process was helpful for your in figuring out how you should structure your game projects.

I'm definitely looking forward to see what you write for the HW2 Devlog, especially in terms of how you imagine you'll want to structure your coding plans moving forward. The plans that you write for your final project will be super important, especially since the project will be much more complex than the homeworks, so it'll be good to keep developing how you want to write your plans and Devlogs (as long as you're always answering the Devlog prompt!).

You may also want to check out this [README formatting guide here](https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax) to make sure your formatting turns out as expected.
