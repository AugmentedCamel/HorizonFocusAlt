using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassController : MonoBehaviour
{
    [SerializeField] private GameObject _compassCover;
    [SerializeField] private Vector3 _originalRot;
    [SerializeField] private Vector3 _targetRot;


    private void OnEnable()
    {
        _originalRot = _compassCover.transform.eulerAngles;
        
        StartCoroutine(OpeningCompass(2f));
        
    }

    private IEnumerator OpeningCompass(float duration)
    {
        float time = 0f;

        while (time < duration)
        {
            float lerpFac = time / duration;
            _compassCover.transform.eulerAngles = Vector3.Lerp(_originalRot, _targetRot, lerpFac);
            time += Time.deltaTime;
            yield return null;
        }

        _compassCover.transform.eulerAngles = _targetRot;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
