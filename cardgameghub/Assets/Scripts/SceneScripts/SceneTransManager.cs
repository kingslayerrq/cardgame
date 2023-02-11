using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using static RichardQ.GameManager;

namespace RichardQ{
    public class SceneTransManager : MonoBehaviour
    {

        public static SceneTransManager SMInstance;

        public int cur_sceneIndex;

        private void Awake()
        {
            GameManager.onStateChanged += GameManagerOnStateChanged;
            SceneManager.LoadSceneAsync("StartScene");



        }
        private void OnDestroy()
        {
            GameManager.onStateChanged -= GameManagerOnStateChanged;
        }


        private void GameManagerOnStateChanged(GameManager.GameState state)
        {
            
            switch (state)
            {
                case GameState.MenuState:
                    Debug.Log("firstscene");
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("StartScene"));
                    break;
                case GameState.MapState:

                    handleMapScene();
                    break;
                case GameState.PlayState:
                    handlePlayScene();
                    break;
                    
            }
            Debug.Log(state.ToString());
            
        }

        private void handlePlayScene()
        {
            Debug.Log("statechanged");
            SceneManager.SetActiveScene(SceneManager.GetSceneAt(2));
        }

        private void handleMapScene()
        {
            Debug.Log("statechanged");
            SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));
        }

       

        
        
        

        
    }
}


