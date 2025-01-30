using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float speed;

    float xInput;
    float yInput;
    bool jump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update(){
        if(transform.position.y < -5f){
            SceneManager.LoadScene("Game");
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        jump = Input.GetKeyDown(KeyCode.Space);

        rb.AddForce(xInput * speed, 0, yInput * speed);
        rb.velocity = new Vector3(xInput * speed, rb.velocity.y, yInput * speed);
        rb.AddForce(Vector3.down * 9.8f, ForceMode.Acceleration);

        if(jump){
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }
}
