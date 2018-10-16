using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableController : MonoBehaviour {

    public event Action OnHitted;

    GameObject _spawnablePartsInstance;
    Rigidbody _rb;
    Vector3 _newPos;
    MeshRenderer _meshRenderer;
    [SerializeField] GameObject _spawnableParts;

    void OnEnable()
    {
        OnHitted += SpawnBrokenParts;
        OnHitted += ResetSpawnable;
    }

    void OnDisable()
    {
        OnHitted -= SpawnBrokenParts;
        OnHitted -= ResetSpawnable;
    }


    void OnGroundHitted()
    {
        if (OnHitted != null)
        {
            OnHitted();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Ground")
        {
            OnGroundHitted();
        }   
        if(col.tag == "Player")
        {
            print("Hitted");
        }
    }

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _rb.useGravity = false;
        _meshRenderer.enabled = false;
    }

    void SpawnBrokenParts()
    {
        _spawnablePartsInstance = Instantiate(_spawnableParts, transform);
        _spawnablePartsInstance.transform.SetParent(null);
    }

    public void SetSpawnablePos(Vector3 spawnedPos)
    {
        transform.position = spawnedPos;
    }

    public void PushSpawnable(Vector3 newPos)
    {
        _meshRenderer.enabled = true;
        _rb.useGravity = true;
        _newPos = newPos;
    }
    public void ResetSpawnable()
    {
        _rb.useGravity = false;
        _rb.velocity = new Vector3(0, 0, 0);
        _meshRenderer.enabled = false;
        transform.position = _newPos; 
    }


}
