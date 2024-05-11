using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class VisualScoreController : MonoBehaviour
{
    [SerializeField] GameObject _visualScoreObject;
    [SerializeField] TextMeshPro _totalScoreText;
    [SerializeField] TextMeshPro _lastScore;
    
    public UnityEvent OnGameOver;
    
    private Vector3 _initialPosition;
    private int _score = 0;
    
    
    public void SetVisualScore(int score)
    {
        
        _lastScore.text = score.ToString();
        IncreaseScore(score);
        
    }
    
    private void IncreaseScore(int lastscore) //score of 500 is game over
    {
        _score += lastscore;
        if (_score >= 500)
        {
            //clamp to end position
            _visualScoreObject.transform.localPosition = _initialPosition + new Vector3(0, 3, 0);
            Debug.Log("Game Over");
            _totalScoreText.text = "GAME OVER";
            OnGameOver.Invoke();
        }
        else
        {
            //map score from 0 to 500 to 0 to 3
            float normalizedScore = (float)_score / 500;
            float calculatedScore = Mathf.Lerp(0, 3, normalizedScore);
            
            
            _visualScoreObject.transform.localPosition = _initialPosition + new Vector3(0, calculatedScore, 0);
        }
        _totalScoreText.text = _score.ToString();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = _visualScoreObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
