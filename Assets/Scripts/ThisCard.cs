using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public int id;
    public string cardName;
    public int cost;
    public int type;
    public string effect;
    public string description;
    public Sprite thisSprite;
    public Image thisImage;
    public int colorR;
    public int colorG;
    public int colorB;

    public Text nameText;
    public Text costText;
    public Text descriptionText;
    public Text effectText;

    public Image frame;

    //public bool cardBack;
    public static bool staticCardBack;

    public GameObject Hand;
    public int nCardsInDeck;

    public GameObject DeckPanel;

    public bool canBeUsed;
    public bool used;
    public GameObject TopicZone;

    public static int drawX;
    public static int discardX;
    public int drawXCards;
    public int discardXCards;
    public int addXMaxInterest;

    // Start is called before the first frame update
    void Start()
    {
        DeckPanel = GameObject.Find("DeckPanel");
        thisCard[0] = CardDataBase.cardList[thisId];
        nCardsInDeck = Deck.nCards;

        canBeUsed = false;
        used = false;

        drawX = 0;
        discardX = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Hand = GameObject.Find("Hand");
        if (this.transform.parent == DeckPanel.transform)//Hand.transform)
        {
            staticCardBack = true;
            //cardBack = false;
            //staticCardBack = false;
        }
        else
        {
            staticCardBack = false;
            //staticCardBack = true;
        }


        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cost = thisCard[0].cost;
        type = thisCard[0].type;
        effect = thisCard[0].effect;
        description = thisCard[0].description;
        thisSprite = thisCard[0].thisImage;
        colorR = thisCard[0].colorR;
        colorG = thisCard[0].colorG;
        colorB = thisCard[0].colorB;

        // EFFECTS
        drawXCards = thisCard[0].drawXCards;
        discardXCards = thisCard[0].discardXCards;
        addXMaxInterest = thisCard[0].addXMaxInterest;


        nameText.text = "" + cardName;
        costText.text = "" + cost;
        descriptionText.text = "" + description;
        effectText.text = "" + effect;

        thisImage.sprite = thisSprite;

        frame.GetComponent<Image>().color = new Color32(System.Convert.ToByte(colorR), System.Convert.ToByte(colorG), System.Convert.ToByte(colorB), 255);

        //staticCardBack = cardBack;

        if (this.tag == "CloneHand")
        {
            if (nCardsInDeck > 0)
            {
                thisCard[0] = Deck.staticDeck[nCardsInDeck - 1];
                nCardsInDeck -= 1;
                Deck.nCards -= 1;
                staticCardBack = false; //cardBack = false;
                this.tag = "Untagged";
            }
        }

        if (TurnSystem.currentInterest >= cost && used == false)
        {
            canBeUsed = true;
        }
        else
        {
            canBeUsed = false;
        }

        if (canBeUsed == true && staticCardBack == false)
        {
            gameObject.GetComponent<Draggable>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Draggable>().enabled = false;
        }

        TopicZone = GameObject.Find("TopicZone");

        if (used == false && this.transform.parent == TopicZone.transform)
        {
            Use();
        }
    }

    public void Use()
    {
        TurnSystem.currentInterest -= cost;
        used = true;

        MaxInterest(addXMaxInterest);
        drawX = drawXCards;
    }

    public void MaxInterest(int x)
    {
        TurnSystem.maxInterest += x;
    }
}
