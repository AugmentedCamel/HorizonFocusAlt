using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SignPost : MonoBehaviour
{
    
    
    [SerializeField] private List<TextMeshPro> _signPostTexts;
    [SerializeField] private ControllerDirection _controllerDirection;

    

    [SerializeField] private GameObject _CorrectArrow;
    [SerializeField] private GameObject _ShotArrow;
    
    private bool _AimingAt;
    // Start is called before the first frame update
    public bool _isSaved;
    
    public void ActivateSignPost(GameObject aim, string text) //used for the correct arrow
    {
        
        _AimingAt = aim;
        SetNewText(text);
        
        _isSaved = false;
    }

    private void SetNewText(string signText)
    {
        foreach (var signPostText in _signPostTexts)
        {
            signPostText.text = signText;
        }
        
    }
    
    public void StartAimSignPost(string text)
    {
        gameObject.SetActive(true);
        _AimingAt = true;
        _isSaved = false;
        SetNewText(text);
        
    }
    
    public void SetText(string text)
    {
        SetNewText(text);
    }
    
    public void AimPosition(GameObject obj)
    {
        _AimingAt = obj;
    }

    private void ActivateCorrectArrow(float angle)
    {
        //the angle here is the score of the shot, so the correct angle is the actual angle of the arrow - the score
        
        if (_CorrectArrow != null)
        {
            _CorrectArrow.SetActive(true);
            //_ShotArrow.SetActive(false);
            _CorrectArrow.transform.localRotation = Quaternion.Euler(0, angle, 0);
        }
    }
    
    public void Save(float correctLocalAngle) 
    {
        _isSaved = true;
        
        ActivateCorrectArrow(correctLocalAngle);
        //should activate the correct arrow later
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!_isSaved && _AimingAt)
        {
            transform.rotation = Quaternion.Euler(0, _controllerDirection.controllerDirectionYAngle, 0);
            
        }
    }
}
