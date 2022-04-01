using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{

    public float distanceFromPressurePlate;
    public GameObject wallToDestroy;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("UISocket"))
        {   
            
            other.gameObject.transform.position = new Vector3(transform.position.x,transform.position.y + distanceFromPressurePlate,transform.position.z);
            Destroy(other.GetComponent<DraggableUISocket>());
            other.gameObject.GetComponent<FollowCursorScript>().KILL();
            if (wallToDestroy)
            {
                Destroy(wallToDestroy);
                
            }
            Destroy(this);
        }
    }

   
}
