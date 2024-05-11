using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _targetText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        _targetText.text = "none";
        _scoreText.text = "-";
    }
    
    public void UpdateTargetText(string text)
    {
        _targetText.text = text;
        _scoreText.text = "";
    }
    
    public void UpdateScoreText(int score)
    {
        _scoreText.text = score.ToString();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
