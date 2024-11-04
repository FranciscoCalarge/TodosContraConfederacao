using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class MainCameraMovementScript : MonoBehaviour
{
    private Vector3 _initialPosition;
    private Vector3 _movementReferenceTarget;
    [SerializeField]private Vector3 _referenceCube;
    private float _movingCooldown=0f;
    public float cameraMoveSpeed=.5f;

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
        _movementReferenceTarget = transform.position + new Vector3((Random.value-.5f)*_referenceCube.x, (Random.value - .5f) *_referenceCube.y, (Random.value - .5f) * _referenceCube.z) ;

    }

    // Update is called once per frame
    void Update()
    {
        _movingCooldown += Time.deltaTime/3f;
        transform.position = Vector3.Lerp(transform.position,_movementReferenceTarget+ Mathf.Sin(Time.time / 2f) * transform.right*2.5f,_movingCooldown*cameraMoveSpeed/2);
        if (_movingCooldown > 1f)
        {
            _movementReferenceTarget = _initialPosition + new Vector3((Random.value - .5f) * _referenceCube.x , (Random.value - .5f) * _referenceCube.y, (Random.value - .5f) * _referenceCube.z);
            _movingCooldown = 0f;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.DrawWireCube(_initialPosition,_referenceCube);
    }
#endif
}
