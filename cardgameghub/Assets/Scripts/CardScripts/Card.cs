using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card 



{
    public enum CardType
    {
        cardAtk,
        cardHeal,
        cardCurse
        
    }

    public enum DmgType
    {
        weapon,
        physical,
        stamina,
        magic

    }
    public enum Target
    {
        self,
        ranknfile,
        boss
    }

    public int cardId;
    public int cardCost;
    public int dmgNum;
    public int healNum;
    public DmgType dmgType;
    public Target target;
    public CardType cardType;
    public string cardName = "";
    public string cardDescription = "";
    public int imageIndex = 0; // card image 



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
