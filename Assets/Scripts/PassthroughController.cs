using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class PassthroughController : MonoBehaviour
{
    
    [SerializeField] private OVRPassthroughLayer _passthroughLayer;
    
    
    private float _lerpDuration = 0.5f;
    private float _passthroughOpacityStart = 0.7f;
    private float _passthroughOpacityEnd = 0.08f;
    
    // Start is called before the first frame update
    void Start()
    {
        SetPasstroughToGameMode(_passthroughOpacityStart);
    }
    
    private void SetPasstroughToGameMode(float opacity)
    {
        _passthroughLayer.textureOpacity = opacity;
        
    }
    
    [Button]
    public void SetPasstroughToAimMode()
    {
        StartCoroutine(LerpOpacity(_passthroughOpacityStart, _passthroughOpacityEnd, _lerpDuration));
        
    }
    
    [Button]
    public void ResetPassthroughAimMode()
    {
        StartCoroutine(LerpOpacity(_passthroughOpacityEnd, _passthroughOpacityStart, _lerpDuration));
    }

    private IEnumerator LerpOpacity(float startOpacity, float endOpacity, float duration)
    {
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            _passthroughLayer.textureOpacity = Mathf.Lerp(startOpacity, endOpacity, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        _passthroughLayer.textureOpacity = endOpacity;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
