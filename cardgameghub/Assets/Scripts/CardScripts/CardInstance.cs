using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInstance : MonoBehaviour
{

    public Image image;
    public Sprite[] img; // card background
    public int cardId;
    public int imageIndex;
    public int dmgNum;
    public Card.CardType cardType;
    public Card.DmgType dmgType;
    public Card.Target target;
    public Card card; // confirm this card

    public Text cardTitle;
    public Text cardDescription;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
