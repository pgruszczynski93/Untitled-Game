using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

namespace MindworksGames.MyGame
{
    public class EnemyMovement : HumanoidMovement
    {

        public delegate void NavTargetEventHandler(Transform myTarget);
        public event NavTargetEventHandler OnEnemySetNavTarget;

        public delegate void EnemyHealthEventHandler(float health);
        public event EnemyHealthEventHandler OnEnemyHealthChanged;

        public HumanoidEventHandler OnEnemyDie;
        public HumanoidEventHandler OnEnemyMoving;
        public HumanoidEventHandler OnEnemyReachedNavTarget;
        public HumanoidEventHandler OnEnemyAttack;
        public HumanoidEventHandler OnEnemyTargetLost;

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
            StartCoroutine(RandomizeMoveDirectionRoutine());
        }

        void SetInitRefs()
        {
            _currentTarget = GameObject.FindGameObjectWithTag("Player").transform;
            _playerTrigger = GetComponent<SphereCollider>();
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _headingAngle = Random.Range(0, 360);
            transform.rotation = Quaternion.Euler(0, _headingAngle, 0);
        }

        //protected override void MoveHumanoid()
        //{
        //    _currentTargetPos = _currentTarget.position;
        //    _moveVector = (_currentTargetPos - transform.position).normalized;
        //    _forwardRotation = Quaternion.LookRotation(_moveVector);
        //    _smoothedRotation = Quaternion.Lerp(transform.rotation, _forwardRotation, _smoothRotationFactor);
        //    _rb.MoveRotation(_smoothedRotation);
        //}


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
        }

        public void CallOnEnemySetNavTarget(Transform target)
        {
            OnEnemySetNavTarget?.Invoke(target);

            _currentTarget = target;
        }

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
