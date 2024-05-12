using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SyncronizeGame _syncronizeGame;
    [SerializeField] private ControllerDirection _controllerDirection;
    [SerializeField] private ControllerActive _controllerActive;
    [SerializeField] private TargetGenerator _targetGenerator;
    [SerializeField] private DesiredAngleController _desiredAngleController;
   
    [SerializeField] private SceneActivator _sceneActivator;
    [SerializeField] private PoleManager _poleManager;
    [SerializeField] private SignPostController _signPostController;
    [SerializeField] private IpadScreensManager _ipadScreensManager;
    [SerializeField] private TextMeshPro _totalScoreText;
    [SerializeField] private PassthroughController _passthroughController;
    [SerializeField] private VisualScoreController _visualScoreController;
    [SerializeField] private SFXLauncher _sfxLauncher;
    
    // Start is called before the first frame update
    public int totalScore = 0;
    public int turnCounter = 0;
    private bool _isCoordinated = false;
    private bool _isTurn = false;
    private float _correctAngle;
    private int _currentIndex;
    void Start()
    {
        
        //start with cordinating game
        //StartCoordinatingGame();
        //StartSyncGame();
    }
    
    
    public void StartCoordinatingGame() //happens after spawning of all MRUK objects
    {
        _isCoordinated = false;
        _controllerActive.DeactivateAllControllers();
        _sceneActivator.ActivateObjectsOne();
        Invoke("SetPoleActive", 2); //delay so that the all th scene objecst can spawn?
        _sfxLauncher.LaunchSoundStartScene();
        //activate the user input module 
        
    
    }

    private void SetPoleActive()
    {
        _poleManager.SetPoleActive();
        _sfxLauncher.LaunchSoundPoleSpawn();
    }
    
    public void OnGameCoordinated()
    {
        if (!_isCoordinated)
        {
            _sfxLauncher.LaunchSoundConfirmLocation();
            _isCoordinated = true;
            StartSyncGame();
            _ipadScreensManager.HideInterfaceScreen();
        }
        
        
    }
    private void StartSyncGame()
    {
        _sfxLauncher.LaunchSoundSyncControllerAppear();
        _syncronizeGame._syncronizingGame = true;
        _controllerActive.ChangeControllerToActive(0);
        _sceneActivator.ActivateObjectsTwo();
        
        _signPostController.SpawnSignPostAt(0, "NORTH");
        
    }
    
    public void OnSyncGame()
    {
        _sfxLauncher.LaunchSoundSyncNorth();
        _sfxLauncher.LaunchSoundSyncControllerDissapear();
        _controllerActive.ChangeControllerToActive(1);
        _signPostController.SaveCurrentSignPosts(0); //because north
        StartGame();
        
    }
    
    private void StartGame()
    {
        turnCounter = 1; // turn 0 is for syncing the north
        _sceneActivator.ActivateObjectsThree();
        Invoke("NewTurn", 2);
        
    }
    
    private void NewTurn()
    {
        _isTurn = true;
        _passthroughController.SetPasstroughToAimMode();
        //generating targets
        if (turnCounter < 4) // should have easy targets
        {
            float newTarget = _targetGenerator.GenerateTarget();
            string newTargetstring = _targetGenerator.currentTarget;
            
            //generating signposts
            _signPostController.SpawnSignPostAt(turnCounter, newTargetstring);
            _sfxLauncher.LaunchSoundSignPostEnter();
            //calculating the score:
            _desiredAngleController.SetTargetAngle(newTarget);
            
        }
        else if (turnCounter < 8) // should have medium targets
        {
            float newTarget = _targetGenerator.GenerateTargetCity();
            string newTargetstring = _targetGenerator.currentTarget;
            
            //generating signposts
            _signPostController.SpawnSignPostAt(turnCounter, newTargetstring);
            
            //get the screenindex
            _currentIndex = _targetGenerator.currentTargetIndex;
            
            //activate the horizon object
            _syncronizeGame.SetCityHorizonTarget(_currentIndex);
            
            //calculating the score:
            _desiredAngleController.SetTargetAngle(newTarget);
            
        }else //turncounter is over turns
        {
            if (totalScore < 500)
            {
                _sfxLauncher.LaunchSoundGameWon();
            }else
            {
                _sfxLauncher.LaunchSoundGameLost();
            }
            OnGameOver();
        }
        
        
        
        //spawn new signposts
    }
    
    public void OnPlayerShoot(float score)
    {
        if (!_isTurn)
        {
            return; //below can only be exectued if it is the players turn once
        }
        
        _passthroughController.ResetPassthroughAimMode();
        //if the player has shot at a city the ipad screen should change
        if (turnCounter > 3)
        {
            _ipadScreensManager.SetIpadScreen(_currentIndex);
            _syncronizeGame.SaveCityHorizonTarget((int)score);
            _sfxLauncher.LaunchSoundPlayerShootHard();
            
        }else
        {
            _sfxLauncher.LaunchSoundPlayerShootEasy();
        }
        
        
        
        turnCounter++;
        
        AddScore(score);
        
        if (score < 10f)
        {
            _sfxLauncher.LaunchSoundSuccesfullShot((int)score);
        }
        else
        {
            _sfxLauncher.LaunchSoundUnsuccesfullShot((int)score);
        }
        
        //should save the arrow 
        _signPostController.SaveCurrentSignPosts(score);
        //should spawn another correct arrow.
        
        //do something with turn counter
        //start newturn after seconds
        
        _isTurn = false;
        Invoke("NewTurn", 5);
    }
    
    private void AddScore(float score)
    {   
        int scoreaddition = (int)score;
        if (scoreaddition < 0)
        {
            scoreaddition -= (scoreaddition * 2); //inversing the negative number
        }
        
        totalScore += scoreaddition;
        
        _sfxLauncher.LaunchSoundScoreFeedback(totalScore);
        
        _visualScoreController.SetVisualScore(scoreaddition);
        
        _totalScoreText.text = ("Total Score: " + totalScore.ToString());
        
    }
    
    public void OnGameOver()
    {
        _isTurn = false;
        
        _totalScoreText.text = "GAME OVER";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
