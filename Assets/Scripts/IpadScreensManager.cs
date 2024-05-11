using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IpadScreensManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> _ipadScreens;
    [SerializeField] private SpriteRenderer _ipadScreenRenderer;
    [SerializeField] private GameObject _interfaceScreen;
    // Start is called before the first frame update
    void Start()
    {
        _ipadScreenRenderer.enabled = false;
    }
    
    public void SetIpadScreen(int index)
    {
        _ipadScreenRenderer.enabled = true;
        
        if (_ipadScreens.Count > index)
        {
            _ipadScreenRenderer.sprite = _ipadScreens[index];
        }
    }
    
    public void HideIpadScreen()
    {
        _ipadScreenRenderer.enabled = false;
        _interfaceScreen.SetActive(true);
    }
    
    public void HideInterfaceScreen()
    {
        _interfaceScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
