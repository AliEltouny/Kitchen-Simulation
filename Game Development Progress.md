---

# Cooking Game Development Progress

This document outlines the day-by-day progress in developing a Unity-based cooking game, focusing on mechanics, interaction, UI/UX, and gameplay features.

---

## Day 1 – Core Setup

* Implemented post-processing for improved visual quality.
* Added player character model.
* Created a movement system using `InputVector`, `rotateSpeed`, and `moveSpeed`. Smoothed movement with `Slerp`.
* Used `SerializeField` for private field inspector access.
* Added idle animation for the player.

---

## Day 2 – Animation & Input

* Introduced `PlayerAnimator` script to manage walking animation.
* Used a constant `IS_WALKING` parameter to toggle walking state.
* Integrated Unity's new Input System for flexible input handling.
* Refactored code to separate player logic from input logic.
* Started work on player collision:

  * Tested `Raycast` (rejected due to limitations).
  * Implemented `CapsuleCast` for accurate collision using height, radius, and movement direction.
  * Improved diagonal movement along walls.

---

## Day 3 – Kitchen Layout & Interaction

* Added kitchen models and created layout.
* Implemented interaction detection using raycasting.
* Created `ClearCounter` script with `TryGetComponent` to interact with counter objects.
* Added `Interact` actions and C# events.
* Developed `SelectedCounter` system with highlighting and Singleton pattern.
* Refactored and cleaned repeated code.

---

## Day 4 – Kitchen Objects & Counter System

* Added kitchen items: tomato, cheese, lettuce, buns, burger.
* Created `KitchenObject` Scriptable Objects (SO) for defining interactables.
* Developed kitchen object scripts and parent-child logic.
* Enabled picking up and placing items using interfaces.
* Introduced `ContainerCounter` for item spawning using prefab variants.
* Used inheritance and created `BaseCounter` class for unified counter logic.
* Simplified interaction logic and limited player to one held object at a time.

---

## Day 5 – Cutting System

* Enabled player to rotate toward counters when interacting.
* Added cutting functionality: place item on board, slice it, and retrieve slices.
* Created `CuttingRecipeSO` to define what items can be cut and into what.
* Prevented invalid cutting (e.g., already sliced items).
* Implemented cutting progress bar using a `World Canvas`.
* Fixed float division in progress calculation.
* Added cutting animation and smooth canvas rotation with `LateUpdate`.
* Added trash bin (deletes held items) and reorganized folder structure.

---

## Day 6 – Cooking & Plate System

* Created Scriptable Objects for patty states: raw, cooked, burned.
* Developed state machine in `StoveCounter` to manage transitions.
* Added particle effects and UI bar for cooking progress.
* Refactored cutting progress to use `IHasProgress` interface for reuse.
* Implemented plate system with stackable plate visuals and item placement.
* Ensured item stacking shows correct visuals and icons.

---

## Day 7 – Recipe Delivery System

* Finalized kitchen design with proper counter placement.
* Created `DeliveryCounter` and visual effect indicators.
* Built `DeliveryManager` to randomly assign and validate recipes.
* Developed delivery UI using world canvas with recipe icons and names.
* Implemented success/failure logic with UI feedback.

---

## Day 8 – Audio & Game Loop

* Added sound effects: chopping, walking, cooking, item interaction, and order feedback.
* Integrated background music.
* Created game loop states: `WaitingToStart`, `CountdownToStart`, `GamePlaying`, `GameOver`.
* Added countdown UI and post-game results screen.
* Designed main menu and pause menu:

  * Start, Quit, and Load screens.
  * Pause toggles time scale and shows pause canvas.
  * Escape key resumes or navigates to main menu.

---

## Day 9 – Settings & Key Rebinding

* Reset static data on main menu return.
* Added volume controls for sound/music using `PlayerPrefs`.
* Implemented dynamic key rebinding UI with prompts.
* Saved custom keybinds across sessions.

---

## Day 10 – Gamepad Support & Polish

* Added full controller support with UI navigation.
* Enhanced visuals with surrounding walls and UI animations.
* Added feedback animations for burned food warnings and delivery results.
* Introduced player tutorial on first load.
* Final gameplay polishing and usability improvements.

---