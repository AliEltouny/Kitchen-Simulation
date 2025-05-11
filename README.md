# Unity Kitchen Simulation Game

This is a top-down, single-player kitchen simulation game developed in Unity. The player is responsible for preparing, cooking, and delivering food orders under time constraints. The project demonstrates modular gameplay systems, input flexibility, dynamic UI, and real-time state management.

## Project Summary

* **Platform**: PC (Keyboard and Gamepad supported)
* **Engine**: Unity 6 (6000.0.26f1)
* **Language**: C#
* **Project Type**: Final Year Undergraduate Project

---

## Features

* **Third-Person Character Control** using Unity's Input System
* **Interactive Environment** with counters, cutting boards, stoves, plates, and delivery areas
* **Ingredient Management** including raw, cooked, burned, and chopped states
* **Dynamic UI System** for order tracking, progress bars, timers, and score tracking
* **Recipe System** using ScriptableObjects
* **Audio System** for feedback and ambiance
* **Multiple Scenes** including Main Menu, Game Scene, and Loading Scene
* **Input Rebinding System** with persistent user settings
* **Support for Gamepad and Keyboard** controls

---

## Requirements

* Unity Editor version `6000.0.26f1`
* Input System, Cinemachine, TextMeshPro, and URP packages installed

---

## Setup Instructions

1. **Clone or Download the Project**

   * Ensure the entire `Assets/` and `ProjectSettings/` directories are intact.

2. **Open in Unity**

   * Open the project using Unity Hub.
   * Use version `6000.0.26f1`

3. **Run the Game**

   * Open `Scenes/MainMenuScene.unity`
   * Enter Play mode in the Unity Editor.

---

## Folder Structure

```
Assets/
├── Animations/                # Character and object animations
├── Materials/                 # Materials for rendering
├── Meshes/                    # 3D models used in the game
├── PrefabsVisuals/            # Visual-only prefabs
├── Sounds/                    # Audio clips and music
├── Textures/                  # 2D assets and icons
├── Prefabs/                   # Gameplay prefabs
│   ├── Counters/              # Stationary interactables
│   ├── KitchenObject/         # Ingredient and utensil prefabs
│   └── ProgressBarUI.prefab   # World-space UI elements
├── Scenes/                    # Game scenes
│   ├── GameScene.unity
│   ├── LoadingScene.unity
│   └── MainMenuScene.unity
├── ScriptableObjects/         # Data-driven objects
│   ├── BurningRecipesSO/
│   ├── CuttingRecipesSO/
│   ├── FryingRecipesSO/
│   ├── KitchenObjectSO/
│   └── RecipeSO/
├── Scripts/                   # C# source files
│   ├── Counters/              # Counter interaction logic
│   ├── ScriptableObjects/     # SO-specific logic
│   ├── UI/                    # UI management and animations
│   ├── GameInput.cs
│   ├── HasProgress.cs
│   ├── KitchenObjectParent.cs
│   ├── KitchenGameManager.cs
│   ├── KitchenObject.cs
│   ├── Loader.cs
│   ├── LoaderCallback.cs
│   ├── LookAtCamera.cs
│   ├── MusicManager.cs
│   ├── PlateCompleteVisual.cs
│   ├── PlateKitchenObject.cs
│   ├── Player.cs
│   ├── PlayerAnimator.cs
│   ├── PlayerSounds.cs
│   ├── ResetStaticDataManager.cs
│   ├── SelectedCounterVisual.cs
│   └── SoundManager.cs
├── Settings/                  # Input actions and rendering profiles
│   ├── DefaultVolumeProfile.asset
│   ├── PC_Renderer.asset
│   ├── PC_RPAsset.asset
│   └── PlayerInputActions.inputactions
├── Shaders/                   # Shader Graph assets
│   └── MovingVisual.shadergraph
└── TextMesh Pro/              # Fonts and text rendering resources
```

---

## Controls

| Action             | Keyboard (Default) | Gamepad (Default) |
| ------------------ | ------------------ | ----------------- |
| Move               | WASD               | Left Stick        |
| Interact           | E                  | A Button          |
| Alternate Interact | F                  | X Button          |
| Pause              | Esc                | Start Button      |

**Note**: Controls are fully rebindable via the in-game Options menu.

---

## Gameplay Overview

1. **Start from the Main Menu.**
2. **Prepare orders** by:

   * Picking up ingredients from counters
   * Cutting or frying items
   * Combining items on plates
3. **Deliver completed dishes** to the delivery area.
4. **Earn points** by completing orders before time runs out.
5. **Lose points** or time if orders are incorrect or burned.

---

## Scenes

* `MainMenuScene.unity`: Start screen, options, input rebinding
* `LoadingScene.unity`: Brief intermediary for scene loading
* `GameScene.unity`: Main gameplay area

---

## Technical Highlights

* Singleton architecture for managers (Game, Sound, Loader)
* Modular system for counter interactions using interfaces
* ScriptableObject-based data modeling for recipes and ingredients
* Visual feedback for game states using particle systems and animations
* Dynamic UI elements (order queue, progress bars, pause menu)
* Separation of visuals and logic for maintainability

---

## Testing and QA Checklist

* ✔️ Player input and movement
* ✔️ Object interaction and holding system
* ✔️ Cutting and frying states
* ✔️ Recipe validation and scoring
* ✔️ UI displays and updates in real time
* ✔️ Audio feedback for actions
* ✔️ Volume and input configuration persistence
* ✔️ Game over, pause, and restart functionality

---

## Known Issues

* Interactions may occasionally miss if facing away from the counter due to raycasting from last move direction.
* Delivery fails if plate contains items not matching a complete recipe.

---

## Credits

* Developed by: Aly Eltony
* Sound and music assets: Royalty-free assets from public sources
* UI and visual templates: Unity Asset Store and custom materials