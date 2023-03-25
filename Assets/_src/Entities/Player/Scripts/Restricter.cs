using UnityEngine;

public class Restricter : MonoBehaviour
{
    [Header("X")]
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;

    [Header("Y")]
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    private void LateUpdate()
    {
        transform.position = new Vector3
                                 (Mathf.Clamp(transform.position.x, _minX, _maxX),
                                  Mathf.Clamp(transform.position.y, _minY, _maxY),
			          transform.position.z);
    }
}
