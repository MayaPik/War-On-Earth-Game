using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;
     [SerializeField] TMP_Text scoreText;
     [SerializeField] TMP_Text statusText;

   void Start() 
   {
     scoreText = GameObject.Find("ScoreBoard").GetComponent<TMP_Text>();
     statusText = GameObject.Find("StatusBoard").GetComponent<TMP_Text>();
     }
   public void ModifyScore(int value) 
   {
        score += value;
        scoreText.text = score.ToString();
   }

   public int GetScore() {
     return score;
   }
     public TMP_Text GetStatusText() 
    {
        return statusText;
    }

}
