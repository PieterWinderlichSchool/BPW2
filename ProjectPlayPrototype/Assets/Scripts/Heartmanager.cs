using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartmanager : MonoBehaviour
{

    public List<GameObject> heartObjects = new List<GameObject>();
    public GameObject heartObject;
    public void AddnewHeart()
    {
        for (int i = 0; i < heartObjects.Count; i++)
        {
            if(heartObjects[i] == null){
                GameObject newHeartObject = Instantiate(heartObject,this.transform, heartObject.GetComponent<RectTransform>());
                
                newHeartObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                newHeartObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
                newHeartObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(25, 0);
                newHeartObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                    newHeartObject.GetComponent<RectTransform>().anchoredPosition.x + (50 * i),
                    newHeartObject.GetComponent<RectTransform>().anchoredPosition.y);
                heartObjects[i] = newHeartObject;
            }
        }
    }
}

