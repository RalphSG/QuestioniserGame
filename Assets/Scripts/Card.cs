using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card
{
    public int id;
    public string cardName;
    public int cost;
    public int type;
    public string effect;
    public string description;
    public Sprite thisImage;
    public int colorR;
    public int colorG;
    public int colorB;

    public int drawXCards;
    public int addXMaxInterest;
    public int discardXCards;

    public Card()
    {

    }

    public Card(int Id, string CardName, int Cost, int Type, string Effect, string Description, Sprite ThisImage, int ColorR, int ColorG, int ColorB, int DrawXCards, int AddXMaxInterest, int DiscardXCards)
    {
        id = Id;
        cardName = CardName;
        cost = Cost;
        type = Type;
        effect = Effect;
        description = Description;
        thisImage = ThisImage;
        colorR = ColorR;
        colorG = ColorG;
        colorB = ColorB;
        drawXCards = DrawXCards;
        addXMaxInterest = AddXMaxInterest;
        discardXCards = DiscardXCards;
    }

}
