using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetGenerator : MonoBehaviour
{
    
    private List<string> _targets = new List<string> { "North", "North-East", "East", "South-East", "South", "South-West", "West", "North-West", "Amsterdam" };
    private List<float> _targetAngles = new List<float> { 0, 45, 90, 135, 180, 225, 270, 315, 35 };

    private List<string> _cityTargets = new List<string>
    {
        "Rotterdam", "Amsterdam", "Tokyo", "New York", "Adelaide", "Berlin", "Cape Town", "Dubai", "London", "Paris", "Rio de Janeiro" 
    };
    
    private List<float> _cityBearings = new List<float>
    {
        231, 26, 35, 231, 79, 80, 166, 104, 263, 204, 222
    }; 
    
    public string currentTarget = "N";

    public int currentTargetIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float GenerateTarget()
    {
        
        int newIndex = Random.Range(0, _targets.Count);
        currentTarget = _targets[newIndex];
        currentTargetIndex = newIndex;
        return _targetAngles[newIndex];
    }

    public float GenerateTargetCity()
    {
        int newIndex = Random.Range(0, _cityTargets.Count);
        currentTarget = _cityTargets[newIndex];
        currentTargetIndex = newIndex;
        return _cityBearings[newIndex];
    }
    
    
}
