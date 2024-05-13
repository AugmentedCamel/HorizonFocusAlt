using System.Collections;
using System.Collections.Generic;
using Meta.WitAi.Attributes;
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
    [SerializeField] private DialogueEventManager _dialogueEventManager;
    [SerializeField] private DictationActivationCustom _dictationActivationCustom;
    
    [SerializeField] private GameObject _horizonFocusTarget;
    
    [SerializeField] private TMP_Text _totalSoreText;
    [SerializeField] private TMP_Text _roundScoreText;
    
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
        _controllerActive.ChangeControllerToActive(0); //closed compass
        _sceneActivator.ActivateObjectsOne();
        Invoke("SetPoleActive", 2); //delay so that the all th scene objecst can spawn?
        _sfxLauncher.LaunchSoundStartScene();
        
        //activate the user input module 
        
    
    }

    private void SetPoleActive()
    {
        _poleManager.SetPoleActive();
        _sfxLauncher.LaunchSoundPoleSpawn();
        _dialogueEventManager.OnStartOfGame();
        Invoke("ListenToUserInputAfterTime", 10);
        
    }

    private void ListenToUserInputAfterTime()
    {
        _dictationActivationCustom.ToggleActivation(); //set on
        Debug.Log("listening to user input");
    }
    
    public void OnSuccesfullCoordinatesEntry()
    {
        //should continue the game and 
        Debug.Log("succesfull entry");
        _dictationActivationCustom.ToggleActivation(); //set off
        OnGameCoordinated();
    }
    
    public void OnFailedCoordinatesEntry()
    {
        if (_isCoordinated)
        {
            return; //should only be executed if the game is not coordinated yet
        }
        _dictationActivationCustom.ToggleActivation(); //set offf
        //should ask to retry
        _dialogueEventManager.OnInputCityRetry();
        Invoke("ListenToUserInputAfterTime", 5f); 
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
        _controllerActive.ChangeControllerToActive(1); //controller sync
        _sfxLauncher.LaunchSoundSyncControllerAppear();
        _dialogueEventManager.OnGrabPhone();
        _syncronizeGame._syncronizingGame = true;
        
        _sceneActivator.ActivateObjectsTwo();
        
        _signPostController.SpawnSignPostAt(0, "NORTH");
        
        //start listening to voice input
        
    }
    
    public void OnSyncGame()
    {
        _sfxLauncher.LaunchSoundSyncNorth();
        _sfxLauncher.LaunchSoundSyncControllerDissapear();
        _dialogueEventManager.OnNorthSynchronized();
        _controllerActive.ChangeControllerToActive(2); //controller aim
        _signPostController.SaveCurrentSignPosts(0); //because north
        StartGame();
        
    }
    
    private void StartGame()
    {
        turnCounter = 1; // turn 0 is for syncing the north
        _sceneActivator.ActivateObjectsThree();
        _horizonFocusTarget.SetActive(true);
        Invoke("NewTurn", 16); //this will wait for narration event to explain game
        
    }
    
    private void NewTurn()
    {
        _isTurn = true;
        _passthroughController.SetPasstroughToAimMode();
        //generating targets
        if (turnCounter == 1) //first turn shoul dask west 
        {
            _dialogueEventManager.OnStartWarmingUp();
            //get west target
            float newTarget = _targetGenerator.GenerateTargetWest();
            string newTargetstring = _targetGenerator.currentTarget;
            
            _signPostController.SpawnSignPostAt(turnCounter, newTargetstring);
            _sfxLauncher.LaunchSoundSignPostEnter();
            //calculating the score:
            _desiredAngleController.SetTargetAngle(newTarget);
        }
        else if(turnCounter == 2) //second turn should ask east
        {
            _dialogueEventManager.OnArrowEast();
            float newTarget = _targetGenerator.GenerateTargetEast();
            string newTargetstring = _targetGenerator.currentTarget;
            
            _signPostController.SpawnSignPostAt(turnCounter, newTargetstring);
            _sfxLauncher.LaunchSoundSignPostEnter();
            //calculating the score:
            _desiredAngleController.SetTargetAngle(newTarget);
            //get east target
        }
        else if(turnCounter < 4) // should have easy targets
        {
            float newTarget = _targetGenerator.GenerateTarget();
            string newTargetstring = _targetGenerator.currentTarget;
            
            //generating signposts
            _signPostController.SpawnSignPostAt(turnCounter, newTargetstring);
            _sfxLauncher.LaunchSoundSignPostEnter();
            //calculating the score:
            _desiredAngleController.SetTargetAngle(newTarget);
            
        }
        else if (turnCounter == 4) //should introduce cities
        {
            _horizonFocusTarget.SetActive(false);
            _dialogueEventManager.OnBeginCities();
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
                _dialogueEventManager.OnGameWon();
                _sfxLauncher.LaunchSoundGameWon();
            }else
            {
                _sfxLauncher.LaunchSoundGameLost();
                _dialogueEventManager.OnGameLost();
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
            _dialogueEventManager.OnFeedbackPositive();
        }
        else
        {
            _sfxLauncher.LaunchSoundUnsuccesfullShot((int)score);
            _dialogueEventManager.OnFeedbackNegative();
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
        
        
        
        _roundScoreText.text = (scoreaddition.ToString());
        _totalSoreText.text = (totalScore.ToString());
        
        
        
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
