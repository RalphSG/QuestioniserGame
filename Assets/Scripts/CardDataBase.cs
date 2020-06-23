using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    private void Awake()
    {
        cardList.Add(new Card(0, "Yes/No", 1, 1, "None", "This is for DaveMaster", Resources.Load<Sprite>("1"), 100, 255, 100, 0, 0, 0));
        cardList.Add(new Card(1, "Checkbox", 2, 2, "None", "This is for DaveMaster", Resources.Load<Sprite>("1"), 255, 100, 100, 0, 0, 0));
        cardList.Add(new Card(2, "Multiple Choice", 2, 2, "None", "This is for DaveMaster", Resources.Load<Sprite>("1"), 100, 100, 255, 0, 0, 0));
        cardList.Add(new Card(3, "Open-Ended", 3, 2, "None", "This is for DaveMaster", Resources.Load<Sprite>("1"), 255, 100, 255, 0, 0, 0));
        cardList.Add(new Card(4, "Meta Card1", 10, 3, "Draw 1 card and gain 2 interest", "This is for DaveMaster", Resources.Load<Sprite>("1"), 255, 255, 100, 5, 2, 0));
        cardList.Add(new Card(5, "Meta Card2", 10, 3, "Draw 2 cards and lose 3 interest", "This is for DaveMaster", Resources.Load<Sprite>("1"), 255, 255, 100, 5, -3, 0));
        cardList.Add(new Card(6, "Meta Card3", 10, 3, "Draw 4 cards", "This is for DaveMaster", Resources.Load<Sprite>("1"), 255, 255, 100, 5, 0, 0));
        cardList.Add(new Card(7, "Meta Card4", 10, 3, "Draw 3 cards", "This is for DaveMaster", Resources.Load<Sprite>("1"), 255, 255, 100, 5, 0, 0));

    }
}
