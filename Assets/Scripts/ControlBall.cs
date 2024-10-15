using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBall : MonoBehaviour
{


  private bool isGrounded = true;
  private Rigidbody rb;
  public Transform cameraTransform;
  public Vector3 jump;
  public float jumpForce = 4.0f;
  public float speed;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
    jump = new Vector3(0.0f, 2.0f, 0.0f);
  }

  void Update() //Not FixedUpdate() since it's very bad working with "GetButtonDown"
  {
        MovementLogic();
  }
    

  private void MovementLogic()
  {
        //player move
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //camera moving with player and normalising, so when you press "W" - player will go forward to the camera view
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }

        forward.y = 0f;
        right.y = 0f;


        forward.Normalize();
        right.Normalize();
        Vector3 direction = forward * vertical + right * horizontal;
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
  }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    void OnCollisionExit()
    {
        isGrounded = false;
    }
}
