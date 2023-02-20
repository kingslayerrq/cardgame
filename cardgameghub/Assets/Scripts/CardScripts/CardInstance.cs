using RichardQ;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardInstance : MonoBehaviour, CardListen
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

    private Canvas canvas;
    private CanvasGroup canvasGroup;

    private bool isDown = false;
    // make sure onyl one active event triggers at one time
    private static GameObject activeCard = null;
    // default renderScale for cards
    public Vector3 cardRenderScale = new Vector3(0.9f, 1.2f);
    // initial cardPosition
    private Vector3 curCardInitPos;
    // the difference between cardPosition and mouseOnDragPosition
    private Vector3 dragDifference;
    // original cardSortingLayerName
    private string originalSortingLayer = "CardOriginal";
    // lifted cardSortingLayerName
    private string liftedSortingLayer = "CardLifted";

    private void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        canvasGroup = canvas.GetComponent<CanvasGroup>();

    }
    private void Update()
    {
        
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

        
        
        
       
    }

    

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        
        // record initial position to snap back
        curCardInitPos = transform.position;
        dragDifference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - curCardInitPos;
        
        
        
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // snaps back to initial position
        transform.position = curCardInitPos;
        // update everything back if the card is not dealt
        activeCard = null;
        transform.localScale = cardRenderScale;
        bringCardToBack();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("draggin");
        // record curMousePosition
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // maintain the difference between object and dragPostion
        transform.position = mousePos - dragDifference;
        
        
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (activeCard == null)
        {    
            activeCard = gameObject;
            bringCardToFront();
            transform.localScale = new Vector3(2f, 3f);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (activeCard == gameObject)
        {
            
            activeCard = null;
            bringCardToBack();
            transform.localScale = cardRenderScale;
        }
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {


    }


    public void OnPointerUp(PointerEventData eventData)
    {

    }

    public void bringCardToFront()
    {
        // override SortingLayer
        canvas.overrideSorting = true;
        canvas.sortingOrder += 1;
        
    }
    public void bringCardToBack()
    {
        canvas.sortingOrder -= 1;
        // deoverride SortingLayer
        canvas.overrideSorting = false;
        
    }
}
