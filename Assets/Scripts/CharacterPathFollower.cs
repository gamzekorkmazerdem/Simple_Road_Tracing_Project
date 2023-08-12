using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterPathFollower : MonoBehaviour
{
    //public float speedThreshold;

    private List<GameObject> _pathPointList = new List<GameObject>();

    private Vector3 _targetPosition;
    private Vector3 _currentPosition;
    private Vector3 _directionVector;
    
    private int _index = 0;

    private bool _isEndPoint = false;

    [SerializeField]
    private float _speed;

    public void MoveCharacter(List<GameObject> _pathPointList)
    {
        if(!_isEndPoint)
        {
            float distance = 0;

            _targetPosition = _pathPointList[_index].transform.position;
            _currentPosition = transform.position;

            Debug.Log("Target position: " + _targetPosition);

            // iki pozisyon aras� uzakl�k hesaplan�r
            distance = Vector3.Distance(_currentPosition, _targetPosition);

            Debug.Log("Distance: " + distance);

            // d�nd�rme i�lemi i�in do�rultu vekt�r� hesaplan�r
            _directionVector = (_targetPosition - _currentPosition).normalized;

            // k�p�n iki pozisyon aras� hareketi sa�lan�r
            transform.position = Vector3.MoveTowards(_currentPosition, _targetPosition, _speed * Time.deltaTime);

            // k�p�n d�nd�rme i�lemi yap�l�r
            RotateCharacter(_directionVector);

            // e�er uzakl�k 0.1 den k���kse hedef pozisyon bir sonraki noktan�n pozisyonu olmal�
            if (distance < 0.1f && _index < _pathPointList.Count)
            {
                Debug.Log("Target position has changed!");
                _index++;
                Debug.Log(_index);

                // e�er son noktaya ula��ld�ysa oyun durmal�
                if (_index >= _pathPointList.Count)
                {
                    Debug.Log("You have reached the last point!");
                    _isEndPoint = true;
                }
            }
        }
        else
        {
            transform.position += Vector3.zero;
        }
        
    }

    public void RotateCharacter(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = lookRotation;
    }
}
