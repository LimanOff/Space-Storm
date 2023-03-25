using System;
using UnityEngine;

public class ClickAndDragPlayer : MonoBehaviour
{
    public static Action OnTouchPlayer;

    private Rigidbody2D _selectedObject;
    private Vector3 _offset;
    private Vector3 _mousePosition;
    private Camera _cam;

    private void Awake()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        _mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(_mousePosition);
            if (targetObject)
            {
                _selectedObject = targetObject.transform.gameObject.GetComponent<Rigidbody2D>();
                _offset = _selectedObject.transform.position - _mousePosition;

                OnTouchPlayer?.Invoke();
            }
        }
        if (Input.GetMouseButtonUp(0) && _selectedObject)
        {
            _selectedObject = null;
        }
    }
    void FixedUpdate()
    {
        if (_selectedObject)
        {
            _selectedObject.MovePosition(_mousePosition + _offset);
        }
    }
}
