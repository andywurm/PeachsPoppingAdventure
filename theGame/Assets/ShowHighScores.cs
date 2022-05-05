using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighScores : MonoBehaviour
{
   const int maxNum = 5;
   const string playerKey = "Player";
   const string scoreKey = "Score";

   [SerializeField] string playerName;
   [SerializeField] int playerScore;

   [SerializeField] Text[] playerTxts;

   // Start is called before the first frame update
   void Start()
   {
       playerName = PlayerInfo.playerName;
       playerScore = ScoreScript.scoreValue;

       SaveScore();
       ShowTheHighScores();
   }

   void SaveScore()
   {
       for (int i = 1; i <= maxNum; i++)
       {
           string currentPlayerKey = playerKey + i;
           string currentScoreKey = scoreKey + i;

           if (PlayerPrefs.HasKey(currentScoreKey))
           {
               int currentScore = PlayerPrefs.GetInt(currentScoreKey);
               if (playerScore > currentScore)
               {
                   int tempScore = currentScore;
                   string tempName = PlayerPrefs.GetString(currentPlayerKey);

                   PlayerPrefs.SetString(currentPlayerKey, playerName);
                   PlayerPrefs.SetInt(currentScoreKey, playerScore);

                   playerName = tempName;
                   playerScore = tempScore;
               }

           }
           else
           {
               PlayerPrefs.SetString(currentPlayerKey, playerName);
               PlayerPrefs.SetInt(currentScoreKey, playerScore);
               return;
           }
       }
   }

   void ShowTheHighScores()
   {
       for (int i = 0; i < maxNum; i++)
       {
         if(PlayerPrefs.GetInt(scoreKey + (i+1)) == 0){

         }
         else {
           playerTxts[i].text = PlayerPrefs.GetString(playerKey + (i+1)) + " " +  PlayerPrefs.GetInt(scoreKey + (i+1)).ToString();
         } 
       }

   }

}
