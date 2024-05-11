using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;

public class SFXLauncher : MonoBehaviour
{
    public List<UnityEvent> SFXEvents;
    public UnityEvent NorthCalibrationEvent;
    public UnityEvent x;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
