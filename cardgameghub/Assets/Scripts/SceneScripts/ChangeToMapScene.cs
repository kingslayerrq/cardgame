using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RichardQ{
    public class ChangeToMapScene : MonoBehaviour
    {

        public void ToMapState()
        {
            //Debug.Log("clicked");
            GameManager.GMInstance.updateGameState(GameManager.GameState.MapState);
        }
        
        
    }
}


