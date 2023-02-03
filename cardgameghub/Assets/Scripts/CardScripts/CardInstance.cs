using RichardQ;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInstance : MonoBehaviour
{

    
    public int cardId;
    public int dmgNum;
    public int healNum;
    public int cardCost;
    public Card.CardType cardType;
    public Card.DmgType dmgType;
    public Card.Target target;
    public Sprite artWork;
    [SerializeField]
    private SpriteRenderer sRenderer;

    public string cardTitle;
    public string cardDescription;

    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        sRenderer.sprite = artWork;
    }
    public void loadCardData(CardAssets cardData)
    {
        cardId = cardData.cardId;
        cardType = cardData.cardType;
        dmgType = cardData.dmgType;
        target = cardData.target;
        cardCost = cardData.cardCost;
        dmgNum = cardData.dmgNum;
        healNum = cardData.healNum;
        cardTitle = cardData.cardTitle;
        cardDescription = cardData.cardDescription;
        artWork = cardData.artWork;
    }
}
