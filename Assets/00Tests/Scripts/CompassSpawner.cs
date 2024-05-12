using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class CompassSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _compassPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Button]
    void SpawnCompass()
    {
        var compass = Instantiate(_compassPrefab, this.transform.position, Quaternion.identity);
    }
}
