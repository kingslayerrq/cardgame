using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RichardQ{

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
        boss,
        all
    }

    [CreateAssetMenu(menuName = "ScriptableObjects/ Create CardAssets ")]
    public class CardAssets : ScriptableObject
    {
        [Header("Description")]
        [Space]
        [Tooltip("ID")]
        public int cardId;
        public int cardCost;
        public int dmgNum;
        public int healNum;
        public DmgType dmgType;
        public Target target;
        public CardType cardType;
        public string cardName = "";
        public string cardDescription = "";
        public Sprite artWork;
        


    }
}


