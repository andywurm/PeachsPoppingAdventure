using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{


  [SerializeField] GameObject thePauseMenu;
  public GameObject theMusic;

  void Start()
  {
      theMusic = GameObject.Find("LevelMusic");

  }

    public void Paused(){
      thePauseMenu.SetActive(true);
      Time.timeScale = 0f;
      Time.timeScale = 0f;
    }

    public void Resume(){
      thePauseMenu.SetActive(false);
      Time.timeScale = 1f;
    }

    public void MainMenu (){
      Time.timeScale = 1f;
      Destroy(theMusic);
      SceneManager.LoadScene(0);
    }
}
