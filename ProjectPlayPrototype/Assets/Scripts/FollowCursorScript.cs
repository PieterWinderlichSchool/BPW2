using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Cryptography;
using UnityEngine;

public class FollowCursorScript : MonoBehaviour
{
    [SerializeField]
    private bool isAlive = false;
    [SerializeField]
    private float DistanceToCamera = 0;
    private Camera cam;
    [SerializeField]
    private DraggableUISocket Socket;
    [SerializeField]
    private float moveTowardsSpeed;
    [SerializeField]
    private GameObject HeartToSpawn;

    private Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        cam = Camera.main;
        Socket.activateSocket += SetAlive;
    }
    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            Vector3 mousePosition = Input.mousePosition;
            
            mousePosition.z = DistanceToCamera;
            //transform.position = new Vector3(cam.ScreenToWorldPoint(mousePosition).x,0.5f,cam.ScreenToWorldPoint(mousePosition).z);
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(cam.ScreenToWorldPoint(mousePosition).x, 0.5f, cam.ScreenToWorldPoint(mousePosition).z),
                moveTowardsSpeed);
        }
    }
    public void SetAlive()
    {
        body.constraints = RigidbodyConstraints.None;
        body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                           RigidbodyConstraints.FreezeRotationZ;
        isAlive = true;
    }
    public void KILL()
    {
        Socket.GetComponent<DraggableUISocket>().SetisFilled(false,null);
        Socket.GetComponentInChildren<SpriteRenderer>().color = Color.black;
        body.constraints = RigidbodyConstraints.FreezeAll;
        isAlive = !isAlive;
        if (HeartToSpawn)
        {
            GameObject heart =  Instantiate(HeartToSpawn, new Vector3(transform.position.x,transform.position.y,transform.position.z-1f), Quaternion.identity);
            heart.AddComponent(typeof(Rigidbody));
            heart.AddComponent(typeof(BoxCollider));
            heart.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-4f),ForceMode.Impulse);
            heart.GetComponent<HeartPickupScript>().SetHeartManager(FindObjectOfType<Heartmanager>());
        }
    }
}
