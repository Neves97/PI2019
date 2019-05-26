using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleShoot : MonoBehaviour
{

    public GameObject bullet;
    public Transform point;
    public float force;
// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Tiro") ){
            var clone = Instantiate(bullet, point.position,point.rotation);
           clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * force);

        }
    }
}
