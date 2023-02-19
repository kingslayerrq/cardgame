using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RichardQ{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField]
        public Animator transition;
        [SerializeField]
        private float transitionTime = 1f;
        public static SceneLoader SLInstance;

        public static SceneLoader Instance
        {
            get { return SLInstance; }
        }

        private void Awake()
        {
            if (SLInstance != null && SLInstance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                SLInstance = this;
            }

            GameManager.onStateChanged += ChangeScene;
        }

        private void OnDestroy()
        {
            GameManager.onStateChanged -= ChangeScene;
        }
        void Update()
        {
            
        }

        private void ChangeScene(GameManager.GameState state)
        {
            switch (state)
            {
                case GameManager.GameState.MenuState:
                    LoadStartScene();
                    break;
                case GameManager.GameState.MapState:
                    LoadMapScene();
                    break;
                case GameManager.GameState.PlayState:
                    LoadPlayScene();

                    break;
            }
        }

        public void LoadMapScene()
        {
            
            SLInstance.StartCoroutine(LoadLevel("MapScene"));

        }
        public void LoadPlayScene()
        {
            SLInstance.StartCoroutine(LoadLevel("PlayScene"));
            //GameManager.GMInstance.updateSubState(PlayState.SubState.DrawState);
        }
        public void LoadStartScene()
        {
            SLInstance.StartCoroutine(LoadLevel("StartScene"));
        }

        

        IEnumerator LoadLevel(string sceneName)
        {
            // play animation
            
            transition.SetTrigger("Start");
            // wait
            yield return new WaitForSeconds(transitionTime);
            //load scene
            SceneManager.LoadScene(sceneName);
        }
    }
}


