using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _target; // kameran�n takip edece�i nesne

    [SerializeField]
    // kameran�n nesneyi ne kadar geriden ve y�ksekten takip edece�ini ayarlamak i�in kullan�lacak vekt�r
    private Vector3 _offset;

    // kamera kontrolleri genelde late update te yap�l�r
    private void LateUpdate()
    {
        // kamera nesneyi sadece yukar� a�a�� hareketlerde takip etsin
        var targetPosition = _target.position - _offset;
        targetPosition.z = 0;
        // takibi belirtilen offset kadar geriden ve yukar�dan yap
        transform.position = targetPosition;
    }
}
