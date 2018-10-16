using UnityEngine;

public class SpawnablePartsController : MonoBehaviour {

	void Start () {
        Destroy(gameObject, 0.5f);		
	}
}
