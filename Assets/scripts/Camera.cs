using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform target;  // The object to follow
    public Vector3 offset = new Vector3(0, 1, -10);  // Offset from the target
    public float smoothSpeed = 5f;  // Speed of camera movement
    // Start is called before the first frame update
    void LateUpdate(){
        if (target == null)
            return;
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target); // Make camera look at the target
    }
}
