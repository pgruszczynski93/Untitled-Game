using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindworksGames
{
    public class CameraController : MonoBehaviour
    {

        void OnEnable()
        {
            DelegatesHandler.onIntroStart += AnimateIntroCamera;    
        }

        void OnDisable()
        {
            DelegatesHandler.onIntroStart -= AnimateIntroCamera;
        }

        void AnimateIntroCamera()
        {

        }
    }
}
