using System.Collections;
using System.Collections.Generic;
using Meta.WitAi.Dictation;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class DictationActivationCustom : MonoBehaviour
{
    [SerializeField] private DictationService _dictation;
    [SerializeField] private TextMeshPro _lastCoordinates;
    [SerializeField] private CoordinateController _coordinateController;

    public UnityEvent secondsAfterActivation;
    public UnityEvent onInvalidInput;
    public UnityEvent onValidCoordinateUpdate;
    private bool _isActive = false;
    
    // Start is called before the first frame update
    
    
    public void ToggleActivation()
    {
        if (_isActive)
        {
            _dictation.Deactivate();
            _isActive = false;
        }
        else
        {
            _dictation.Activate();
            Invoke("PassToGPT", 5); //this waits for the user to give input
            _isActive = true;
        }
    }

    public void PassToGPT()
    {
        //should activate the chatgpt manager to check the input and make coordinates
        secondsAfterActivation.Invoke();
    }
    
    
    
    public void ReadVoiceResponse()
    {
        Debug.Log("reading response");
        if (_coordinateController.IsCoordinateValid(_lastCoordinates.text))
        {
            onValidCoordinateUpdate.Invoke();
        }
        else
        {
            _lastCoordinates.text = "";
            onInvalidInput.Invoke(); //should use this to give feedback to the user to repeat the input
        }
        
        
        
    }
}