using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
  public GameObject prevMusic;

  void Start()
  {
      prevMusic = GameObject.Find("WinMusic");

  }

  public void playAgain(){
    Destroy(prevMusic);
    ScoreScript.currentScore = 0;
    ScoreScript.scoreValue = 0;
    ScoreScript.currentLevel = 1;
    SceneManager.LoadScene(0);
  }

}
