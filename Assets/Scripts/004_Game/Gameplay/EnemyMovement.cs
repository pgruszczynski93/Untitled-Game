using UnityEngine;
using System.Collections;
using UnityEngine.AI;

namespace MindworksGames.MyGame
{
    public class EnemyMovement : HumanoidMovement
    {

        float _randomWalkDistance;

        [SerializeField] float _headingCeil;
        [SerializeField] float _headingFloor;
        [SerializeField] float _headingAngle;
        [SerializeField] float _maxHeadingChange;

        SphereCollider _playerTrigger;
        [SerializeField] Vector3 _targetRotation;
        [SerializeField] NavMeshAgent _navMeshAgent;
        [SerializeField] EnemyMaster _enemyMaster;


        void OnEnable()
        {
            SetInitRefs();
        }

        void OnDisable()
        {
            
        }

        void Start()
        {
            StartCoroutine(RandomizeMoveDirectionRoutine());
        }

        protected override void SetInitRefs()
        {
            base.SetInitRefs(); 

            _playerTrigger = GetComponent<SphereCollider>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _enemyMaster = GetComponent<EnemyMaster>();

            _headingAngle = Random.Range(0, 360);
            transform.rotation = Quaternion.Euler(0, _headingAngle, 0);
        }

        void ChangeHeadingAngle()
        {
            _headingFloor = Mathf.Clamp(_headingAngle - _maxHeadingChange, 0, 360);
            _headingCeil = Mathf.Clamp(_headingAngle + _maxHeadingChange, 0, 360);
            _headingAngle = Random.Range(_headingFloor, _headingCeil);
            _targetRotation = new Vector3(0, _headingAngle, 0);

            transform.rotation = Quaternion.Euler(_targetRotation);
        }

        IEnumerator RandomizeMoveDirectionRoutine()
        {
            while (true)
            {
                ChangeHeadingAngle();
                yield return new WaitForSeconds(Random.Range(1, 3));
            }

        }

    }

}
