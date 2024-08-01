using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _duration;
    [SerializeField] private float _currentTime;
    [SerializeField] private float[] _posX;

    void Update()
    {
        if (_currentTime <= 0)
        {
            _currentTime = _duration;
            Spawn();
        }
        else
        {
            _currentTime -= Time.deltaTime;
        }
    }

    private void Spawn()
    {
        GameObject _newEnemy = Instantiate(_enemyPrefab);
        _newEnemy.transform.position = new Vector2(
                _posX[Random.Range(0, _posX.Length)],
                transform.position.y
            );

        _newEnemy.transform.SetParent(transform);

        if (_newEnemy.transform.position.x == _posX[1])
        {
            _newEnemy.transform.localScale = new Vector3(_newEnemy.transform.localScale.x * -1, 0.4f, 0f);
        }
    }
}
