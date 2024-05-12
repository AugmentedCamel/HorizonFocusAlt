using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Pole SFX")]
    //[field: SerializeField] public EventReference poleSpawn { get; private set; }
    
    [field: Header("Narration")]
    //[field: SerializeField] public EventReference narration { get; private set; }
    
    [field: Header("Ambience")]
    //[field: SerializeField] public EventReference ambience { get; private set; }

    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events instance in the scene.");
        }
        instance = this;
    }
    
}
