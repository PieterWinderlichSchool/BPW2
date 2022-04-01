using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{

    [SerializeField]
    private ScoreManager scoreManager;
    [SerializeField]
    private int scoreValue;
    [SerializeField]
    private bool canPickup;
    public bool isPickedUp = false;
    private void OnTriggerEnter(Collider other)
    {
        if (canPickup)
        {
            if (other.name == "Player")
            {
                isPickedUp = true;
            }
        }
    }
    private void LateUpdate()
    {
        if (isPickedUp == true)
        {
            scoreManager.UpdateHighscore(scoreValue);
            Destroy(this.gameObject);
        }
    }
    public ScoreManager GetManager()
    {
        return scoreManager;
    }
    public void SetManager(ScoreManager newManager)
    {
        scoreManager = newManager;
    }
}
