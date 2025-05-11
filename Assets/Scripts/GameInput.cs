using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour {


    private const string PLAYER_PREFS_BINDINGS = "InputBindings"; 


    public static GameInput Instance { get; private set; }

    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public event EventHandler OnPauseAction;
    public event EventHandler OnBindingRebind;


    public enum Binding {
        Move_up,
        Move_down,
        Move_left,
        Move_right,
        Interact,
        Interact_Alternate,
        Pause,
        Gamepad_Interact,
        Gamepad_InteractAlternate,
        Gamepad_Pause
    }



    private PlayerInputActions playerInputActions;

    private void Awake() {
        Instance = this;

        
        // Initialize the PlayerInputActions object
        playerInputActions = new PlayerInputActions();

        if (PlayerPrefs.HasKey(PLAYER_PREFS_BINDINGS)) {
            playerInputActions.LoadBindingOverridesFromJson(PlayerPrefs.GetString(PLAYER_PREFS_BINDINGS));
        }

        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
        playerInputActions.Player.Pause.performed += Pause_performed;
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        // Read the movement input and normalize it
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;

        return inputVector;
    }

    private void OnDestroy() {
        playerInputActions.Player.Interact.performed -= Interact_performed;
        playerInputActions.Player.InteractAlternate.performed -= InteractAlternate_performed;
        playerInputActions.Player.Pause.performed -= Pause_performed;

        playerInputActions.Dispose();
        // Disable the PlayerInputActions object when the GameObject is destroyed
        playerInputActions.Player.Disable();
    }

    public string GetBindingText(Binding binding) {
        switch (binding) {
            default:
            case Binding.Move_up:
                return playerInputActions.Player.Move.bindings[1].ToDisplayString();
            case Binding.Move_down:
                return playerInputActions.Player.Move.bindings[2].ToDisplayString();
            case Binding.Move_left:
                return playerInputActions.Player.Move.bindings[3].ToDisplayString();
            case Binding.Move_right:
                return playerInputActions.Player.Move.bindings[4].ToDisplayString();
            case Binding.Interact:
                return playerInputActions.Player.Interact.bindings[0].ToDisplayString();
            case Binding.Interact_Alternate:
                return playerInputActions.Player.InteractAlternate.bindings[0].ToDisplayString();
            case Binding.Pause:
                return playerInputActions.Player.Pause.bindings[0].ToDisplayString();
            case Binding.Gamepad_Interact:
                return playerInputActions.Player.Interact.bindings[1].ToDisplayString();
            case Binding.Gamepad_InteractAlternate:
                return playerInputActions.Player.InteractAlternate.bindings[1].ToDisplayString();
            case Binding.Gamepad_Pause:
                return playerInputActions.Player.Pause.bindings[1].ToDisplayString();    
        }
    }

    public void RebindBinding(Binding binding, Action onActionRebound) {
        playerInputActions.Player.Disable();

        InputAction inputAction;
        int bindingIndex;

        switch (binding) {
            default:    
            case Binding.Move_up:
            inputAction = playerInputActions.Player.Move;
            bindingIndex = 1;
            break;
            case Binding.Move_down:
            inputAction = playerInputActions.Player.Move;
            bindingIndex = 2;
            break;
            case Binding.Move_left:
            inputAction = playerInputActions.Player.Move;
            bindingIndex = 3;
            break;
            case Binding.Move_right:
            inputAction = playerInputActions.Player.Move;
            bindingIndex = 4;
            break;
            case Binding.Interact:
            inputAction = playerInputActions.Player.Interact;
            bindingIndex = 0;
            break;
            case Binding.Interact_Alternate:
            inputAction = playerInputActions.Player.InteractAlternate;
            bindingIndex = 0;
            break;
            case Binding.Pause:
            inputAction = playerInputActions.Player.Pause;
            bindingIndex = 0;
            break;
            case Binding.Gamepad_Interact:
            inputAction = playerInputActions.Player.Interact;
            bindingIndex = 1;
            break;
            case Binding.Gamepad_InteractAlternate:
            inputAction = playerInputActions.Player.InteractAlternate;
            bindingIndex = 1;
            break;
            case Binding.Gamepad_Pause:
            inputAction = playerInputActions.Player.Pause;
            bindingIndex = 1;
            break;
        }

        inputAction.PerformInteractiveRebinding(bindingIndex)
            .OnComplete(callback => { 
                callback.Dispose();
                playerInputActions.Player.Enable();
                onActionRebound();

                PlayerPrefs.SetString(PLAYER_PREFS_BINDINGS, playerInputActions.SaveBindingOverridesAsJson());
                PlayerPrefs.Save();

                OnBindingRebind?.Invoke(this, EventArgs.Empty);
            })
            .Start();
    }
}