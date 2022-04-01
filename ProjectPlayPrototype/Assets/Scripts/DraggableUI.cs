using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DraggableUI : MonoBehaviour,IPointerDownHandler
{   
    [SerializeField]
    private GameObject elementToSpawn;
    [SerializeField]
    private Camera cam;
    private GameObject activeUIElementInWorld;
    [SerializeField]
    private float draggableUIDistanceToCamera;
    void Start()
    {
        cam = Camera.main;
    }
    public void OnPointerDown(PointerEventData eventData)
   {
       
       Vector3 mousePosition = Input.mousePosition;
       mousePosition.z = draggableUIDistanceToCamera;

       GameObject draggedUI =  Instantiate(elementToSpawn,cam.ScreenToWorldPoint(mousePosition),transform.rotation) as GameObject;
       draggedUI.GetComponent<DraggableUIBehaviour>().SetOrigin(this.gameObject);
       activeUIElementInWorld = draggedUI;
   }

    public void SetElementToSpawn(GameObject newElement)
    {
        elementToSpawn = newElement;
    }
}
