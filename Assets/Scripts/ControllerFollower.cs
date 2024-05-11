using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerFollower : MonoBehaviour
{
    [SerializeField] private Transform _controller;
    
    [SerializeField] private GameObject _SycronizeGameController;
    
    // Start is called before the first frame update
    void Start()
    {
        ActivateSyncronizeGame();
    }
    
    public void ActivateSyncronizeGame()
    {
        if (_SycronizeGameController != null)
        {
            _SycronizeGameController.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Transform controller = _controller;
        if (controller != null)
        {
            transform.position = controller.position;
            transform.rotation = controller.rotation;
        }
    }
}
