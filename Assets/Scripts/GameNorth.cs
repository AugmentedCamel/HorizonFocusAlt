using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNorth : MonoBehaviour
{
    public Transform gameNorth;
    
    //this is used as Game North, it is syncroninzed in the beginning with the actual north.
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public float NorthDirectionYAngle()
    {
        return gameNorth.rotation.eulerAngles.y;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
