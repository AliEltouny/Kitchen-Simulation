using System;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour {


    [SerializeField] private StoveCounter stoveCounter;
    [SerializeField] private GameObject StoveOnGameObject;
    [SerializeField] private GameObject particlesGameObject;


    private void Start() {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e) {
        bool showVisual = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;
        StoveOnGameObject.SetActive(showVisual);
        particlesGameObject.SetActive(showVisual);
    }

}