using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingBehaviour : MonoBehaviour
{
    
    
    
    [SerializeField]
    private DraggableUITypes draggableUIType = DraggableUITypes.Heart;
    [SerializeField]
    private GameObject SocketObject;

    


    private void OnTriggerStay(Collider other)
    {
        checkObject(other);
    }
    private void checkObject(Collider other)
    {
        if (other.gameObject.tag == "UISocket")
        {
            CheckObjectType(other);
        }
        
        
            
        
    }
    private void CheckObjectType(Collider other)
    {
        DraggableUIBehaviour draggableBehaviour = transform.GetComponentInParent<DraggableUIBehaviour>();
        
        DraggableUISocket socket = other.gameObject.GetComponent<DraggableUISocket>();
        if (socket)
        {
            if (socket.GetSocketType() == draggableUIType && !socket.GetisFilled())
            {
                SocketObject = other.gameObject;
                draggableBehaviour.SetSocket(SocketObject);
            }
            else
            {
                SocketObject = null;
            }
        }
        
    }
}
