using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardManager : Singleton<CardManager> // handles card actions, card counts in draw/discard/hand pile
{
    [SerializeField]
    private GameObject CardPrefab;

    public int totalCardCount = 20;
    public int handCount = 7;
    public int drawPileCount = 13;
    public int discardPileCount = 0;

    public Card[] cardGroup; // all card in array

    public List<Card> cardToDraw; // cardlist use to draw

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
