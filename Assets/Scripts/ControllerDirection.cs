using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerDirection : MonoBehaviour
{
    public Transform controllerDirection;
    public float controllerDirectionYAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controllerDirection != null)
        {
            controllerDirectionYAngle = controllerDirection.rotation.eulerAngles.y;
            //controllerDirection.rotation = Quaternion.Euler(0, controllerDirectionYAngle, 0);
        }
    }
}
