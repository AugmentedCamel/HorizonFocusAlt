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
   
   
   // Play narration (from the centralized audio source)
   public void PlayNarrationClip(int clipIndex)
   {
      if (clipIndex < 0 || clipIndex >= _narrationClips.Length)
      {
         Debug.LogError("Clip index out of range.");
         return;
      }

      // Stop the current narration if it is playing
      if (_narrationSource.isPlaying)
      {
         _narrationSource.Stop();
      }

      _narrationSource.PlayOneShot(_narrationClips[clipIndex]);
   }
   
   
   public void ScoreFeedbackSound()
   {
      _sceneAudioSource.PlayOneShot(_scoreFeedback, 0.7f);  //  Score feedback to be integrated with ScoreManager?
   }

   public void ControllerTurnsClick()   // Further logic may be needed to connect to the game mechanics
   {
      _controllerSource.PlayOneShot(_controllerTurnClick, 0.45f);
   }

   public void GameWonSound()  // Indicates game has been won.
   {
      _sceneAudioSource.PlayOneShot(_gameWon, 0.6f);
   }
   
   public void GameLostSound()      // Indicates game has been lost.
   {
      _sceneAudioSource.PlayOneShot(_gameLost, 0.6f);
   }

   // Play a SFX from a specific GameObject

   public void PlayAmbientSound()  // Play ambient atmosphere sound 
   {
      _atmosphereSource.PlayOneShot(_ambientSound, 0.5f);
   }

   public void PoleSpawnSound()  // Pole spawn Sound
   {
      _poleSource.PlayOneShot(_poleSpawnClip, 0.7f);
   }

   public void ConfrimLocationSound()  //  Location confirmed sound.
   {
      _sceneAudioSource.PlayOneShot(_confirmLocationSound, .5f);
   }

   public void ControllerAppearSound()  // Controller appears
   {
      _controllerSource.PlayOneShot(_controllerAppear, 0.35f);
   }

   public void ControllerDisappearSound()  // Controller disappears
   {
      _controllerSource.PlayOneShot(_controllerDisappear, 0.25f);
   }
   
   
   public void NorthSyncSound() // North Sync sound
   {
      _northSource.PlayOneShot(_northSyncSound, 1f);
   }

   public void SignPostEnterSound()  // Sign post Enter
   {
      _signPostSource.PlayOneShot(_newTargetSound, 0.3f);
   }
   
   public void SignPostSwingSound()   //  Sign post Swing
   {
      _signPostSource.PlayOneShot(_swingSound, 0.3f);
   }

   public void GuessEasySound()  // Guess EASY
   {
      _sceneAudioSource.PlayOneShot(_guessEasySound, 0.5f);
   }
   
   public void GuessHardSound()   // Guess HARD
   {
      _sceneAudioSource.PlayOneShot(_guessHardSound, 0.5f);
   }

   public void SuccessSound()   // Success
   {
      _sceneAudioSource.PlayOneShot(_successfulShot, 0.5f);
   }
   
   public void UnsuccessSound()   // Unsuccessful
   {
      _sceneAudioSource.PlayOneShot(_unsuccessfulShot, 0.5f);
   }

   
}
   

