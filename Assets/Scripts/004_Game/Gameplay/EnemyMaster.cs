using UnityEngine;

namespace MindworksGames.MyGame
{
    public class EnemyMaster : HumanoidMaster
    {

        public delegate void NavTargetEventHandler(Transform myTarget);
        public event NavTargetEventHandler OnEnemySetNavTarget;

        public delegate void EnemyHealthEventHandler(float health);
        public event EnemyHealthEventHandler OnEnemyHealthChanged;

        public event HumanoidEventHandler OnEnemyDie;
        public event HumanoidEventHandler OnEnemyMoving;
        public event HumanoidEventHandler OnEnemyReachedNavTarget;
        public event HumanoidEventHandler OnEnemyAttack;
        public event HumanoidEventHandler OnEnemyTargetLost;
        public event HumanoidEventHandler OnAnimationsPlaying;

        public bool isPursuing;
        public bool isNavPaused;

        public Transform CurrentTarget
        {
            get
            {
                return _currentTarget;
            }
        }

        void SetInitRefs()
        {
            _currentTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public void CallOnAnimationsPlaying()
        {
            OnAnimationsPlaying?.Invoke();
        }

        public void CallOnEnemyDie()
        {
            OnEnemyDie?.Invoke();
        }

        public void CallOnEnemyMoving()
        {
            OnEnemyMoving?.Invoke();
        }

        public void CallOnEnemyReachedNavTarget()
        {
            OnEnemyReachedNavTarget?.Invoke();
        }

        public void CallOnEnemyAttack()
        {
            OnEnemyAttack?.Invoke();
        }

        public void CallOnEnemyTargetLost()
        {
            OnEnemyTargetLost?.Invoke();
            _currentTarget = null;
        }

        public void CallOnEnemySetNavTarget(Transform target)
        {
            OnEnemySetNavTarget?.Invoke(target);

            _currentTarget = target;
        }

    }
}


