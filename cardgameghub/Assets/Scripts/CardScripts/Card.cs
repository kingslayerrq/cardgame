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
        magic,
        none

    }
    public enum Target
    {
        self,
        ranknfile,
        boss,
        enemy,
        all
    }

    public int cardId;
    public int cardCost;
    public int dmgNum;
    public int healNum;
    public DmgType dmgType;
    public Target target;
    public CardType cardType;
    public string cardTitle = "";
    public string cardDescription = "";
    



    
}
