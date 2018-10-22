using UnityEngine;
using UnityEngine.AI;

namespace MindworksGames.MyGame
{
    public class EnemyTargetReached : MonoBehaviour
    {

        [SerializeField] float _checkRate;
        [SerializeField] float _nextCheck;

        [SerializeField] EnemyMaster _enemyMaster;
        [SerializeField] NavMeshAgent _navMeshAgent;

        void SetInitRefs()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _enemyMaster = GetComponent<EnemyMaster>();
            _checkRate = Random.Range(0.3f, 0.4f);
        }

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
            if (Time.time > _nextCheck)
            {
                _nextCheck = Time.time + _checkRate;

                CheckIsTargetReached();
            }
        }

        void CheckIsTargetReached()
        {
            if (_enemyMaster.isMoving)
            {
                if(_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
                {
                    _enemyMaster.isMoving = false;
                    _enemyMaster.CallOnEnemyReachedNavTarget();
                }
            }
        }

        void DisableScript()
        {
            enabled = false;
        }

    }

}
