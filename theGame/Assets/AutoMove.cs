using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    private Vector3 startPosition, scaleChange, maxSize;
    bool up = true;
    [SerializeField] AudioSource pop;
    private GameObject boo;
    public int scoreCalc = 100;

    void Start ()
      {
        startPosition = transform.position;

        if (pop == null)
        {
            pop = GetComponent<AudioSource>();
        }

        if(boo == null){
          boo = GameObject.Find("boo");
        }
        scaleChange = new Vector3(0.02f, .03f, 0.001f);
        maxSize = new Vector3(0.9f, .09f, 0.001f);
        InvokeRepeating("balloonGrow", 2f, 3f);

      }

      // Update is called once per frame
      void Update ()
      {
        MoveVertical ();
      }

      void MoveVertical()
      {
        var temp = transform.position;
        print (up);
        if(up == true)
        {
            temp.y += 0.03f;
            transform.position=temp;

            if(transform.position.y >= 3f)
            {
                up = false;
            }
        }
        if(up == false)
        {
            temp.y -= 0.03f;
            transform.position=temp;

            if(transform.position.y<=-3f)
            {
                up = true;
            }
        }
      }

      private void OnTriggerEnter2D (Collider2D collider)
    {
        ScoreScript.scoreValue += scoreCalc;
        // ScoreScript.currentScore+= scoreCalc;
        Debug.Log("Boo hit");
        AudioSource.PlayClipAtPoint(pop.clip, transform.position);
        Destroy(gameObject);
        ScoreScript.currentLevel += 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    void balloonGrow () {

      if(boo.transform.localScale.x >= .9f || boo.transform.localScale.y >= .9f ){
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
      } else{
        scoreCalc -= 5;
        boo.transform.localScale += scaleChange;
      }


    }

}
