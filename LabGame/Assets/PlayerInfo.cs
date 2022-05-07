using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    public static string playerName;

    // Start is called before the first frame update
    void Start()
    {
         playerName = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetName(string s)
   {
       playerName = s;
   }

  
}
