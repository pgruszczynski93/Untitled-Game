#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace MindworksGames
{
    [CustomEditor(typeof(MeshCombiner))]
    public class MeshCombinerEditor : Editor
    {
        void OnSceneGUI()
        {
            MeshCombiner mc = (MeshCombiner)target;
            if(Handles.Button(mc.transform.position + Vector3.up * 5, Quaternion.LookRotation(Vector3.up), 1,1, Handles.CylinderHandleCap))
            {
                mc.CombineMeshes();
            }
        }
    }

}
#endif
