using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] Transform _target;
    [SerializeField] Vector3 _targetPos;
    [SerializeField] Vector3 _offset;
    Vector3 _newPos;
    float _startCamY;

	void Start () {
        _offset = _targetPos - transform.position;
        _startCamY = transform.position.y;
	}
	
	void LateUpdate () {
        MoveCamera();
	}

    void MoveCamera()
    {
        _targetPos = _target.position;
        _newPos = _targetPos - _offset;
        transform.position = new Vector3(_newPos.x, _startCamY, _newPos.z);
    }
}
