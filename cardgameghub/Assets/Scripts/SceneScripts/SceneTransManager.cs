using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using static RichardQ.GameManager;
using Scene = UnityEngine.SceneManagement.Scene;

namespace RichardQ{
    // singleton
    public  class SceneTransManager : MonoBehaviour
    {

        private static SceneTransManager SMInstance;

        public int cur_sceneIndex;
        private List<Scene> sceneList = new List<Scene>();


        public static SceneTransManager Instance
        {
            get { return SMInstance; }
        }

        private void Awake()
        {
            
            if (SMInstance != null && SMInstance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                SMInstance = this;
            }

            // load all build scenes into a list
            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            {
                if (scene.enabled)
                {
                    Scene loadedScene = SceneManager.GetSceneByPath(scene.path);
                    sceneList.Add(loadedScene);
                }
            }

            // subscribe to gamestate change event
            GameManager.onStateChanged += SMInstance.GameManagerOnStateChanged;

        }
        private void OnDestroy()
        {
            // unsubscribe
            GameManager.onStateChanged -= SMInstance.GameManagerOnStateChanged;
        }


        private void GameManagerOnStateChanged(GameManager.GameState state)
        {
            switch (state)
            {
                case GameState.MenuState:
                    SMInstance.handleMenuScene();
                    break;
                case GameState.MapState:
                    SMInstance.handleMapScene();
                    break;
                case GameState.PlayState:
                    SMInstance.handlePlayScene();
                    break;
                    
            }
            Debug.Log(state.ToString());
            
        }
        private void handleMenuScene()
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("StartScene"));
        }
        private void handlePlayScene()
        {
            
            SceneManager.LoadScene("PlayScene");
            Debug.Log(SceneManager.sceneCount);
            //SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));
        }

        private void handleMapScene()
        {
            SceneManager.LoadScene("MapScene");
            Debug.Log(SceneManager.sceneCount);
        }

       

        
        
        

        
    }
}


