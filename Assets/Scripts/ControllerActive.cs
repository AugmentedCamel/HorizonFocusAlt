using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerActive : MonoBehaviour
{
    
    
    [SerializeField] private List<GameObject> _controllers;
    
    // Start is called before the first frame update
    
    public void ChangeControllerToActive(int index)
    {
        if (_controllers.Count > index)
        {
            _controllers[index].SetActive(true);
            
            //inactivate all others
            for (int i = 0; i < _controllers.Count; i++)
            {
                if (i != index)
                {
                    _controllers[i].SetActive(false);
                }
            }
        }
    }
    
    public void DeactivateAllControllers()
    {
        foreach (var controller in _controllers)
        {
            controller.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
