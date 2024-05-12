using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
   // Singleton instance
   public static AudioManager instance;

   // Dedicated AudioSource for narration
   private AudioSource _narrationSource;

   // Struct to hold sound clips with their names
   [Serializable]
   public class SoundClip
   {
      public string name;
      public AudioClip clip;
   }

   // Audio clips for SFX, Narration, and UI sounds
   public SoundClip[] sfxClips;
   public SoundClip[] narrationClips;
   public SoundClip[] uiClips;

   void Awake()
   {
      // Ensure there is only one instance of AudioManager
      if (instance == null)
      {
         instance = this;
         DontDestroyOnLoad(gameObject);
      }
      else
      {
         Destroy(gameObject);
      }

      // Initialize the narration audio source
      _narrationSource = gameObject.AddComponent<AudioSource>();
      _narrationSource.loop = false;  // Narration typically doesn't loop
   }

   // Play a SFX from a specific GameObject
   public void PlaySFX(string name, GameObject sourceObject)
   {
      AudioSource source = sourceObject.GetComponent<AudioSource>();
      if (source == null)
      {
         source = sourceObject.AddComponent<AudioSource>();
      }

      AudioClip clip = FindClip(name, sfxClips);
      if (clip != null)
      {
         source.PlayOneShot(clip);
      }
   }
   
   // Play a UI sound from a specific GameObject
   public void PlayUISound(string name, GameObject sourceObject)
   {
      AudioSource source = sourceObject.GetComponent<AudioSource>();
      if (source == null)
      {
         source = sourceObject.AddComponent<AudioSource>();
      }

      AudioClip clip = FindClip(name, uiClips);
      if (clip != null)
      {
         source.PlayOneShot(clip);
      }
   }

   // Play narration (from the centralized audio source)
   public void PlayNarration(string name)
   {
      AudioClip clip = FindClip(name, narrationClips);
      if (clip != null)
      {
         _narrationSource.clip = clip;
         _narrationSource.Play();
      }
   }

   // Find an AudioClip by name from the specified array
   private AudioClip FindClip(string name, SoundClip[] clips)
   {
      foreach (SoundClip sc in clips)
      {
         if (sc.name == name)
         {
            return sc.clip;
         }
      }
      Debug.LogWarning("Sound clip not found: " + name);
      return null;
   }
}
   

