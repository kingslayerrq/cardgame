using RichardQ;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnMouseDown()
    {
        // trigger gamestate change to PlayState
        GameManager.GMInstance.updateGameState(GameManager.GameState.PlayState);

        //SceneLoader.SLInstance.LoadPlayScene();
    }
}
