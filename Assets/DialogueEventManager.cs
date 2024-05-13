using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEventManager : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    
    public void OnStartOfGame()
    {
        //index 0 after seconds
        Invoke("StartGameAfterSeconds", 3);
    }
    
    private void StartGameAfterSeconds()
    {
        _audioManager.PlayNarrationClip(0);
        Invoke("OnInputCityOne", 2);
    }

    public void OnInputCityOne()
    {
        //index 1 ask to input city one
        _audioManager.PlayNarrationClip(1);
    }
    
    public void OnInputCityRetry()
    {
        //index 4 ask to retry after failure
        _audioManager.PlayNarrationClip(4);
    }
    
    public void OnGrabPhone()
    {
        //index 3 after succesfull city input ask to grab phone and open compass app
        _audioManager.PlayNarrationClip(3);
    }
    
    
    public void OnNorthSynchronized()
    {
        //index 5 put phone down its all good
        _audioManager.PlayNarrationClip(5);
    }
    
    public void OnStartWarmingUp()
    {
        //index 6 ask to point at west
        _audioManager.PlayNarrationClip(6);
    }
    
    public void OnArrowEast()
    {
        //index 7 to point at east
        _audioManager.PlayNarrationClip(7);
    }
    
    public void OnBeginCities()
    {
        //index 11 to start with cities
        _audioManager.PlayNarrationClip(11);
    }
    
    public void OnFeedbackPositive()
    {
        //index 8 or 9
        if (Random.Range(0, 2) == 0)
        {
            _audioManager.PlayNarrationClip(9);
        }
        else
        {
            _audioManager.PlayNarrationClip(8);
        }
        
    }
    
    public void OnFeedbackNegative()
    {
        //index 10
        
        if (Random.Range(0, 3) == 0)
        {
            _audioManager.PlayNarrationClip(10);
        }
        
    }
    
    public void OnGameWon()
    {
        //index 12
        _audioManager.PlayNarrationClip(12);
    }

    public void OnGameLost()
    {
        //index 13
        _audioManager.PlayNarrationClip(13);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
