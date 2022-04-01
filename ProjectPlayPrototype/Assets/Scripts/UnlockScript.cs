using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockScript : MonoBehaviour
{
    [SerializeField]
    private GameObject SocketOBJ;

    private DraggableUISocket Socket;
    
    // Start is called before the first frame update
    void Start()
    {
        Socket = SocketOBJ.GetComponent<DraggableUISocket>();
        Socket.activateSocket += UnlockDoor;
    }
    private void UnlockDoor()
    {
        while (transform.position.x < 20f)
        {
           transform.position = Vector3.Lerp(transform.position, new Vector3(20f, 0, 0), 20f);
        }
    }
}
