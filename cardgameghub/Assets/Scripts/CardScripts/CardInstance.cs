using RichardQ;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardInstance : MonoBehaviour, CardListen, IPointerDownHandler
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
    [SerializeField]
    private UnityEngine.UI.Image img;

    public string cardTitle;
    public string cardDescription;

    private void Start()
    {
        //sRenderer = GetComponent<SpriteRenderer>();
        //sRenderer.sprite = artWork;
        
        
    }

    // load the data on to each card prefab
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
        img = GetComponent<Image>();
        img.sprite = cardData.artWork;
        

    }

    

    

    public void moveCard(CardInstance curCard)
    {
        Transform origin = this.transform;
        // get mouse pos
        Vector3 inputPos = Input.mousePosition;
        Vector3 difference = origin.position - inputPos;
        // update card pos
        this.transform.position += difference;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("down1");
        
    }
}
