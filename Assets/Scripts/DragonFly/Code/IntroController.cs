using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindworksGames
{
    public class IntroController : MonoBehaviour
    {
        [SerializeField] Transform _playerTransform;
        [SerializeField] Vector3 _playerPos;
        [SerializeField] GateController[] _gates;

        WaitForSeconds _explosionWFS;

        void OnEnable()
        {
            DelegatesHandler.onIntroStart += InitExplosion;
        }

        void OnDisable()
        {
            DelegatesHandler.onIntroStart -= InitExplosion;
        }

        private void Start()
        {
            StartCoroutine(BeginIntro());
        }

        IEnumerator BeginIntro()
        {
            SetRefs();
            yield return _explosionWFS;
            DelegatesHandler.OnIntroStarted();
        }

        void SetRefs()
        {
            _playerPos = _playerTransform.position;
            _explosionWFS = new WaitForSeconds(3f);
        }

        void InitExplosion()
        {
            int gatesCount = _gates.Length;
            for(int i=0; i<gatesCount; i++)
            {   
                _gates[i].ExplodeGate(_playerPos);
            }
        }

    }
}
