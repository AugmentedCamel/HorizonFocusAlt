using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class PoleManager : MonoBehaviour
{
    private Vector3 _spawnPosition;
    
    private bool _alreadySpawned = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    [Button]
    public void SetPoleActive()
    {
        //find a nice spawnposition
        if (!_alreadySpawned)
        {
            try {_spawnPosition = FindObjectOfType<SpawnPostion>().transform.position;}
            catch { Debug.Log("no spawn position found"); _spawnPosition = new Vector3(0, 0, 0); }
            transform.position = _spawnPosition;
            _alreadySpawned = true;
        }
        else
        {
            _spawnPosition = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
