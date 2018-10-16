using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindworksGames
{
    public class PlayerController : MonoBehaviour
    {
        float _currentTime;
        float _nextAttackTime;
        [SerializeField] float _attackCooldownTime;
        //[SerializeField] Animator _playerAnimator;
        //[SerializeField] ParticleSystem _fireParticles;
        //[SerializeField] GameObject _gfxJaw;        //szczęka

        WaitForSeconds _attackWFS;
        WaitForSeconds _fireParticlesWFS;


        void OnEnable()
        {
            //DelegatesHandler.onIntroStart += PlayFireWithAnimation;
        }

        void OnDisable()
        {
            //DelegatesHandler.onIntroStart -= PlayFireWithAnimation;
        }

        private void Start()
        {
            _attackWFS = new WaitForSeconds(1.5f);
            _fireParticlesWFS = new WaitForSeconds(0.5f);
        }

        //public void PlayFireParticles()
        //{
        //    _fireParticles.Play();
        //}

        //public void EnableFireAttack()
        //{
        //    _currentTime = Time.time;
        //    if (_currentTime > _nextAttackTime)
        //    {
        //        _nextAttackTime = _currentTime + _attackCooldownTime / 1000;
        //        StartCoroutine(FireAttack());
        //    }
        //}

        //public void PlayFireWithAnimation()
        //{
        //    StartCoroutine(IntroAnimation());
        //}

        //IEnumerator IntroAnimation() {
        //    _playerAnimator.SetTrigger("FireAttack");
        //    _fireParticles.Play();
        //    yield return StartCoroutine(AnimateJaw(DragonJawState.Closed));
        //    yield return _attackWFS;
        //    yield return StartCoroutine(AnimateJaw(DragonJawState.Open));
        //}


        //IEnumerator EnableFireParticles()
        //{
        //    _playerAnimator.SetTrigger("FireAttack");
        //    yield return _fireParticlesWFS;
        //    _fireParticles.Play();
        //}

        //IEnumerator FireAttack()
        //{
        //    yield return EnableFireParticles();
        //    yield return StartCoroutine(AnimateJaw(DragonJawState.Closed));
        //    yield return _attackWFS;
        //    yield return StartCoroutine(AnimateJaw(DragonJawState.Open));
        //}

        //IEnumerator AnimateJaw(DragonJawState jawState)
        //{
        //    float time = 0f;
        //    float duration = 0.5f;
        //    Quaternion closedJawRotation = Quaternion.Euler(0, 0, 73f);
        //    Quaternion openJawRotation = Quaternion.Euler(0, 0, 90f);

        //    while(time < duration)
        //    {
        //        _gfxJaw.transform.localRotation = Quaternion.Lerp((jawState == DragonJawState.Closed) ? closedJawRotation : openJawRotation,
        //                                                           (jawState == DragonJawState.Closed) ?  openJawRotation : closedJawRotation,
        //                                                           time / duration);
        //        time += Time.deltaTime;
        //        yield return null;
        //    }
        //}


        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                 //EnableFireAttack();
            }
        }
    }
    

}
