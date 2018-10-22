using UnityEngine;
using System.Collections;
using UnityEngine.AI;

namespace MindworksGames.MyGame
{
    public class EnemyMovement : HumanoidMovement
    {

        [SerializeField] float _checkRate;
        [SerializeField] float _nextCheck;
        [SerializeField] float _wanderRange;

        NavMeshHit _navMeshHit;
        [SerializeField] NavMeshAgent _navMeshAgent;
        [SerializeField] EnemyMaster _enemyMaster;
        [SerializeField] Vector3 _wanderTarget;


        void OnEnable()
        {
            SetInitRefs();

            _enemyMaster.OnEnemyDie += DisableScript;
        }

        void OnDisable()
        {

            _enemyMaster.OnEnemyDie -= DisableScript;
        }


        void Update()
        {
            if(Time.time > _nextCheck)
            {
                _nextCheck = Time.time + _checkRate;
                CheckMovingPossibility();
            }    
        }

        protected override void SetInitRefs()
        {
            base.SetInitRefs();

            _wanderRange = 15f;
            _checkRate = Random.Range(0.3f, 0.4f);
            _enemyMaster = GetComponent<EnemyMaster>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void CheckMovingPossibility()
        {
            if(_enemyMaster.CurrentTarget == null && !_enemyMaster.isMoving && !_enemyMaster.isNavPaused)
            {
                if (IsRandomWanderTargetFound(_humanoidTransform.position, _wanderRange, out _wanderTarget))
                {
                    _navMeshAgent.SetDestination(_wanderTarget);
                    _enemyMaster.isMoving = true;
                    _enemyMaster.CallOnAnimationsPlaying();
                }
            }
        }

        bool IsRandomWanderTargetFound(Vector3 center, float wanderRange, out Vector3 randomizedTarget)
        {
            Vector3 randomNavMeshPoint = center + Random.insideUnitSphere * wanderRange;

            if(NavMesh.SamplePosition(randomNavMeshPoint, out _navMeshHit, 1.0f, NavMesh.AllAreas))
            {
                randomizedTarget = _navMeshHit.position;
                return true;

            }
            else
            {
                randomizedTarget = center;
                return false;
            }
        }

        void DisableScript()
        {
            enabled = false;
        }


    }

}
