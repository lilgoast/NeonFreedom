using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSwitches : MonoBehaviour
{
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject optionsButton;
    [SerializeField] GameObject achivmentsButton;
    [SerializeField] GameObject quitButton;

    public float buttonMoveSpeed = 1.0f;

    private List<RectTransform> buttons = new List<RectTransform>();
    private int currentButtonIndex = 0;
    private int nextButtonIndex;
    private bool moveLeft, moveRight;
    private Vector3 leftPosition, rightPosition, centerPosition;

    private void Awake()
    {
        buttons.Add(playButton.GetComponent<RectTransform>());
        buttons.Add(optionsButton.GetComponent<RectTransform>());
        buttons.Add(achivmentsButton.GetComponent<RectTransform>());
        buttons.Add(quitButton.GetComponent<RectTransform>());

        leftPosition = new Vector3(-88550, -480, -80315);
        rightPosition = new Vector3(90000, -480, 84445);
        centerPosition = new Vector3(725, -480, 2065);
    }

    private void Start()
    {
        foreach(var button in buttons)
        {
            button.anchoredPosition3D = rightPosition;
        }

        buttons[currentButtonIndex].anchoredPosition3D = centerPosition;
    }

    private void Update()
    {
        if(moveLeft)
        {
            var step = buttonMoveSpeed * Time.deltaTime * 10000;
            buttons[currentButtonIndex].anchoredPosition3D = Vector3.MoveTowards(buttons[currentButtonIndex].anchoredPosition3D, leftPosition, step);
            buttons[nextButtonIndex].anchoredPosition3D = Vector3.MoveTowards(buttons[nextButtonIndex].anchoredPosition3D, centerPosition, step);
            if (Vector3.Distance(buttons[nextButtonIndex].anchoredPosition3D, centerPosition) < 0.0001f)
            {
                moveLeft = false;
                currentButtonIndex = nextButtonIndex;
            }
        }
        else if(moveRight)
        {
            var step = buttonMoveSpeed * Time.deltaTime * 10000;
            buttons[currentButtonIndex].anchoredPosition3D = Vector3.MoveTowards(buttons[currentButtonIndex].anchoredPosition3D, rightPosition, step);
            buttons[nextButtonIndex].anchoredPosition3D = Vector3.MoveTowards(buttons[nextButtonIndex].anchoredPosition3D, centerPosition, step);
            if (Vector3.Distance(buttons[nextButtonIndex].anchoredPosition3D, centerPosition) < 0.0001f)
            {
                moveRight = false;
                currentButtonIndex = nextButtonIndex;
            }
        }
    }

    public void LeftSwitch()
    {
        moveLeft = true;
        nextButtonIndex = currentButtonIndex + 1;
        if(nextButtonIndex >= buttons.Count)
        {
            nextButtonIndex = 0;
        }
        buttons[nextButtonIndex].anchoredPosition3D = rightPosition;
    }

    public void RightSwitch()
    {
        moveRight = true;
        nextButtonIndex = currentButtonIndex - 1;
        if (nextButtonIndex < 0)
        {
            nextButtonIndex = buttons.Count - 1;
        }
        buttons[nextButtonIndex].anchoredPosition3D = leftPosition;
    }
}
