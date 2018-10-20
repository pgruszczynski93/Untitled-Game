using UnityEngine;

namespace MindworksGames.MyGame
{
    public abstract class HumanoidMaster : MonoBehaviour
    {

        public delegate void HumanoidEventHandler();

        [SerializeField] protected Transform _currentTarget;

    }
}

