using UnityEngine;
using UnityEngine.AI;

namespace MindworksGames.MyGame
{
    public class EnemyPursuit : MonoBehaviour
    {

        [SerializeField] float _checkRate;
        [SerializeField] float _nextCheck;

        [SerializeField] NavMeshAgent _navMeshAgent;
        [SerializeField] EnemyMaster _enemyMaster;


        void SetInitRefs()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _enemyMaster = GetComponent<EnemyMaster>();
            _checkRate = Random.Range(0.1f, 0.2f);

        }


        void OnEnable()
        {
            SetInitRefs();
        }

        void OnDisable()
        {
        }

        void Update()
        {
            if (Time.time > _nextCheck)
            {
                _nextCheck = Time.time + _checkRate;

                TryToChaseTarget();
            }
        }

        void TryToChaseTarget()
        {
            if (_enemyMaster.CurrentTarget != null && _navMeshAgent!=null && !_enemyMaster.isNavPaused)
            {
                _navMeshAgent.SetDestination(_enemyMaster.CurrentTarget.position);

                if(_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance)
                {
                    _enemyMaster.isPursuing = true;
                    _enemyMaster.CallOnAnimationsPlaying();
                }
            }
        }

        void DisableScript()
        {
            if (_navMeshAgent != null)
            {
                _navMeshAgent.enabled = false;
            }
            enabled = false;
        }
    }
}
