using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    [SerializeField] private TMP_Text _ballCountText = null;
    [SerializeField] private List<GameObject> _ball = new List<GameObject> ();
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _horizontalLimit; // Bulundu�u zeminin boyutlar�na g�re sa� sol hareketini yapabilmek i�in ekledi�imiz limit de�i�keni
    [SerializeField] private float _moveSpeed;
    [SerializeField] private GameObject _ballPrefab;

    private float _horizontal;
    private int _gateNumber;
    private int _targetCount;

    void Update()
    {
        HorizontalBallMove();
        ForwardBallMove();
        UpdateBallCountText();
    }

    private void HorizontalBallMove()
    {
        float _newX = 0;

        if (Input.GetMouseButton(0))
        {
            _horizontal = Input.GetAxisRaw("Mouse X");
        }
        else
        {
            _horizontal = 0;
        }

        _newX = transform.position.x + _horizontal * _horizontalSpeed * Time.deltaTime; //Mevcut x pozisyonuna bu de�erleri ata
        _newX = Mathf.Clamp(_newX, -_horizontalLimit, _horizontalLimit); //Hem yeni x poziyonunu olu�turduk hem de zemin boyutlar�na g�re yatay d�zlemdeki hareketi s�n�rland�rd�k

        transform.position = new Vector3(
                _newX,
                transform.position.y,
                transform.position.z
            );
    }

    private void ForwardBallMove()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) // zeminde toplan�lan toplar hemen arkam�zda s�ralans�n
    {
        if (other.gameObject.CompareTag("BallStack"))
        {
            other.gameObject.transform.SetParent(transform);
            other.gameObject.GetComponent<SphereCollider>().enabled = false;
            other.gameObject.transform.localPosition = new Vector3(0f, 0f, _ball[_ball.Count - 1].transform.localPosition.z - 1f);
            _ball.Add(other.gameObject);
        }

        if (other.gameObject.CompareTag("Gate"))
        {
            _gateNumber = other.gameObject.GetComponent<GateController>().GetGateNumber();
            _targetCount = _ball.Count + _gateNumber;

            if (_gateNumber > 0)
            {
                IncreaseBallCount();
            }
            else if (_gateNumber < 0)
            {
                DecreaseBallCount();
            }
        }
    }

    private void UpdateBallCountText()
    {
        _ballCountText.text = _ball.Count.ToString();
    }

    private void IncreaseBallCount()
    {
        for (int i = 0; i < _gateNumber; i++)
        {
            GameObject _newBall = Instantiate(_ballPrefab);
            _newBall.transform.SetParent(transform);
            _newBall.GetComponent<SphereCollider>().enabled = false;
            _newBall.transform.localPosition = new Vector3(0f, 0f, _ball[_ball.Count - 1].transform.localPosition.z - 1f);
            _ball.Add(_newBall);
        }
    }

    private void DecreaseBallCount()
    {
        for (int i = _ball.Count -1; i >= _targetCount; i--)
        {
            _ball[i].SetActive(false);
            _ball.RemoveAt(i);
        }
    }
}
