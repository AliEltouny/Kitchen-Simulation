using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[CreateAssetMenu()]
public class BurningRecipeSO : ScriptableObject {
    

    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public float burningTimerMax;


}