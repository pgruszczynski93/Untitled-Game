using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindworksGames.MyGame
{
    public class PlayerMaster : HumanoidMaster
    {
        public delegate void PlayerAnimationsEventHandler(float inputValue);

        public event HumanoidEventHandler OnPlayerMoving;
        public event HumanoidEventHandler OnPlayerLevelUp;
        public event HumanoidEventHandler OnPlayerAttack;
        public event HumanoidEventHandler OnPlayerDie;
        public event PlayerAnimationsEventHandler OnAnimationsPlaying;

        public void CallOnPlayerMoving()
        {
            OnPlayerMoving?.Invoke();
        }

        public void CallOnPlayerLevelUp()
        {
            OnPlayerLevelUp?.Invoke();
        }

        public void CallOnPlayerAttack()
        {
            OnPlayerAttack?.Invoke();
        }

        public void CallOnPlayerDie()
        {
            OnPlayerDie?.Invoke();
        }

        public void CallOnAnimationsPlaying(float inputVal)
        {
            OnAnimationsPlaying?.Invoke(inputVal);
        }

        void FixedUpdate()
        {
            CallOnPlayerMoving();
        }
    }

}
