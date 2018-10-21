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
            _enemyMaster.OnEnemyDie += DisableScript;
        }

        private void OnDisable()
        {
            _enemyMaster.OnAnimationsPlaying -= SetMovementAnimation;
            _enemyMaster.OnAnimationsPlaying -= SetAttackAnimation;
            _enemyMaster.OnEnemyDie -= DisableScript;
        }


        protected override void SetMovementAnimation()
        {
            if(_enemyMaster.isPursuing)
            {
                _animator.SetBool("IsWalking", true);
                _animator.SetBool("IsRunning", true);

                print("GOWNO");
            }
            else if(!_enemyMaster.isPursuing || !_enemyMaster.CurrentTarget)
            {
                _animator.SetBool("IsWalking", false);
                _animator.SetBool("IsRunning", false);
                print("GOWNO 2 ");


            }
        }

        protected override void SetAttackAnimation() { }

    }
}

