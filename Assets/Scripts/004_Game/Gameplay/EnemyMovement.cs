using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

namespace MindworksGames.MyGame
{
    public class EnemyMovement : HumanoidMovement
    {

        public HumanoidEventHandler OnEnemyTargetDetected;
        public HumanoidEventHandler OnEnemyReachedTarget;
        public HumanoidEventHandler OnEnemyAttack;
        public HumanoidEventHandler OnEnemyDie;

        float _randomWalkDistance;

        [SerializeField] float _headingCeil;
        [SerializeField] float _headingFloor;
        [SerializeField] float _headingAngle;
        [SerializeField] float _maxHeadingChange;

        [SerializeField] Vector3 _targetRotation;
        [SerializeField] NavMeshAgent _navMeshAgent;
        SphereCollider _playerTrigger;

        protected override void Start()
        {
            base.Start();
            SetInitRefs();
            StartCoroutine(RandomizeMoveDirection());
        }

        void SetInitRefs()
        {
            _currentTarget = GameObject.FindGameObjectWithTag("Player").transform;
            _playerTrigger = GetComponent<SphereCollider>();
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _headingAngle = Random.Range(0, 360);
            transform.rotation = Quaternion.Euler(0, _headingAngle, 0);
        }

        protected override void SetAttackAnimator()
        {
        }

        protected override void SetMovementAnimator()
        {
        }

        //protected override void MoveHumanoid()
        //{
        //    _currentTargetPos = _currentTarget.position;
        //    _moveVector = (_currentTargetPos - transform.position).normalized;
        //    _forwardRotation = Quaternion.LookRotation(_moveVector);
        //    _smoothedRotation = Quaternion.Lerp(transform.rotation, _forwardRotation, _smoothRotationFactor);
        //    _rb.MoveRotation(_smoothedRotation);
        //}


        protected override void OnTriggerEnter(Collider col)
        {
            if(col.tag == "Player")
            {
                print("Player entered");
            }
        }

        protected override void FixedUpdate()
        {
            //MoveHumanoid();
        }

        void ChangeHeadingAngle()
        {
            _headingFloor = Mathf.Clamp(_headingAngle - _maxHeadingChange, 0, 360);
            _headingCeil = Mathf.Clamp(_headingAngle + _maxHeadingChange, 0, 360);
            _headingAngle = Random.Range(_headingFloor, _headingCeil);
            _targetRotation = new Vector3(0, _headingAngle, 0);


            transform.rotation = Quaternion.Euler(_targetRotation);
        }

        IEnumerator RandomizeMoveDirection()
        {
            while (true)
            {
                ChangeHeadingAngle();
                yield return new WaitForSeconds(Random.Range(1, 3));
            }

        }

    }

}
