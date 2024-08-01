using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private Transform _heroTransform;
    [SerializeField] private float _lerpValue;
    private Vector3 _offset;
    private Vector3 _newPosition;

    private void Start()
    {
        _offset = transform.position - _heroTransform.position;
    }

    private void LateUpdate()
    {
        SetCameraSmoothFollow();
    }

    private void SetCameraSmoothFollow()
    {
        _newPosition = Vector3.Lerp(transform.position, new Vector3(0f, _heroTransform.position.y, _heroTransform.position.z) + _offset, _lerpValue * Time.deltaTime);
        transform.position = _newPosition;
    }
}
