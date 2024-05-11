using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetGenerator : MonoBehaviour
{
    
    [SerializeField] private CoordinateController _coordinateController;
    private List<string> _targets = new List<string> { "North", "North-East", "East", "South-East", "South", "South-West", "West", "North-West", "Amsterdam" };
    private List<float> _targetAngles = new List<float> { 0, 45, 90, 135, 180, 225, 270, 315, 35 };
    
    private List<string> _cityTargets = new List<string>
    {
        "Rotterdam", "Amsterdam", "Tokyo", "New York", "Adelaide", "Berlin", "Cape Town", "Dubai", "London", "Paris", "Rio de Janeiro" 
    };
    
    private List<string> _cityCoordinates = new List<string>
    {
        "51.9225, 4.47917", "52.379189, 4.899431", "35.6895, 139.6917", "40.7128, -74.0060", "-34.9285, 138.6007", "52.5200, 13.4050", "-33.9249, 18.4241", "25.276987, 55.296249", "51.5074, -0.1278", "48.8566, 2.3522", "-22.9068, -43.1729"
    };
    
    private List<float> _cityBearings = new List<float>
    {
        231, 26, 35, 231, 79, 80, 166, 104, 263, 204, 222
    }; 
    
    public List<float> _calulatedBearings = new List<float>();
    
    public string currentTarget = "N";

    public int currentTargetIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [Button]
    public void PlayerInputDummy()
    {
        OnPlayerInput("51.9225, 4.47917");
    }
    
    public void OnPlayerInput(string input)
    {
        //input here is player coordinates in "latitude,longitude" format
        if (input != null)
        {
            _coordinateController.SaveLocation(input);
            //calculate for each city the bearing relative o the players input
            foreach (var city in _cityCoordinates)
            {
                double[] target = _coordinateController.ParseCoordinate(city);
                if (target != null)
                {
                    float bearing = _coordinateController.CalculateBearingToNewLocation(city);
                    _calulatedBearings.Add((float)bearing);
                }
            }
            
        }
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
