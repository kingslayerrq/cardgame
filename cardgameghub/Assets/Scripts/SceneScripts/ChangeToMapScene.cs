using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RichardQ{
    public class ChangeToMapScene : MonoBehaviour
    {

        private void OnMouseDown()
        {
            GameManager.GMInstance.updateGameState(GameManager.GameState.MapState);

        }
    }
}


