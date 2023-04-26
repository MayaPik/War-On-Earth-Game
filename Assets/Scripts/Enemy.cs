using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
   [SerializeField] GameObject deathVFX;
   [SerializeField] GameObject hitVFX;
   [SerializeField] int value;
   [SerializeField] int hitPoints = 4;
   ScoreBoard scoreBoard;
   GameObject parent;

  

   void Start() 
   {
      scoreBoard = FindObjectOfType<ScoreBoard>();
      parent = GameObject.FindWithTag("SpawnAtRunTime");
   }

   void OnParticleCollision(GameObject other)
   {
      ProcessHit();
      if (hitPoints < 1) {     
      KillEnemy();
      } 
   }

   private void KillEnemy()
   {
     
      GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
      vfx.transform.parent = parent.transform;
      Destroy(gameObject);
   }

   private void ProcessHit()
   {
      
      GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
      vfx.transform.parent = parent.transform;
      hitPoints --;
      if (hitPoints < 1) {
     
      scoreBoard.ModifyScore(value);
      } else {
         scoreBoard.ModifyScore(value/3);
      }
   }
}
