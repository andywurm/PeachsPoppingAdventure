using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePin : MonoBehaviour
{

    private Vector3 startPosition;
    private Rigidbody2D knife;


    // Start is called before the first frame update
    void Start()
    {
      startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        var temp = transform.position;

        // if(Movement.isFacingRight == false || MovementFinal.isFacingRight == false){
        //   temp.x += -0.1f;
        // } else{
          temp.x += 0.1f;


        transform.position=temp;

    }

    void OnBecameInvisible() {
         Destroy(gameObject);
     }
}
