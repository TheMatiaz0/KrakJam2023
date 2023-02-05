using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
   [SerializeField] private AudioSource musicSource;
   
   private void Start()
   {
      HpEntity.OnPlayerDied += OnPlayerDied;
   }

   private void OnDestroy()
   {
      HpEntity.OnPlayerDied -= OnPlayerDied;
   }

   private void OnPlayerDied()
   {
      musicSource.Stop();
   }
}
