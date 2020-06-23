using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> deckContainer = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();

    public int x;

    public static int nCards;
    public int nItemN;
    public int nItemS;
    public int nMeta;

    public GameObject deckIndicator1;
    public GameObject deckIndicator2;
    public GameObject deckIndicator3;
    public GameObject deckIndicator4;
    public GameObject deckIndicator5;

    public GameObject CardToHand;
    public GameObject CardBack;
    public GameObject DeckObject;

    public GameObject[] Clones;

    public GameObject Hand;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        nCards = 27;

        for (int i = 0; i < nCards; i++)
        {
            if (i < nItemN)
            {
                //x = Random.Range(start of the normal Item cards, end of the normal Item cards);
                deck[i] = CardDataBase.cardList[0];
            }
            else if (i < nItemN + nItemS)
            {
                x = Random.Range(1, 4);
                deck[i] = CardDataBase.cardList[x];
            }
            else if (i < nItemN + nItemS + nMeta)
            {
                x = Random.Range(4, 8);
                deck[i] = CardDataBase.cardList[x];
            }
        }

        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {
        staticDeck = deck;

        if (nCards < 1)
        {
            deckIndicator1.SetActive(false);
        }
        if (nCards < 5)
        {
            deckIndicator2.SetActive(false);
        }
        if (nCards < 10)
        {
            deckIndicator3.SetActive(false);
        }
        if (nCards < 15)
        {
            deckIndicator4.SetActive(false);
        }
        if (nCards < 20)
        {
            deckIndicator5.SetActive(false);
        }

        if(ThisCard.drawX > 0)
        {
            StartCoroutine(Draw(ThisCard.drawX));
            ThisCard.drawX = 0;
        }
    }

    IEnumerator KillClone()
    {
        yield return new WaitForSeconds(1);
        Clones = GameObject.FindGameObjectsWithTag("Clone");
        foreach (GameObject Clone in Clones)
        {
            Destroy(Clone);
        }
    }

    IEnumerator StartGame()
    {
        Shuffle();
        for (int i = 0; i <= 4; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

    public void Shuffle()
    {
        for (int i = 0; i < nCards; i++)
        {
            deckContainer[0] = deck[i];
            int randomIdex = Random.Range(i, nCards);
            deck[i] = deck[randomIdex];
            deck[randomIdex] = deckContainer[0];
        }

        Instantiate(CardBack, transform.position, transform.rotation);
        StartCoroutine(KillClone());
    }

    IEnumerator Draw(int x)
    {
        for (int i = 1; i < x; i++)
        {
            if (nCards <= 0)
            {
                //END THE GAME
                break;
            }
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }
}
