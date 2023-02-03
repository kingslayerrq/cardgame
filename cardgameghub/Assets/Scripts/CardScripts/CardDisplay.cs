using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RichardQ{
    public class CardDisplay : MonoBehaviour
    {
        // ScriptableObject CardAssets
        [SerializeField]
        private CardAssets card;

        [SerializeField]
        private int cardId;
        [SerializeField]
        private int cardCost;
        [SerializeField]
        private int dmgNum;
        [SerializeField]
        private int healNum;
        [SerializeField]
        private Card.DmgType dmgType;
        [SerializeField]
        private Card.Target target;
        [SerializeField]
        private Card.CardType cardType;
        [SerializeField]
        private string cardTitle;
        [SerializeField] 
        private string cardDescription;
        [SerializeField]
        private SpriteRenderer sRenderer;
    
        void Start()
        {
            cardId = card.cardId;
            cardCost = card.cardCost;
            dmgNum= card.dmgNum;
            healNum= card.healNum;
            dmgType = card.dmgType;
            target = card.target;
            cardType = card.cardType;
            cardTitle = card.cardTitle;
            cardDescription = card.cardDescription;
            sRenderer.sprite = card.artWork;

        }

    
        void Update()
        {
            
        }
    }
}


