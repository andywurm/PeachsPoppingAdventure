using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove3 : MonoBehaviour
{
  private Vector3 startPosition;
  [SerializeField] AudioSource pop;
  private GameObject boo;
  public int scoreCalc = 100;
  public GameObject playerPeach;
  public float fleeDistance = 10.0f;
  bool up = true;

  void Start ()
    {
      startPosition = transform.position;

      if (pop == null)
      {
          pop = GetComponent<AudioSource>();
      }

      if(playerPeach == null){
        playerPeach = GameObject.Find("ppeach");
      }

      if(boo == null){
        boo = GameObject.Find("boo");
      }

      ScoreScript.currentScore*= 0;
      InvokeRepeating("keepTrackOfTime", 1f, 1f);

    }

    // Update is called once per frame
    void Update ()
    {

      transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8f, 3f), transform.position.y,
      transform.position.z);

      float distance = Vector3.Distance(transform.position, playerPeach.transform.position);
      // Debug.Log("Distance: " + distance);

      if(distance < fleeDistance){

        var temp = transform.position;

        if(playerPeach.transform.position.x >= transform.position.x){
          temp.x -= 0.1f;
          transform.position=temp;
        }

        if(playerPeach.transform.position.x <= transform.position.x){
          temp.x += 0.1f;
          transform.position=temp;
        }

      }

       MoveVertical();
    }

    void MoveVertical()
    {
      var temp = transform.position;
      print (up);
      if(up == true)
      {
          temp.y += 0.08f;
          transform.position=temp;

          if(transform.position.y >= 3f)
          {
              up = false;
          }
      }
      if(up == false)
      {
          temp.y -= 0.08f;
          transform.position=temp;

          if(transform.position.y<=-3f)
          {
              up = true;
          }
      }
    }

    void keepTrackOfTime(){
        if(scoreCalc == 0){
          UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        } else {
          scoreCalc -= 5;
        }
    }

    private void OnTriggerEnter2D (Collider2D collider)
  {
      ScoreScript.scoreValue += scoreCalc;
      ScoreScript.currentScore += scoreCalc;
      Debug.Log("Boo hit");
      AudioSource.PlayClipAtPoint(pop.clip, transform.position);
      Destroy(gameObject);
      UnityEngine.SceneManagement.SceneManager.LoadScene(5);
  }


}
