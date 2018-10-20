using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MindworksGames.MyGame
{
    public class EnemyAnimation : MonoBehaviour
    {
        public delegate void EnemyAnimationsEventHandler();
        public event EnemyAnimationsEventHandler OnAnimationsInvoked;

        public void CallOnAnimationsInvoked()
        {
            OnAnimationsInvoked?.Invoke();
        }
    }
}

