using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[CreateAssetMenu()]
public class FryingRecipeSO : ScriptableObject {
    

    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public float fryingTimerMax;


}