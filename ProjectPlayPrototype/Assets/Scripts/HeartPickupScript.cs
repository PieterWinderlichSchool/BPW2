using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickupScript : MonoBehaviour
{
    [SerializeField]
    private Heartmanager HeartManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            HeartManager.AddnewHeart();
            Destroy(this.gameObject);
        }
    }
    public Heartmanager GetHeartManager()
    {
        return HeartManager;
    }
    public void SetHeartManager(Heartmanager newheartManager)
    {
        HeartManager = newheartManager;
    }
}
