using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMusic : MonoBehaviour
{

   private static TitleMusic instance = null;
   
   public static TitleMusic Instance
   {
       get { return instance; }
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
