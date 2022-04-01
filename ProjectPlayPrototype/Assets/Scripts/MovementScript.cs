using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;

    private float newRot;
   
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(horizontal * speed, 0, vertical * speed) * Time.deltaTime;
        //Vector3 newRot = new Vector3(0, horizontal * rotationSpeed * 10f, 0)* Time.deltaTime;
        //transform.RotateAround(transform.localPosition, transform.up, newRot.y) ;
    }
}
