using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SyncronizeGame : MonoBehaviour
{
    public bool _syncronizingGame = false;
    public bool _isAiming = false;
    [SerializeField] private GameNorth _gameNorth;
    [SerializeField] private ControllerDirection _controllerDirection;
    [SerializeField] private GameObject _horizonFocusTarget;
    public UnityEvent OnSyncGame;
    
    [SerializeField] private List<GameObject> _cityHorizonTargets;
    private GameObject _currentCityHorizonTarget;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var VARIABLE in _cityHorizonTargets)
        {
            VARIABLE.SetActive(false);
        
        }
    }
    public void SetNorthRotation(float angle)
    {
        if (_syncronizingGame)
        {
            _gameNorth.gameObject.transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
    
    public void SetAimHorizonFocus(float angle)
    {
        if (!_syncronizingGame)
        {
            _horizonFocusTarget.transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
    
    private void UpdateAimHorizonTarget(float angle)
    {
        if (_currentCityHorizonTarget != null)
        {
            _currentCityHorizonTarget.transform.rotation = Quaternion.Euler(0, angle, 0);
        }

    }
    
    public void SetCityHorizonTarget(int index)
    {
        if (index < _cityHorizonTargets.Count)
        {
            _currentCityHorizonTarget = _cityHorizonTargets[index];
            _currentCityHorizonTarget.SetActive(true);
            _isAiming = true;
        }
        
    }
    
    public void SaveCityHorizonTarget(int score)
    {
        if (_currentCityHorizonTarget != null)
        {
            _isAiming = false;
            ChangeRotationToActualScore(score);
            _currentCityHorizonTarget = null;
            
        }
        
    }
    
    private void ChangeRotationToActualScore(int score)
    {
        float currentY = _currentCityHorizonTarget.transform.rotation.eulerAngles.y;
        _currentCityHorizonTarget.transform.rotation = Quaternion.Euler(0,  (currentY + score), 0);
    }
    
    public void SaveNorthDirection()
    {
        if (_syncronizingGame)
        {
            _syncronizingGame = false;
            OnSyncGame.Invoke();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_syncronizingGame)
        {
            if (_controllerDirection != null)
            {
                SetNorthRotation(_controllerDirection.controllerDirectionYAngle);
                SetAimHorizonFocus(_controllerDirection.controllerDirectionYAngle);
            }

        }
        
        if (_isAiming)
        {
            if (_controllerDirection != null)
            {
                UpdateAimHorizonTarget(_controllerDirection.controllerDirectionYAngle);
            }
        }
        
        
    }
}
