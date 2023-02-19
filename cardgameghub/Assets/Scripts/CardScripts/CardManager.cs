using Mono.Cecil;
using RichardQ;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static RichardQ.PlayState;

public class CardManager : MonoBehaviour // handles card actions, card counts in draw/discard/hand pile
{
    [SerializeField]
    private GameObject CardPrefab;
    // slots for hand
    [SerializeField]
    private List<Transform> cardSlots;
    public Canvas canvas; // canvas where cards spawn on
    

    [Tooltip("Current battle card info")]
    public CardAssets[] cardArr; // all card in array
    public List<CardAssets> handList; // hand card in array
    public List<CardAssets> cardDiscarded; // discard pile
    public List<CardAssets> cardToDraw; // cardlist use to draw
    public List<CardInstance> cardInstanceList; // cardInstance list
    


    private void Awake()
    {
        // subscribe to playstate substate change event
        PlayState.onPlayStateSubChange += handlePlayStateSubChange;
        cardArr = new CardAssets[2];
        // load all cards into array
        for (int i = 0; i < 2; i++)
        {
            cardArr[i] = Resources.Load<CardAssets>("Cards/" + i.ToString());
            
        }

        // hardcode out initial hand [for now]
        // not instantiating cards
        handList = new List<CardAssets> { cardArr[0], cardArr[0], cardArr[0], cardArr[0], cardArr[0]};
        cardToDraw = new List<CardAssets> { cardArr[1], cardArr[1], cardArr[1], cardArr[1], cardArr[1]};
    }

    // unsubscribe from onSubStateChange event
    private void OnDestroy()
    {
        PlayState.onPlayStateSubChange -= handlePlayStateSubChange;
    }

    private void Start()
    {
        handCardDisplay();
    }

    private void Update()
    {
        // keeping track of curHandSize
        int curHandSize = handList.Count;
        
    }

    // onSubStateChange subscribed method
    private void handlePlayStateSubChange(PlayState.SubState subState)
    {
        switch(subState)
        {
            case PlayState.SubState.DrawState:
                handleDrawState();
                break;
            case PlayState.SubState.PlayerState:
                handlePlayerState();
                break;
            case PlayState.SubState.PlayerEndingState:
                break;
            case PlayState.SubState.EnemyState:
                break;
        }
    }

    private void handlePlayerState()
    {
        Debug.Log("playerState!");

    }

    private void handleDrawState()
    {
        Debug.Log("drawState!");
        drawCards(2);
        GameManager.GMInstance.updateSubState(SubState.PlayerState);
    }

    // draw cards to hand
    public void drawCards(int drawNum)
    {
        // check if there is enough card to draw
        // or do we need to put the card from discard pile to draw pile
        if (cardToDraw.Count >= drawNum )
        {
            for (int i = 0; i <  drawNum; i++)
            {
                // randomly choose a card from draw pile
                CardAssets drawCard = cardToDraw[UnityEngine.Random.Range(0, cardToDraw.Count)];
                if (handList.Count == 10)
                {
                    // if exceeds hand limits, draw card goes into discard pile
                    cardDiscarded.Add(drawCard);
                }
                else
                {
                    // add to hand
                    handList.Add(drawCard);
                }
                
            }
        }
        else
        {
            // shuffle discard pile into draw pile
            foreach (var dc in cardDiscarded)
            {
                cardToDraw.Add(dc);
            }
            cardDiscarded.Clear();
            drawCards(drawNum);
        }
        handCardDisplay();
    }

    // display the current hand
    public void handCardDisplay()
    {
        // instantiate hand card prefabs
        for (int i = 0; i < handList.Count; i++)
        {
            CardInstance handCard = Instantiate(CardPrefab, canvas.transform).GetComponent<CardInstance>();
            cardInstanceList.Add(handCard);
            handCard.transform.position = cardSlots[i].transform.position;
            // change the scale
            handCard.transform.localScale = new Vector3(0.9f, 1.2f);
            // add some rotation
            handCard.transform.Rotate(0f, 0f, 6f);
            handCard.loadCardData(handList[i]);
            
        }

    }

    // update cardSlot after init, each card drawn/discarded/used
    public void fitCards()
    {

    }

    
    
}
