using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    
    public List<GameObject> draggableUIPrefabs;
    public List<GameObject> scoreObjectList;
    [SerializeField]
    private List<int> digits = new List<int>(); 
    public GameObject scoreObject;
    [SerializeField]
    private int highscore = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        CheckforEmpty();
    }

    public void CheckforEmpty() //Checks if an item is empty in the UI lists and updates UI positions accordingly
    {
        for (int i = 0; i < scoreObjectList.Count; i++)
        {
            if (scoreObjectList[i] == null)
            {
                digits.Clear();
                string highscorenumbers = highscore.ToString();
                for (int c = 0; c < highscorenumbers.Length;c++)
                {
                    char character = highscorenumbers[c];
                    digits.Add((int)Char.GetNumericValue(character));
                }
                
                digits.Remove(digits[i]);
                highscore = 0;
                foreach (int entry in digits)
                {
                    highscore = 10 * highscore + entry;
                }
                int tempIndex = 0;
                foreach (GameObject item in scoreObjectList)
                {
                    if (tempIndex < i && item != null)
                    {
                        item.GetComponent<RectTransform>().anchoredPosition = new Vector2(item.GetComponent<RectTransform>().anchoredPosition.x + 20- tempIndex ,item.GetComponent<RectTransform>().anchoredPosition.y);
                        tempIndex++;
                    }
                }
                scoreObjectList.Remove(scoreObjectList[i]);
                UpdateUI(); 
            }
        }
    }
    private void UpdateUI() //Updates the UI. Will re-call itself whenever a new element of UI is Added
    {
        digits.Clear();
        string highscorenumbers = highscore.ToString();
         if (highscorenumbers.Length > scoreObjectList.Count)
         {
             GameObject newScoreObject = Instantiate(scoreObject,this.transform, scoreObject.GetComponent<RectTransform>());
             scoreObjectList.Insert(0,newScoreObject);
           newScoreObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
           newScoreObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
           newScoreObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(100, 0);
             for (int i = 0; i < scoreObjectList.Count - 1; i++)
             {  
                 newScoreObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(newScoreObject.GetComponent<RectTransform>().anchoredPosition.x - 20,newScoreObject.GetComponent<RectTransform>().anchoredPosition.y);
             }
             UpdateUI();
             return; 
         }
         for (int i = 0; i < highscorenumbers.Length; i++)
         {
             char character = highscorenumbers[i];
             scoreObjectList[i].GetComponentInChildren<Text>().text = character.ToString() ;
             digits.Add((int)Char.GetNumericValue(character));
         }
         for (int i = 0; i < scoreObjectList.Count; i++)
         {
             scoreObjectList[i].GetComponent<DraggableUI>().SetElementToSpawn(draggableUIPrefabs[digits[i]]);
         }
    }
    public void UpdateHighscore(int score)
    {
        highscore += score;
        UpdateUI();
    }
}
