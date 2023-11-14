# unity-tilemap-adventure
A 2D sidescrolling platformer demo project using tilemaps in unity

![screenshot](https://github.com/sinamhdn/unity-tilemap-adventure/assets/34884156/6c9800c6-d3fe-4986-97c0-2d40cf5315e6)

## Unity Version
2022.3.2f1 LTS

## Assets Used
Super Platformer Assets by Foxfin fron Unity Assets Store\
\
**Desclaimer: this is not a commercial project and i use these assets only for practice purposes. to use them for a commercial project please pay for them on Unity Assets Store**

## Concepts Used
- Tilemap game objects
- Drawing tilemaps with tile palletes (delete with holding shift)
- Importing 3rd party 2d assets to unity
- Slicing sprites using sprite editor
- Using sorting layers for an object to appear behind or in front of another object
- Changing camera size using cmera settings
- Using tags to assign objects a specific type and detect them with it
- Using layers for collision rules of the objects
- Flipping a tile inside tile pallete by selecting it in edit mode and stting its x scale to -1
- Using rule tiles to program tilemap creation when drawing with tile pallete
- Animator component
- Animation controller
- Sprite renderer component
- Creating animation by selection multiple consecutive sprites
- Control animation transitions by creating varibles inside animation controller
- Creating prefab from game objects and applying their chnge to the original prefab
- Using rigidbody2d component to apply physics to the game object
- Capsule Collider, Tilemap Collider and Composite collider to make tilemaps have a unanimous collider
- Freezing rotation on rigidbody component
- Changing physics shape of sprites inside sprite editor
- Using Input Manager to bind inputs
- Changing physics setting inside project settings > physics2d
- Making collision of trigger type
- Using cinemachine camera
- Adding constaints to cinemachine camera
- Editing collision matrix
- Create state driven cinemachine cmeras
- Adding noise to cinemachine cameras
- Creating physics asset to remove friction
- Using OnTriggerExit2D event
- Using gating technique
- Loading other scene from one scene
- Creating UI in unity
- Using a game object as session controller to store general logic of the game like player lives or score
- Singleton patterns to make an object ot get created only once
- Coroutines
- Playing Audio at point so it wont stop when game object destroys
- Making changes persistant using singleton pattern

**NOTE: REMEMBER TO ADD SCENES TO BUILD SETTINGS IN THIS ORDER "StartMenu.unity" > "Level1.unity" > "Level2.unity" > "EndMenu.unity"**
