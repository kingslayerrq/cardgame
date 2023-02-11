using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RichardQ{
    public class ChangeToPlayScene : MonoBehaviour
    {
        private Scene curScene;
        
        

        private void Update()
        {
            
        }
        private void OnMouseDown()
        {
            // on clicking the roomnode, go to playstate
            GameManager.GMInstance.updateGameState(GameManager.GameState.PlayState);
            
            //curScene = SceneManager.GetActiveScene();
            
            
            
        }

        
        
    }
}


