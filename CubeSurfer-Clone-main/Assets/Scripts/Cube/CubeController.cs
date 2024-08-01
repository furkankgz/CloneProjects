using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private HeroStackController _heroStackController;
    private Vector3 _direction = Vector3.back;
    private RaycastHit _hit;
    private bool _isStack = false;

    private void Start()
    {
        _heroStackController = GameObject.FindObjectOfType<HeroStackController>();
    }

    private void FixedUpdate()
    {
        SetCubeRaycast();
    }

    private void SetCubeRaycast()
    {
        if (Physics.Raycast(transform.position, _direction, out _hit, 1f))
        {
            if (!_isStack)
            {
                _isStack = true;
                _heroStackController.IncreaseBlockStack(gameObject);
                SetDirection();
            }
            if (_hit.transform.name == "ObstacleCube")
            {
                _heroStackController.DecreaseBlock(gameObject);
            }
        }
    }

    private void SetDirection()
    {
        _direction = Vector3.forward;
    }
}
