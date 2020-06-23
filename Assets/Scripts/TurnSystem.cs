using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public bool isYourTurn;
    public Text turnText;

    public static int maxInterest;
    public static int currentInterest;
    public Text interestText;


    // Start is called before the first frame update
    void Start()
    {
        isYourTurn = true;

        maxInterest = 100;
        currentInterest = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (isYourTurn == true)
        {
            turnText.text = "This is your turn";
        }
        else
        {
            turnText.text = "This is not your turn, please wait";
        }

        interestText.text = currentInterest + "/" + maxInterest;
    }

    public void EndYourTurn()
    {
        isYourTurn = false;
        //pick one topic to change (with maybe option to pass this option)
        //discard all cards in hand
    }

    public void EndWaitTurn()
    {
        isYourTurn = true;
        //reset availability for topics
        //draw 5 new cards from deck
    }
}
