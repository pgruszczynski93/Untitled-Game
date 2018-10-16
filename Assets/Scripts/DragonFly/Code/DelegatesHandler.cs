using UnityEngine;
using System;

namespace MindworksGames
{
    public class DelegatesHandler : MonoBehaviour
    {
        public static Action onIntroStart;

        public static void OnIntroStarted()
        {
            if (onIntroStart != null)
            {
                onIntroStart();
            }
        }
    }

}
