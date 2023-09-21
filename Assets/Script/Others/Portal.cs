using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
   [SerializeField] bool lastLevel;
   void Start()
   {
      
   }
   void OnTriggerEnter2D(Collider2D other)
   {
      if(other.CompareTag("Player"))
      {
         if(lastLevel)
         {
            LevelManager.instance.LoadLevel("Main Menu");
            return;
         }
         LevelManager.instance.LoadNextLevel();
      }
   }
}
