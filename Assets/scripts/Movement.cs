using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, z * moveSpeed);

         if (Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        Renderer renderer = GetComponent<Renderer>();
        print("Grounded");
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        Renderer renderer = GetComponent<Renderer>();
        print("Not Grounded");
    }
}
