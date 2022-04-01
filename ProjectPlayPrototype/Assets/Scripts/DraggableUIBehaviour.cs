using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class DraggableUIBehaviour : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float DistanceToCamera = 0;

    private GameObject originButton;
    private GameObject socket = null;
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = DistanceToCamera;
            transform.position = cam.ScreenToWorldPoint(mousePosition);
        }
        else
        {
            DragEnded();
        }
    }
    public void SetOrigin(GameObject origin)
    {
        originButton = origin;
    }
    public GameObject GetOrigin()
    {
        return originButton;
    }
    public void SetSocket(GameObject other)
    {
        socket = other;
    }
    public void DragEnded()
    {
        if (socket != null)
        {   
            socket.GetComponent<DraggableUISocket>().SetisFilled(true,this.gameObject);
            socket.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            Destroy(originButton);
        }
        Destroy(this.gameObject);
    }
}
