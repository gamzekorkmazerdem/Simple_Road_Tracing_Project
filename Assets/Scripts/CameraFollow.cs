using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _target; // kameranýn takip edeceði nesne

    [SerializeField]
    // kameranýn nesneyi ne kadar geriden ve yüksekten takip edeceðini ayarlamak için kullanýlacak vektör
    private Vector3 _offset;

    // kamera kontrolleri genelde late update te yapýlýr
    private void LateUpdate()
    {
        // kamera nesneyi sadece yukarý aþaðý hareketlerde takip etsin
        var targetPosition = _target.position - _offset;
        targetPosition.z = 0;
        // takibi belirtilen offset kadar geriden ve yukarýdan yap
        transform.position = targetPosition;
    }
}
