using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{

  public AudioMixer Main;

  public void start(){

  }

  public void changeVolume(float vol){
    Main.SetFloat("Volumes", vol);
  }


}
