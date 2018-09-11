# Capstone (VR Design Your House) Project

This project is part of [Udacity](https://www.udacity.com "Udacity - Be in demand")'s [VR Developer Nanodegree](https://www.udacity.com/course/vr-developer-nanodegree--nd017).

To play: Follow the audio cues at the beginning. After you cross the street you have two choices. You can either go around the building to see the scenery or you can enter the building. Once you enter the building you can go into the Builder Info room to view a short video, go to the General Info room to watch 360 video clips or go into the House Selection Room to start selecting options to design your house. Be ready for suprises while you play.

## Versions
- Unity 2017.4.0f1
- GVR Unity SDK v1.120.0
- iTween v2.0.9
- Tested on iPhone 6 Plus running the latest version of iOS 11
- Target platform: Google Cardboard

## Links
- Game execution video: https://youtu.be/RZNWdsZ3rjc
- Project Achievements video: https://youtu.be/SwqXXdxx_y0

## Emotion
The goal of my Design Your Home project is to provoke laughter and surprise throughout the application. It appears that you are going to design your home but you will find unexpected things along the way. Selections are made when designing the home but most of the results are randomized. It may provoke frustration for some depending on the person's personality type.

## Sounds
- Dog barking downloaded from [SoundBible](http://soundbible.com/1514-Neighborhood-Dogs-Barking.html).
- Construction audio downloaded from [SoundBible](http://soundbible.com/2134-Tractor-Digging.html).
- Explosion audio downloaded from [FreeSound](https://freesound.org/people/tommccann/sounds/235968/).
- Sounds of Hell audio downloaded from [FreeSound](https://freesound.org/people/klankbeeld/sounds/213944/).
- House under water audio downloaded from [FreeSound](https://freesound.org/people/Robinhood76/sounds/317067/).
- Piling machine audio downloaded from [YouTube](https://www.youtube.com/watch?v=CQZ8oEsgHzc).

## Scripts
- Floating script used for house floating in water originlly written by [Donovan Keith](http://www.donovankeith.com/2016/05/making-objects-float-up-down-in-unity/) [MIT License](https://opensource.org/licenses/MIT). Script was modified to start/stop the animation.
- FPS display script used for testing from Unity3d Wiki (http://wiki.unity3d.com/index.php/FramesPerSecond).

## Model Assets
- Animal assets from **ANIMALS PACK lowPoly** in the [Unity App Store](https://assetstore.unity.com/packages/3d/characters/animals/animals-pack-lowpoly-67734).
- Coke and snack machines from **Snack Machines** in the [Unity App Store](https://assetstore.unity.com/packages/3d/props/interior/snack-machines-3517).
- Bench, potted plants, constuction cones, fence and tree assets from **Low Poly Street Pack** in the [Unity App Store](https://assetstore.unity.com/packages/3d/environments/urban/low-poly-street-pack-67475).
- Vehicles are from **Background Car - Free** in the [Unity App Store](https://assetstore.unity.com/packages/3d/vehicles/land/background-car-free-87053). 
- Chairs and sofas are from **Big Furniture Pack** in the [Unity App Store](https://assetstore.unity.com/packages/3d/props/furniture/big-furniture-pack-7717). 
- Fence in construction site is from **Industrial Props Kit** in the [Unity App Store](https://assetstore.unity.com/packages/3d/props/industrial/industrial-props-kit-84745). 
- Construction vehicle asset from **Low Poly Destructible Cars 2 - Construction Free** in the [Unity App Store](https://assetstore.unity.com/packages/3d/vehicles/land/low-poly-destructible-cars-2-construction-free-69083).
- Dynamite box in construction site from **Cartoon explosive** in the [Unity App Store](https://assetstore.unity.com/packages/3d/props/weapons/cartoon-explosive-113242).
- Haunted House from **Customizable Medieval Houses** in the [Unity App Store](https://assetstore.unity.com/packages/3d/environments/customizable-medieval-houses-8963).
- Houses inside the lobby from  **Simple Houses Lite** in the [Unity App Store](https://assetstore.unity.com/packages/3d/environments/simple-houses-lite-78201).
- Houses outside from **UK Terraced Houses Pack FREE** in the [Unity App Store](https://assetstore.unity.com/packages/3d/environments/urban/uk-terraced-houses-pack-free-63481).

## Fundamentals Achievements
- #1 Scale achievement (100 pts) - The scaling inside and outside of a huge building reflects an experience for an average size human being.
- #2 Animation achievement(100 pts) - Animations are used for both doors, the shaking of the haunted house, the moving of the dog's head, the moving of the pile machine with a separate animation to coordinate the sound with when it hits the object and the moving of the construction vehicle arm.
- #4 Locomotion achievement (100 pts) - Waypoints are used to move around outside of the building.
- #5 Physics achievement (100 pts) - The house floating in water (Floating script) uses physics forces.
- #6 Video Player achievement (100 pts) - Two videos are available for viewing in the two side rooms inside of the building, one regular and one 360.

## Completeness Achievements
- #1 Gamification achievement (250 pts) - The selecting of varying house building combinations produces a reward of a designed home when completed and accepted by the person.
- #3 Alternative Storyline achievement (250 pts) - The available experiences are (1) walking around the building to see the construction site and model homes without going inside, (2) viewing a video in each side room without designing a home or (3) going into the House Selection room to design their house.
- #5 3D Modeling achievement (250 pts) - The following 3D models were created using Google Sketchup: BoothInside, SignOutdoor, BoothToParking, ConstructionSign, BillboardCastle

## Challenges Achievements
- #2 User Testing (250 pts X 2 with 750 in Completeness) - Completed five user tests during the development process. Here are the questions I asked with the detailed responses.
     > How does the scene look overall to you?
       a. Paths on the outside were uneven. Leveled paths.
       b. Light on haunted house was too bright in daylight and especially at night. Added a blue light in the same area to turn on when the scene goes dark. Adjusted the intensity of the light during daytime. Added signs that say ‘Toy Box’ in front of them. Added lights above the houses
       c. Did not understand the point of the two houses inside and there was no lighting. Added signs that say ‘Toy Box’ in front of them. Added lights above the houses.
       d. The green text on the glass walls in the main area was way too large. Reduced the size of the text.
       e. Hard to find the booth after exiting a room. Added orange text telling people to turn around to view the booth.
       f. Outside signs were way too big. Signs were resized to scale.
       g. Camera heights were inconsistent. It was almost like a yoyo. Changed them to the same height.
       h. Waypoints were not at the same level, looked uneven. Y axis changed for all waypoints.
       i. Images in left and right rooms were way too large. Images resized to scale.
       j. The video length in the left room is longer than the text says below the video screen. Updated text with the correct video length.
     > How does the scene look with the modifications and the animations and sounds I added to the outside scene?
       a. Exit signs were in an awkward place where they could click the exit signs from the main area. Moved exit signs to back of front glass wall. 
       b. The sign going to the construction site was still incredibly large. Sign reduced to match the size of the other signs.
       c. Cones in construction site are floating. Cones were lowered. Grouped together for easier movement.
       d. The explosion is not realistic enough. It looks cheesy. Add particle systems to simulate the explosion better.
       e. After the explosion the audio for the crane is not working. Added loop to audio source for the crane audio.
       f. The text on the left and right glass walls inside the building is not bright when running the application. Increased the Z position for the canvas.
       g. Plants on back corners are floating. They were lowered.
       h. Text on the section to check for animals is way too high. Text was lowered and centered.
       i. The plant pots in front of the building were higher than the benches. Reduced size of plant pots by half.
       j. The sign near the front door is taller and larger than the ‘person’. Rescaled the sign size.
       k. Audio playing toward the main area did not fit the application. The wrong audio was playing. The audio source was updated with the correct audio clip.
       l. No explanation of what to expect in each room. Recorded audios for left and right rooms in main area.
     > How does the scene look with the corrections and new additions?
       a. Cones are not flush with the path. Cones lowered.
       b. The middle construction vehicle size in the construction zone is way too large. The scale was reduced.
       c. Plants on the front are floating. Plants lowered.
       d. Construction site sign too large and the black text is hard to read. Reduced scale for sign and changed the text to white.
       e. Sign for model homes near construction site is too far away. Sign moved closer to path.
       f. The video screen in the General Info room is too high. Lowered it to the same place as in the left room.
       g. Concrete near the building exposes grass. Moved them close to the building.
       h. After reentering the construction site a second time the waypoint is there but not clickable. Changed MoveTheCamera script to execute Exit method in the Waypoint script to set the state back to Idle.
       i. After turning around in the parking lot the waypoint is there but not clickable. See previous item.
       j. Awkward exiting out of rooms into the main area. Add rotations when people exit rooms in the main area.
       k. Exit signs in each room are dark but works as expected. Moved them forward.
       l. General Info lettering on the glass wall is dark. Moved text forward.
       m. When you exit a room and go back to the main area it is a little confusing what to do or where to go. Reworded the orange booth text to include both the booth and other rooms.
     > How does the scene look with the corrections and new asthetic changes?
       a. Hard to read the text on the options in the House Selection room. Reformatted the toggles and increased font size of the labels.
       b. No text describing the images in House Photos room. Added text below each image on the left and right walls.
       c. Images in the Builder Info and General Info rooms are too high compared to the height of the 'person'. Images were lowered.
       d. Hard to see Model Homes sign near construction site. Increased the size of the sign and changed position.
       e. Very difficult to see the corners in the inside room with no shadows. Added material with a slightly lighter color to use for vertical walls.
       f. Random images are changed twice in House Photos room. Moved code for certain gameobjects to only execute the first time the method executes.
       g. Scaling of existing pictures is strange in House Selection Room. They appear to not match the image dimensions. Adjusted the scale to enlarge the images.
       h. Rooms looked mostly empty because of lots of bare walls. Added images throughout where they make sense.
       i. Exit sign in House Selection room dark. Moved the exit sign to the right wall in the room near the entrance.
       j. It was hard to see the separator wall section between the inside/outside sections where the exit sign for the inside options section appears. When you look toward the outside options section it all looks like one blob. Changed the separator wall color to a semitransparent color.
       k. After clicking the exit sign in the Inside Options setion he path back to the House Selection room is very awkward. Changed to go straight back to room instead of stepping back through rooms. Added audio when people abandon the house selection process and start over.
     > How does the scene look with the corrections and new additions?
       a. You can click the exit sign in the House Selection room from the main area. Moved the exit sign to the right to bring it closer to the reticle where it’s no longer dark.
       b. When playing the 360 video you see the reticle finding other active gameobjects. Added logic to disable them when watching the movie and enable them again when they quit watching it.
       c. When playing the 360 video the controls are hard to press because they are too close. Sometimes they appear double. Enlarged the movie sphere from 5 to 9 and moved the controls far away.
       d. Dog head animation is barely seen when the audio starts. Changed to start/stop the audio and animation at the first waypoint along the display.
       e. The explosion looked strange because there was no shaking. Implemented a camera shake using iTween ShakePosition to make it look more realistic.