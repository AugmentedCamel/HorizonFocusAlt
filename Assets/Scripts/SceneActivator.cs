using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneActivator : MonoBehaviour
{
    public List<GameObject> _objectsToActivateOne;
    public List<GameObject> _objectsToDeactivateOne;
    public List<GameObject> _objectsToActivateTwo;
    public List<GameObject> _objectsToDeactivateTwo;
    public List<GameObject> _objectsToActivateThree;
    public List<GameObject> _objectsToDeactivateThree;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ActivateObjectsOne() //during setting of coordinates
    {
        foreach (var obj in _objectsToActivateOne)
        {
            obj.SetActive(true);
        }

        
    }
    
    public void ActivateObjectsTwo() //during syncing
    {
        foreach (var obj in _objectsToActivateTwo)
        {
            obj.SetActive(true);
        }

        foreach (var obj in _objectsToDeactivateOne)
        {
            obj.SetActive(false);
        }
    }
    
    public void ActivateObjectsThree() //during game
    {
        foreach (var obj in _objectsToActivateThree)
        {
            obj.SetActive(true);
            
        }
        foreach (var obj in _objectsToDeactivateTwo)
        {
            obj.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
