using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RichardQ{
    public class GameManager : MonoBehaviour
    {

        public static GameManager GMInstance;

        public enum GameState
        {
            MenuState,
            MapState,
            PlayState
        }


        public GameState State;

        private void Awake()
        {
            if (GMInstance != null && GMInstance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                GMInstance = this;
            }
        }
        public static event Action<GameState> onStateChanged;

        private void Start()
        {
            //updateGameState(GameState.MenuState);
        }


        public virtual void OnStateEnter()
        {

        }
        

        public virtual void updateSubState(PlayState.SubState subState)
        {

        }
        public void updateGameState(GameState newState)
        {
            State = newState;

            switch(newState)
            {
                case GameState.MenuState:
                    handleMenuState();
                    break;
                case GameState.MapState:
                    break;
                case GameState.PlayState:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);

            }
            // if anyone subscribed to this then invoke
            onStateChanged?.Invoke(newState);
        }

        private void handleMenuState()
        {
            
        }
    }
}


