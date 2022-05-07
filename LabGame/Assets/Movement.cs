using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    public static bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] bool isGrounded = true;
     Animator animator;

    [SerializeField] GameObject knifePrefab;


    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        speed = 15;

        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(movement));

        if (Input.GetButtonDown("Jump")){
            jumpPressed = true;
        }

        if(Input.GetButtonDown("Fire1")){
          Debug.Log("fire");
          shootKnife();
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8f, 3f), transform.position.y,
        transform.position.z);
    }

    public void shootKnife(){

      GameObject knife = Instantiate(knifePrefab) as GameObject;
      knife.transform.position = transform.position;

    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();
        if (jumpPressed && isGrounded)
          Jump();

    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        rigid.gravityScale = 1;
        isGrounded = false;
        jumpPressed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

}
