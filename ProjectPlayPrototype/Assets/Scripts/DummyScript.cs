using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DummyScript : MonoBehaviour
{
    
    [SerializeField]
    private float health = 0;
    public delegate void CriticalDamage();

    public GameObject WallToClear;
    public GameObject NewDummyObject;
    public CriticalDamage _criticalDamage;
    public GameObject critPanel;
    bool SuperDeluxePremiumBoolEdition = false;
    

    public bool isPuzzleDummy = false;
    private void Update()
    {
        if (!isPuzzleDummy)
        {
            if (health <= 0)
            {
                Destroy(this.gameObject);
                Destroy(WallToClear);
            }
        }
        else
        {
            if (health == 0)
            {
                Destroy(WallToClear);
                Destroy(this.gameObject);
            }
            else if (health < 0)
            {
                if (!SuperDeluxePremiumBoolEdition)
                {
                    SpawnNewDummy();
                }
            }
        }
    }
    public void SpawnNewDummy()//Instantiates a new dummy and gives the current values of this object to the new dummy
    {
        SuperDeluxePremiumBoolEdition = true;
        GameObject newDummy = Instantiate(NewDummyObject, transform.position, Quaternion.identity);
        DummyScript newDummyDummyScript = newDummy.GetComponent<DummyScript>();
        newDummyDummyScript.WallToClear = WallToClear;
        newDummyDummyScript.NewDummyObject = NewDummyObject;
        newDummyDummyScript.critPanel = critPanel;
        PickupScript dummyPickup = newDummy.GetComponent<PickupScript>();
        PickupScript pickup = gameObject.GetComponent<PickupScript>();
        dummyPickup.SetManager(pickup.GetManager());
        pickup.isPickedUp = true;
    }
    public void TakeDamage(int damage)//takes damage and calculates if it was a critical strike, then returns the result
    {
        float random =  Mathf.Ceil(Random.Range(0,2));
        if (random == 1)
        {
            _criticalDamage();
            if (critPanel == null)
            {
                return;
            }
            else
            {
                critPanel.SetActive(true);
            }
            return;
        }
        health -= damage;
        if (critPanel)
        {
            critPanel.SetActive(false);
        }
    }
    public void TakeCritikalDamage(int critHit)//Takes critical damage according to what has been returned of the number that was slotted in the socket 
    {
        health -= critHit;
        if (!critPanel)
        {
            return;
        }
        else
        {
            critPanel.SetActive(false);
        }
    }
    public float GetHealth()
    {
        return health;
    }
}
