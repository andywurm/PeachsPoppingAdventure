using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{

    public GameObject prevMusic;
    private static LevelMusic instance = null;

    public static LevelMusic Instance
    {
        get { return instance; }
    }

    void Start()
    {
        prevMusic = GameObject.Find("TitleMusic");
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
