using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class AudioManager : MonoBehaviour
{
   // Singleton instance
   public static AudioManager instance;
   
   [Header("SCENE AUDIO")]
   [SerializeField] private AudioSource _atmosphereSource;  // 2D audio atmosphere
   [SerializeField] private AudioClip _ambientSound;
   
   [SerializeField] private AudioSource _sceneAudioSource;
   [SerializeField] private AudioClip _confirmLocationSound;
   [SerializeField] private AudioClip _guessEasySound;
   [SerializeField] private AudioClip _guessHardSound;
   [SerializeField] private AudioClip _successfulShot;
   [SerializeField] private AudioClip _unsuccessfulShot;
   [SerializeField] private AudioClip _scoreFeedback;
   [SerializeField] private AudioClip _gameLost;
   [SerializeField] private AudioClip _gameWon;
   
   [Space]
   [Header("POLE")]
   [SerializeField] private AudioSource _poleSource;
   [SerializeField] AudioClip _poleSpawnClip;
   [Space]
   [Header("KEYBOARD")]
   [SerializeField] private AudioSource _vKeyboardSource;
   [SerializeField] private AudioClip _vKeyboardAppear;
   [SerializeField] private AudioClip _vKeyboardType;
   [SerializeField] private AudioClip _vKeyboardDisappear;
   [Space]
   [Header("CONTROLLER")]
   [SerializeField] private AudioSource _controllerSource;
   [SerializeField] private AudioClip _controllerAppear;
   [SerializeField] private AudioClip _controllerDisappear;
   [SerializeField] private AudioClip _buttonPressSound;
   [SerializeField] private AudioClip _controllerTurnClick;
   [Space]
   [Header("NORTH")]
   [SerializeField] private AudioSource _northSource;
   [SerializeField] private AudioClip _northSyncSound;
   [Space]
   [Header("SIGN POST")]
   [SerializeField] private AudioSource _signPostSource;
   [SerializeField] private AudioClip _newTargetSound;
   [SerializeField] private AudioClip _swingSound;
   [Space]
   [Header("NARRATION")]
   // Dedicated AudioSource for narration
   [SerializeField] private AudioSource _narrationSource;
   [SerializeField] AudioClip[] _narrationClips;  // Audio clips for Narration
   
   
   public void ScoreFeedbackSound()
   {
      _sceneAudioSource.PlayOneShot(_scoreFeedback);  //  Score feedback to be integrated with ScoreManager?
   }

   public void ControllerTurnsClick()   // Further logic may be needed to connect to the game mechanics
   {
      _controllerSource.PlayOneShot(_controllerTurnClick);
   }

   public void GameWonSound()  // Indicates game has been won.
   {
      _sceneAudioSource.PlayOneShot(_gameWon);
   }
   
   public void GameLostSound()      // Indicates game has been lost.
   {
      _sceneAudioSource.PlayOneShot(_gameLost);
   }

   // Play a SFX from a specific GameObject

   public void PlayAmbientSound()  // Play ambient atmosphere sound 
   {
      _atmosphereSource.PlayOneShot(_ambientSound);
   }

   public void PoleSpawnSound()  // Pole spawn Sound
   {
      _poleSource.PlayOneShot(_poleSpawnClip);
   }

   public void ConfrimLocationSound()  //  Location confirmed sound.
   {
      _sceneAudioSource.PlayOneShot(_confirmLocationSound);
   }

   public void ControllerAppearSound()  // Controller appears
   {
      _controllerSource.PlayOneShot(_controllerAppear);
   }

   public void ControllerDisappearSound()  // Controller disappears
   {
      _controllerSource.PlayOneShot(_controllerDisappear);
   }
   
   public void KeyboardAppearSound()  // Keyboard appears
   {
      _vKeyboardSource.PlayOneShot(_vKeyboardAppear);
   }
   
   public void KeyboardTypeSound()  // keyboard typing
   {
      _vKeyboardSource.PlayOneShot(_vKeyboardType);
   }
   
   public void KeyboardDisappearSound() // Keyboard disappears
   {
      _vKeyboardSource.PlayOneShot(_vKeyboardDisappear);
   }

   public void NorthSyncSound() // North Sync sound
   {
      _northSource.PlayOneShot(_northSyncSound);
   }

   public void SignPostEnterSound()  // Sign post Enter
   {
      _signPostSource.PlayOneShot(_newTargetSound);
   }
   
   public void SignPostSwingSound()   //  Sign post Swing
   {
      _signPostSource.PlayOneShot(_swingSound);
   }

   public void GuessEasySound()  // Guess EASY
   {
      _sceneAudioSource.PlayOneShot(_guessEasySound);
   }
   
   public void GuessHardSound()   // Guess HARD
   {
      _sceneAudioSource.PlayOneShot(_guessHardSound);
   }

   public void SuccessSound()   // Success
   {
      _sceneAudioSource.PlayOneShot(_successfulShot);
   }
   
   public void UnsuccessSound()   // Unsuccessful
   {
      _sceneAudioSource.PlayOneShot(_unsuccessfulShot);
   }
   
   
   
   

   // Play narration (from the centralized audio source)
  

   // Find an AudioClip by name from the specified array
  
}
   

