using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructButton : MonoBehaviour
{
  public void Instruct(){
    SceneManager.LoadScene(4);
  }
}
