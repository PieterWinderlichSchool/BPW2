using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum DraggableUITypes {Heart, Energy, Score };
public class DraggableUISocket : MonoBehaviour
{
    public delegate void SocketActive();
    public SocketActive activateSocket;
    private GameObject objectThatFilled;
    [SerializeField]
   private DraggableUITypes draggableUIType = DraggableUITypes.Heart;

   private bool isFilled = false;
   
   public DraggableUITypes GetSocketType()
    {
        return draggableUIType ;
    }
   public void SetSocketType(DraggableUITypes newType)
   {
       draggableUIType = newType;
   }
   public bool GetisFilled()
    {
        return isFilled;
    }
    public void SetisFilled(bool newstatus, GameObject socketFiller)
    {
        isFilled = newstatus;
        
        if (isFilled == true)
        {
            objectThatFilled = socketFiller;
            if (activateSocket != null)
            {
                activateSocket();// Gives the signal that the socket is filled. this does not return WHAT has filled the socket.
            }
        }
    }
    public GameObject GetObjectThatFilled()
    {
        return objectThatFilled;
    }
}
