using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RichardQ{
    public class ChangeToPlayScene : MonoBehaviour
    {
       
        
        

        private void Update()
        {
            
        }
        private void OnMouseDown()
        {
            Debug.Log("play");
            GameManager.GMInstance.updateGameState(GameManager.GameState.PlayState);

        }

        
        
    }
}


