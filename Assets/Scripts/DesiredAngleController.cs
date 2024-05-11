using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DesiredAngleController : MonoBehaviour
{
    public bool waitingForInput = false;
    
    private float _desiredAngle = 0; //this is the target that the player should aim at a value between 0 and 360
    private float _lastAngleDifference = 0; //this is the last angle the player has shot at a value between 0 and 360
    [SerializeField] private CurrentAngle _currentAngle;
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private TextMeshProUGUI _debugText;
    [SerializeField] private bool _debugMode = false;
    // Start is called before the first frame update
    public void SetTargetAngle(float angle)
    {
        _desiredAngle = angle;
        waitingForInput = true;
    }

    private void CalculatePlayerInput()
    {
        float currentAngle = _currentAngle.currentAngle; //this is the angle the player has shot at a value between 0 and 360.
        float angleDifference = _desiredAngle - currentAngle; //this is the difference between the desired angle and the current angle
        
        if (angleDifference > 180)
        {
            angleDifference -= 360;
        }
        else if (angleDifference < -180)
        {
            angleDifference += 360;
        }
        
        //the angle difference is never more than 180 degrees or less than -180 degrees
        _lastAngleDifference = (float)Math.Round(angleDifference, 2); // Rounds to 2 decimal places
        
        //Debug.Log("The player has shot at an angle of " + currentAngle + " degrees and the desired angle is " + _desiredAngle + " degrees. The difference is " + _lastAngleDifference + " degrees.");
        
    }
    
    public void OnPlayerShoot()
    {
        if (waitingForInput)
        {
            CalculatePlayerInput();
            _gameManager.OnPlayerShoot(_lastAngleDifference);
            waitingForInput = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_debugMode)
        {
            float roundedAngle = (float)Math.Round(_currentAngle.currentAngle, 2);  
            _debugText.text = roundedAngle.ToString();
        }
    }
}
