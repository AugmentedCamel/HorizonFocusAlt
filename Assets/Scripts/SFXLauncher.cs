using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class SFXLauncher : MonoBehaviour
{
    public List<UnityEvent> SFXEvents;
    public UnityEvent NorthCalibrationEvent;
    public UnityEvent soundStartScene;
    public UnityEvent soundPoleSpawn;
    public UnityEvent soundVirtualKeyBoardAppear;
    public UnityEvent soundVirtualKeyboardButton;
    public UnityEvent soundVirtualKeyBoardDisappear;
    public UnityEvent soundConfirmLocation;
    public UnityEvent soundSyncController;
    public UnityEvent soundSyncNorth;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    
    public void LaunchNorthCalibration()
    {
        NorthCalibrationEvent.Invoke();
    }
    
    public void LaunchSoundStartScene()
    {
        soundStartScene.Invoke();
    }
    
    [Button]
    public void LaunchSoundPoleSpawn()
    {
        Debug.Log("button pushed for pole spawn");
        soundPoleSpawn.Invoke();
    }
    
    public void LaunchSoundVirtualKeyBoardAppear()
    {
        soundVirtualKeyBoardAppear.Invoke();
    }
    
    public void LaunchSoundVirtualKeyboardButton()
    {
        soundVirtualKeyboardButton.Invoke();
    }
    
    public void LaunchSoundVirtualKeyBoardDisappear()
    {
        soundVirtualKeyBoardDisappear.Invoke();
    }
    
    public void LaunchSoundConfirmLocation()
    {
        soundConfirmLocation.Invoke();
    }
    
    public void LaunchSoundSyncController()
    {
        soundSyncController.Invoke();
    }
    
    public void LaunchSoundSyncNorth()
    {
        soundSyncNorth.Invoke();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
