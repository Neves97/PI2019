using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{
    private Transform thisObj;
    public float rotSpeed = 1.0f;
    Rigidbody rb;
    
    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.S)) {

            rb.AddTorque(0, 0, rotSpeed);
        }

    }

}