using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleToNorth : MonoBehaviour
{
    [SerializeField] private Transform _needle;
    [SerializeField] private Transform _north;
    
    public bool _isNeedleActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
            
    }
    
    public void ActivateNeedle()
    {
        _isNeedleActive = true;
    }
    
    // Update is called once per frame
    void Update()
    {
          if (_isNeedleActive)
          {
              _needle.LookAt(_north);
          }
    }
}
