using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthToData : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private DummyScript script;



    void Update()
    {
        image.fillAmount = script.GetHealth() / 100;
    }
}
