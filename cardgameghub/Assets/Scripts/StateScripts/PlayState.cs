using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RichardQ
{
    public class PlayState : GameManager
    {

        public enum SubState
        {
            DrawState,
            PlayerState,
            PlayerEndingState,
            EnemyState

        }
        public SubState subState;

        public static event Action<SubState> onPlayStateSubChange;

        private void ChangedToPlayState()
        {

        }


        void Start()
        {
            Debug.Log("test");
            OnStateEnter();
        }


        void Update()
        {

        }

        public override void OnStateEnter()
        {
            // when we first enter the state always set substate to drawstate
            GameManager.GMInstance.updateSubState(PlayState.SubState.DrawState);
            
            
                
            

            

        }

        public override void updateSubState(PlayState.SubState newSubState)
        {
            // update substate
            subState = newSubState;
            switch(newSubState)
            {
                case SubState.DrawState:
                    break;
                case SubState.PlayerState:
                    break;
                case SubState.PlayerEndingState:
                    break;
                case SubState.EnemyState:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newSubState), newSubState, null);

            }
            onPlayStateSubChange?.Invoke(newSubState);
        }

        
    }
}


