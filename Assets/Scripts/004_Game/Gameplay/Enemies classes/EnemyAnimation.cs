using UnityEngine;

namespace MindworksGames.MyGame
{
    public class EnemyAnimation : HumanoidAnimation
    {
        [SerializeField] EnemyMaster _enemyMaster;


        void SetInitRefs()
        {
            _enemyMaster = GetComponent<EnemyMaster>();
        }

        private void OnEnable()
        {
            SetInitRefs();

            _enemyMaster.OnAnimationsPlaying += SetMovementAnimation;
            _enemyMaster.OnAnimationsPlaying += SetAttackAnimation;
            _enemyMaster.OnEnemyTargetLost += SetIdleAnimation;
            _enemyMaster.OnEnemyDie += DisableScript;
        }

        private void OnDisable()
        {
            _enemyMaster.OnAnimationsPlaying -= SetMovementAnimation;
            _enemyMaster.OnAnimationsPlaying -= SetAttackAnimation;
            _enemyMaster.OnEnemyTargetLost -= SetIdleAnimation;
            _enemyMaster.OnEnemyDie -= DisableScript;
        }


        protected override void SetMovementAnimation()
        {
            if(_enemyMaster.isPursuing)
            {
                _animator.SetBool("IsWalking", true);
                _animator.SetBool("IsRunning", true);

            }
            else if(!_enemyMaster.isPursuing)
            {
                SetIdleAnimation();
            }
        }

        void SetIdleAnimation()
        {
            _animator.SetBool("IsWalking", false);
            _animator.SetBool("IsRunning", false);
        }

        protected override void SetAttackAnimation() { }

    }
}

