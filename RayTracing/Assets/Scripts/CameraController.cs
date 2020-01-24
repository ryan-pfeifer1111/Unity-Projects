using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float horiz_input;
    private float vert_input;

    private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horiz_input = Input.GetAxis("Horizontal");
        //vert_input = Input.GetAxis("Vertical");

        //Debug.Log("horiz_input: " + horiz_input);
        //Debug.Log("vert_input: " + vert_input);

        this.gameObject.transform.Rotate(Vector3.up, speed * horiz_input, Space.World);
        //this.gameObject.transform.Rotate(Vector3.right, -speed * vert_input, Space.World);
    }
}
