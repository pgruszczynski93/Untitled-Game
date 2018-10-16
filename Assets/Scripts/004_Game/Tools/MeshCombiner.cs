using UnityEngine;

namespace MindworksGames
{
    [RequireComponent(typeof(MeshRenderer))]
    public class MeshCombiner : MonoBehaviour
    {
        [SerializeField] Material _basicDungeonMaterial;

        public void CombineMeshes()
        {
            Quaternion initialRot = transform.rotation;
            Vector3 initialPos = transform.position;

            transform.rotation = Quaternion.identity;
            transform.position = new Vector3(0, 0, 0);

            Mesh finalMesh = new Mesh();
            finalMesh.name = "Combined" + name;
            MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();

            int filtersCount = meshFilters.Length;
            Debug.Log(name + " is combing " + filtersCount + " meshes");

            CombineInstance[] meshesToCombine = new CombineInstance[filtersCount];

            for(int i=0; i<filtersCount; i++)
            {
                if(meshFilters[i].transform != transform)
                {
                    meshesToCombine[i].subMeshIndex = 0;
                    meshesToCombine[i].mesh = meshFilters[i].sharedMesh;
                    meshesToCombine[i].transform = meshFilters[i].transform.localToWorldMatrix;
                }
            }


            finalMesh.CombineMeshes(meshesToCombine);
            GetComponent<MeshFilter>().sharedMesh = finalMesh;
            GetComponent<MeshRenderer>().materials = new Material[] { _basicDungeonMaterial };

            transform.rotation = initialRot;
            transform.position = initialPos;

            EnableChildren(false);
        }

        void EnableChildren(bool isEnable)
        {
            int childCount = transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(isEnable);
            }
        }
    }

}
