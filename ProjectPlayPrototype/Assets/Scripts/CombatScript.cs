using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CombatScript : MonoBehaviour
{
    public DummyScript Enemy;
    public int damage;
    public GameObject socket;
    public Sprite newSprite;
    private bool isInRange = false;
    [SerializeField] private GameObject currentSocket;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            DealDamage();
        }

        if (Input.GetKeyDown("r"))
        {
            ResumeGame();
        }
    }
    public void DealDamage()//deals normal damage
    {
        if (isInRange)
        {
            Enemy.TakeDamage(damage); 
        }
    }
    public void DealDamage(int critModifier) //deals damage with a critical strike
    {
        if (isInRange)
        {
            Enemy.TakeCritikalDamage(damage * critModifier);
        }
    }
    public void CritikalStrike()// Creates a socket for the player to drag a number into
    {
        
        if (currentSocket == null)
        {
            GameObject newSocket = Instantiate(socket,
                new Vector3(Enemy.gameObject.transform.position.x + 1f, Enemy.gameObject.transform.position.y + 1f,
                    Enemy.gameObject.transform.position.z), Enemy.gameObject.transform.rotation);
            newSocket.GetComponent<DraggableUISocket>().SetSocketType(DraggableUITypes.Score);
            newSocket.GetComponentInChildren<SpriteRenderer>().sprite = newSprite;
            newSocket.GetComponent<MeshRenderer>().enabled = false;
            newSocket.GetComponent<DraggableUISocket>().activateSocket += CritikalStrikeActivated;
            newSocket.name = "critSocket";
            currentSocket = newSocket;
        }
        else
        {
            return;
        }
    }

    private void CritikalStrikeActivated()//if the socket is filled,function finds damage according to number that was given. 
    {
        
        if (currentSocket == null)
        {
            Debug.Log("Socket does not exist");
            return;
        }
        switch (currentSocket.GetComponent<DraggableUISocket>().GetObjectThatFilled().GetComponent<NumericalValue>().numericalValue)
        {
            case 0:
                DealDamage(0);
                break;
            case 1:
                DealDamage(1);
                break;
            case 2:
                DealDamage(2);
                break;
            case 3:
                DealDamage(3);
                break;
            case 4:
                DealDamage(4);
                break;
            case 5:
                DealDamage(5);
                break;
            case 6:
                DealDamage(6);
                break;
            case 7:
                DealDamage(7);
                break;
            case 8:
                DealDamage(8);
                break;
            case 9:
                DealDamage(9);
                break;
            default:
                Debug.Log(currentSocket.GetComponent<DraggableUISocket>().GetObjectThatFilled().name);
                Debug.Log("Could not find that anywhere");
                break;
        }
        ResumeGame();
    }
    private void ResumeGame()//Resumes game after a critical strike
    {
        
        if (currentSocket == null)
        {
            return;
        }
        Destroy(currentSocket);
        if (Enemy.critPanel)
        {
            Enemy.critPanel.SetActive(false);
        }
        else
        {
            return;
        }
        
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.GetComponent<DummyScript>())
        {   Enemy._criticalDamage += CritikalStrike;
            Enemy = other.gameObject.GetComponent<DummyScript>();
            isInRange = true;
        }
    }
    public bool GetBool()
    {
        return isInRange;
    }
    public void SetBool(bool newBool)
    {
        isInRange = newBool;
    }
}
