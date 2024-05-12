using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentAngle : MonoBehaviour
{
    [SerializeField] private ControllerDirection _controllerDirection;
    [SerializeField] private Transform _gameNorth;
    [SerializeField] private SFXLauncher _sfxLauncher;
    
    public float currentAngle = 0;
    private float lastEventAngle = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CalculateCurrentAngle()
    {
        //the difference in angle between the controller and the synced north direction with a maximum of 180 degrees and minimum of -180 degrees
        
        if (_controllerDirection != null)
        {
            currentAngle = _controllerDirection.controllerDirectionYAngle - _gameNorth.rotation.eulerAngles.y;
            if (currentAngle < 0)
            {
                currentAngle += 360;
            }
            
            // Check if the current angle has passed a multiple of 10 degrees since the last event
            if (Mathf.Floor(currentAngle / 10) != Mathf.Floor(lastEventAngle / 10))
            {
                // Fire the event
                _sfxLauncher.LaunchControllerTurnsTen(); // Replace with the appropriate event

                // Update the last event angle
                lastEventAngle = currentAngle;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        CalculateCurrentAngle();
    }
}
