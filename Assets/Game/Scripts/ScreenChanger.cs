using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenChanger : MonoBehaviour
{
    public float cameraSpeed;

    private Vector2 _startPos;
    private Camera _camera;
    private float _targetPos;

    void Start()
    {
        _camera = GetComponent<Camera>();
        _targetPos = transform.position.x;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _startPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
        {
            float pos = _camera.ScreenToWorldPoint(Input.mousePosition).x - _startPos.x;
            _targetPos = Mathf.Clamp(transform.position.x-pos, -6.12f, 5.63f);
        }
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, _targetPos, cameraSpeed * Time.deltaTime),
            transform.position.y, transform.position.z);
    }
}
