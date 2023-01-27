using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardListen : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler
{

    private float delay = 0.2f;

    private bool isDown = false;

    private float lastIsDownTime;

    private bool isOnCard = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData data){

    }
    public void OnPointerUp(PointerEventData data){

    }
    public void OnPointerExit(PointerEventData data){

    }
    public void OnPointerEnter(PointerEventData data){

    }
}
