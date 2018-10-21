using UnityEngine;

namespace MindworksGames.MyGame
{
    public class EnemyPlayerDetection : MonoBehaviour
    {
        [SerializeField] float _checkRate;
        [SerializeField] float _nextCheck;
        [SerializeField] float _detectRadius;

        Vector3 _debugPLAYERHEIGHT = new Vector3(0, -1.3f, 0);

        RaycastHit _hitInfo;
        [SerializeField] EnemyMaster _enemyMaster;
        [SerializeField] Transform _enemyTransform;
        [SerializeField] Transform _enemyHead;
        [SerializeField] LayerMask _playerLayerMask;
        [SerializeField] LayerMask _sightLayerMask;
        [SerializeField] Collider[] _detectedColliders;

        void SetInitRefs()
        {
            _enemyMaster = GetComponent<EnemyMaster>();
            _enemyTransform = transform;
            _checkRate = Random.Range(0.8f, 1.2f);

            if(_enemyHead == null)
            {
                _enemyHead = _enemyTransform;
            }

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _detectRadius);
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


        void DisableScript()
        {
            enabled = false;
        }

        void Update()
        {
            CheckTargetVisibility();
        }

        void CheckTargetVisibility()
        {
            if(Time.time > _nextCheck)
            {
                _nextCheck = Time.deltaTime + _checkRate;

                _detectedColliders = Physics.OverlapSphere(_enemyTransform.position, _detectRadius, _playerLayerMask);
                int detecteCollidersCount = _detectedColliders.Length;
                
                if(detecteCollidersCount > 0)
                {
                    for (int i = 0; i < detecteCollidersCount; i++)
                    {
                        if (_detectedColliders[i].CompareTag("Player"))
                        {
                            if (IsTargetVisible(_detectedColliders[i].transform))
                            {
                                break;
                            }
                        }
                    }
                }   
                else
                {
                    _enemyMaster.CallOnEnemyTargetLost();
                }
            }
        }

        bool IsTargetVisible(Transform target)
        {
            Debug.DrawLine(_enemyHead.position, target.position - _debugPLAYERHEIGHT, Color.blue);

            if (Physics.Linecast(_enemyHead.position, target.position - _debugPLAYERHEIGHT, out _hitInfo, _sightLayerMask))
            {

                if(_hitInfo.transform.position == target.position)
                {
                    _enemyMaster.CallOnEnemySetNavTarget(target);
                    return true;
                }
                else
                {
                    _enemyMaster.CallOnEnemyTargetLost();
                    return false;
                }
            }
            else
            {
                _enemyMaster.CallOnEnemyTargetLost();
                return false;
            }
        }
    }
}

