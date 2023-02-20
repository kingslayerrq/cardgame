using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RichardQ{
    public class test : MonoBehaviour,IPointerClickHandler, IPointerDownHandler
    {
    
        void Start()
        {
            
        }

    
        void Update()
        {
            
        }

        private void OnMouseDown()
        {
            Debug.Log("down");
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("click");
            
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("DOWN");
            
        }
    }
}


