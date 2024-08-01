using UnityEngine;

public class HeroMovementController : MonoBehaviour
{
    [SerializeField] private HeroInputController _heroInputController;
    [SerializeField] private float _forwardMovementSpeed;
    [SerializeField] private float _horizontalMovementSpeed;
    [SerializeField] private float _horizontalLimitValue;

    private float newPositionX;

    private void FixedUpdate()
    {
        SetHeroForwardMovement();
        SetHeroHorizontalMovement();
    }
    
    private void SetHeroForwardMovement()
    {
        transform.Translate(Vector3.down * _forwardMovementSpeed * Time.fixedDeltaTime);
    }

    private void SetHeroHorizontalMovement()
    {
        newPositionX = transform.position.x + _heroInputController.HorizontalValue * _horizontalMovementSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -_horizontalLimitValue, _horizontalLimitValue);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
