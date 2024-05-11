using System;
using NaughtyAttributes;
using UnityEngine;

public class CoordinateController : MonoBehaviour
{
    [SerializeField] private Vector2 _savedLocation; // Stores the saved geographic location

    // Start is called before the first frame update
    void Start()
    {
        // You can optionally initialize a default location here
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    [Button]
    private void SaveDummeyLocation()
    {
        SaveLocation("-51.918998, 4.508277");
    }
    
    [Button]
    private void CalculateBearingToDummeyLocation()
    {
        CalculateBearingToNewLocation("48.8575, -255.3514");
        
    }
    /// <summary>
    /// Saves a given location as latitude and longitude.
    /// </summary>
    /// <param name="coordinate">Location to save in "latitude,longitude" format</param>
    public void SaveLocation(string coordinate)
    {
        double[] parsedCoordinate = ParseCoordinate(coordinate);
        if (parsedCoordinate != null)
        {
            _savedLocation = new Vector2((float)parsedCoordinate[0], (float)parsedCoordinate[1]);
            Debug.Log($"Saved location: {_savedLocation.x}, {_savedLocation.y}");
        }
        else
        {
            Debug.LogError("Invalid coordinate format for saving location.");
        }
    }

    /// <summary>
    /// Sets a new target location and calculates the bearing from the saved location.
    /// </summary>
    /// <param name="targetCoordinate">Target location in "latitude,longitude" format</param>
    public float CalculateBearingToNewLocation(string targetCoordinate)
    {
        double[] target = ParseCoordinate(targetCoordinate);
        if (target != null)
        {
            double bearing = CalculateRhumbLineBearing(_savedLocation.x, _savedLocation.y, target[0], target[1]);
            Debug.Log($"Bearing to new location: {bearing}°");
            return (float)bearing;
        }
        else
        {
            Debug.LogError("Invalid target coordinate format.");
            return 0;
        }
    }

    /// <summary>
    /// Parses a latitude and longitude string.
    /// </summary>
    /// <param name="coordinate">String in "latitude,longitude" format</param>
    /// <returns>Array with latitude and longitude as doubles, or null if parsing fails</returns>
    public double[] ParseCoordinate(string coordinate)
    {
        try
        {
            string[] parts = coordinate.Split(',');
            return new double[] { double.Parse(parts[0]), double.Parse(parts[1]) };
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error parsing coordinate '{coordinate}': {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Calculates the bearing between two geographic points using the rhumb line method.
    /// </summary>
    /// <param name="lat1">Latitude of point 1 in decimal degrees</param>
    /// <param="lon1">Longitude of point 1 in decimal degrees</param>
    /// <param="lat2">Latitude of point 2 in decimal degrees</param>
    /// <param="lon2">Longitude of point 2 in decimal degrees</param>
    /// <returns>Bearing in degrees</returns>
    private double CalculateRhumbLineBearing(double lat1, double lon1, double lat2, double lon2)
    {
        // Convert degrees to radians
        double φ1 = lat1 * Math.PI / 180.0;
        double φ2 = lat2 * Math.PI / 180.0;
        double Δλ = (lon2 - lon1) * Math.PI / 180.0;

        // Calculate Δψ (projected latitude difference)
        double Δψ = Math.Log(Math.Tan(Math.PI / 4 + φ2 / 2) / Math.Tan(Math.PI / 4 + φ1 / 2));

        // Correct Δλ to be within ±180° (shortest path)
        if (Math.Abs(Δλ) > Math.PI)
        {
            Δλ = Δλ > 0 ? -(2 * Math.PI - Δλ) : (2 * Math.PI + Δλ);
        }

        // Calculate the bearing
        double θ = Math.Atan2(Δλ, Δψ);

        // Convert from radians to degrees
        double bearing = (θ * 180.0 / Math.PI + 360.0) % 360.0;
        return bearing;
    }
}
