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

            // iki pozisyon arasý uzaklýk hesaplanýr
            distance = Vector3.Distance(_currentPosition, _targetPosition);

            Debug.Log("Distance: " + distance);

            // döndürme iþlemi için doðrultu vektörü hesaplanýr
            _directionVector = (_targetPosition - _currentPosition).normalized;

            // küpün iki pozisyon arasý hareketi saðlanýr
            transform.position = Vector3.MoveTowards(_currentPosition, _targetPosition, _speed * Time.deltaTime);

            // küpün döndürme iþlemi yapýlýr
            RotateCharacter(_directionVector);

            // eðer uzaklýk 0.1 den küçükse hedef pozisyon bir sonraki noktanýn pozisyonu olmalý
            if (distance < 0.1f && _index < _pathPointList.Count)
            {
                Debug.Log("Target position has changed!");
                _index++;
                Debug.Log(_index);

                // eðer son noktaya ulaþýldýysa oyun durmalý
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
