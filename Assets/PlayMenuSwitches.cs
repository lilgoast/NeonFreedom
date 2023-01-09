using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayMenuSwitches : MonoBehaviour
{
    [SerializeField] GameObject levelsPanel;
    [SerializeField] int speed = 100;
    [SerializeField] GameObject LeftSwitchButton;
    [SerializeField] GameObject RightSwitchButton;
    
    
    private int firstLevelIndex, secondLevelIndex, thirdLevelIndex, rightLevelIndex, leftLevelIndex;
    private int levelAmount;
    private bool moveLeft, moveRight;

    List<GameObject> levels = new List<GameObject>();

    private Vector2 firstPos = new Vector2(-550, 0);
    private Vector2 secPos = new Vector2(0, 0);
    private Vector2 thirdPos = new Vector2(550, 0);
    private Vector2 leftPos = new Vector2(-1400, 0);
    private Vector2 rightPos = new Vector2(1400, 0);


    void Start()
    {
        levelAmount = levelsPanel.transform.childCount;

        for (int i = 0; i < levelAmount; i++)
        {
            levels.Add(levelsPanel.transform.GetChild(i).gameObject);
        }

        levels[0].transform.localPosition = firstPos;
        levels[1].transform.localPosition = secPos;
        levels[2].transform.localPosition = thirdPos;

        for (int i = 3; i < levelAmount; i++)
        {
            levels[i].transform.localPosition = rightPos;
            levels[i].SetActive(false);
        }

        firstLevelIndex = 0;
    }

    void Update()
    {   
        if(moveLeft)
        {
            var step = Time.deltaTime * speed;
            levels[firstLevelIndex].transform.localPosition = Vector2.MoveTowards(levels[firstLevelIndex].transform.localPosition, leftPos, step);
            levels[secondLevelIndex].transform.localPosition = Vector2.MoveTowards(levels[secondLevelIndex].transform.localPosition, firstPos, step);
            levels[thirdLevelIndex].transform.localPosition = Vector2.MoveTowards(levels[thirdLevelIndex].transform.localPosition, secPos, step);
            levels[rightLevelIndex].transform.localPosition = Vector2.MoveTowards(levels[rightLevelIndex].transform.localPosition, thirdPos, step);
            if(Vector2.Distance(levels[firstLevelIndex].transform.localPosition, leftPos) < 0.0001f)
            {
                moveLeft = false;
                levels[firstLevelIndex].SetActive(false);
                firstLevelIndex = secondLevelIndex;
                LeftSwitchButton.SetActive(true);
                RightSwitchButton.SetActive(true);
            }
        }        
        if(moveRight)
        {
            var step = Time.deltaTime * speed;
            levels[firstLevelIndex].transform.localPosition = Vector2.MoveTowards(levels[firstLevelIndex].transform.localPosition, secPos, step);
            levels[secondLevelIndex].transform.localPosition = Vector2.MoveTowards(levels[secondLevelIndex].transform.localPosition, thirdPos, step);
            levels[thirdLevelIndex].transform.localPosition = Vector2.MoveTowards(levels[thirdLevelIndex].transform.localPosition, rightPos, step);
            levels[leftLevelIndex].transform.localPosition = Vector2.MoveTowards(levels[leftLevelIndex].transform.localPosition, firstPos, step);
            
            if(Vector2.Distance(levels[thirdLevelIndex].transform.localPosition, rightPos) < 0.0001f)
            {
                moveRight = false;
                levels[thirdLevelIndex].SetActive(false);
                firstLevelIndex = leftLevelIndex;
                LeftSwitchButton.SetActive(true);
                RightSwitchButton.SetActive(true);
            }
        }
    }

    public void LeftSwitch()
    {
        LeftSwitchButton.SetActive(false);
        RightSwitchButton.SetActive(false);

        secondLevelIndex = firstLevelIndex + 1;
        if (secondLevelIndex > levelAmount - 1)
            secondLevelIndex = 0;

        thirdLevelIndex = secondLevelIndex + 1;
        if (thirdLevelIndex > levelAmount - 1)
            thirdLevelIndex = 0;

        rightLevelIndex = thirdLevelIndex + 1;
        if (rightLevelIndex > levelAmount - 1)
            rightLevelIndex = 0;

        levels[rightLevelIndex].transform.localPosition = rightPos;
        levels[rightLevelIndex].SetActive(true);
        moveLeft = true;
    }
    
    public void RightSwitch()
    {
        LeftSwitchButton.SetActive(false);
        RightSwitchButton.SetActive(false); 
        
        leftLevelIndex = firstLevelIndex - 1;
        if (leftLevelIndex < 0)
            leftLevelIndex = levelAmount - 1;

        secondLevelIndex = firstLevelIndex + 1;
        if (secondLevelIndex > levelAmount - 1)
            secondLevelIndex = 0;

        thirdLevelIndex = secondLevelIndex + 1;
        if (thirdLevelIndex > levelAmount - 1)
            thirdLevelIndex = 0;

        levels[leftLevelIndex].transform.localPosition = leftPos;
        levels[leftLevelIndex].SetActive(true);
        moveRight = true;
    }
}
