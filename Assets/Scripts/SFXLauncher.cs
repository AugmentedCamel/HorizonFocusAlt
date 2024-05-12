using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class SFXLauncher : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    
    public UnityEvent soundStartScene;
    public UnityEvent soundPoleSpawn;
    public UnityEvent soundVirtualKeyBoardAppear;
    public UnityEvent soundVirtualKeyboardButton;
    public UnityEvent soundVirtualKeyBoardDisappear;
    public UnityEvent soundConfirmLocation;
    public UnityEvent soundSyncController;
    public UnityEvent soundSyncNorth;
    public UnityEvent soundSyncControllerDissapear;
    public UnityEvent soundSignPostEnter;
    public UnityEvent soundSignPostSwing;
    public UnityEvent soundPlayerShootEasy;
    public UnityEvent soundPlayerShootHard;
    public UnityEvent soundSuccesfullShot;
    public UnityEvent soundUnsuccesfullShot;
    public UnityEvent soundScoreFeedback;
    
    public UnityEvent soundGameLost;
    public UnityEvent soundGameWon;

    public UnityEvent soundControllerTurnsTen; //when the north is activated this will fire every 10 degres the controller is turned
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void LaunchControllerTurnsTen()
    {
        Debug.Log("Controller Turns Ten");
        soundControllerTurnsTen.Invoke();
    }
    
    public void LaunchSoundStartScene()
    {
        Debug.Log("Launch StartScene Sound");
        soundStartScene.Invoke();
        
    }
    
    public void LaunchSoundPoleSpawn()
    {
        Debug.Log("Pole Spawn");
        soundPoleSpawn.Invoke();
    }
    
    public void LaunchSoundVirtualKeyBoardAppear()
    {
        Debug.Log("Virtual Keyboard Appear");
        soundVirtualKeyBoardAppear.Invoke();
    }
    
    public void LaunchSoundVirtualKeyboardButton()
    {
        Debug.Log("Virtual Keyboard Button");
        soundVirtualKeyboardButton.Invoke();
    }
    
    public void LaunchSoundVirtualKeyBoardDisappear()
    {
        Debug.Log("Virtual Keyboard Disappear");
        soundVirtualKeyBoardDisappear.Invoke();
    }
    
    public void LaunchSoundConfirmLocation()
    {
        Debug.Log("Confirm Location");
        soundConfirmLocation.Invoke();
    }
    
    public void LaunchSoundSyncControllerAppear()
    {
        Debug.Log("Sync Controller");
        soundSyncController.Invoke();
    }
    
    public void LaunchSoundSyncNorth()
    {
        Debug.Log("Sync North");
        soundSyncNorth.Invoke();
    }

    public void LaunchSoundSyncControllerDissapear()
    {
        Debug.Log("Disaapear controller");
        soundSyncControllerDissapear.Invoke();
    }
    
    public void LaunchSoundSignPostEnter()
    {
        Debug.Log("Sign Post Enter");
        soundSignPostEnter.Invoke();
    }

    public void LaunchSoundSignPostSwing()
    {
        Debug.Log("Sign Post Swing _ this does not work yet");
        soundSignPostSwing.Invoke();
    }

    public void LaunchSoundPlayerShootEasy()
    {
        Debug.Log("Player Shoot Easy");
        soundPlayerShootEasy.Invoke();
    }

    public void LaunchSoundPlayerShootHard()
    {
        
        
        Debug.Log("Player Shoot Hard");
        soundPlayerShootHard.Invoke();
    }

    public void LaunchSoundSuccesfullShot(int score) //value 0 - 10 
    {
        Debug.Log("Successful Shot");
        soundSuccesfullShot.Invoke();
    }

    public void LaunchSoundUnsuccesfullShot(int score)  //value 10 - 180
    {
        Debug.Log("Unsuccessful Shot");
        soundUnsuccesfullShot.Invoke();
    }

    public void LaunchSoundScoreFeedback(int totalscore)
    {
        int gametotalscore = totalscore; //this is a value from 0 - 500 , 500 = game over;
        Debug.Log("Score Feedback");
        soundScoreFeedback.Invoke();
    }

    public void LaunchSoundGameLost()
    {
        Debug.Log("Game Lost");
        soundGameLost.Invoke();
    }

    public void LaunchSoundGameWon()
    {
        Debug.Log("Game Won");
        soundGameWon.Invoke();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
