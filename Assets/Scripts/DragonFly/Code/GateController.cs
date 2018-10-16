using UnityEngine;

namespace MindworksGames
{
    public class GateController : MonoBehaviour
    {
        [SerializeField] float _force;
        [SerializeField] float _selfDestroyTime;
        [SerializeField] float _explosionRadius;
        [SerializeField] float _upwardsModifier;
        [SerializeField] Rigidbody _gateRigidbody;


        void Start()
        {
            _selfDestroyTime = 8f;
            _gateRigidbody = GetComponent<Rigidbody>();
            Destroy(gameObject, _selfDestroyTime);
        }

        public void ExplodeGate(Vector3 playerPos)
        {
            if(_gateRigidbody != null)
            {
                _gateRigidbody.AddExplosionForce(_force, playerPos, _explosionRadius, _upwardsModifier, ForceMode.Impulse);
            }
        }
    }

}
