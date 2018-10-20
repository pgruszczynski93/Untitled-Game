using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindworksGames.MyGame
{
    public class HumanoidAnimation : MonoBehaviour
    {
        [SerializeField] protected Animator _animator;

        protected virtual void SetMovementAnimation() { }
        protected virtual void SetMovementAnimation(float joystickValue) { }
        protected virtual void SetAttackAnimation() { }
        protected virtual void SetAttackAnimation(float joystickValue) { }

    }

}
