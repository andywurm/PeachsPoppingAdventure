using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMusic : MonoBehaviour
{
      public GameObject prevMusic;
      private static WinMusic instance = null;

      public static WinMusic Instance
      {
          get { return instance; }
      }

      void Start()
      {
          prevMusic = GameObject.Find("LevelMusic");
          Destroy(prevMusic);
      }

      void Awake()
      {
          if (instance != null && instance != this) {
              Destroy(this.gameObject);
              return;
          } else {
              instance = this;
          }
          DontDestroyOnLoad(this.gameObject);
      }
}
