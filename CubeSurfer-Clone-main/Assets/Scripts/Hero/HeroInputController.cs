using UnityEngine;

public class HeroInputController : MonoBehaviour
{
    private float _horizontalValue; // karakterin yatay olarak hareket bilgisini anlamak için 

    public float HorizontalValue
    {
        get { return _horizontalValue; }
    }

    private void Update()
    {
        HandleHeroHorizontalInput();
    }

    private void HandleHeroHorizontalInput()
    {
        if (Input.GetMouseButton(0))
        {
            _horizontalValue = Input.GetAxis("Mouse X");
        }
        else
        {
            _horizontalValue = 0;
        }
    }
}
