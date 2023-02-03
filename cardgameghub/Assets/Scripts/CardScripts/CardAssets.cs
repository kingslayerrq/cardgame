using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RichardQ{

    

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
        public Card.DmgType dmgType;
        public Card.Target target;
        public Card.CardType cardType;
        public string cardTitle = "";
        public string cardDescription = "";
        public Sprite artWork;
        


    }
}


