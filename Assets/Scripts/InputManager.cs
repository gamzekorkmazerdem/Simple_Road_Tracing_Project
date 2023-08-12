using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private GameObject pathPoints;
    private List<GameObject> _pathPointList;

    private CharacterPathFollower _characterPathFollower;

    void Start()
    {
        // temel tanýmlamalar yapýlýr
        pathPoints = GameObject.Find("Paths");
        _pathPointList = new List<GameObject>();
        _characterPathFollower = FindObjectOfType<CharacterPathFollower>();

        // takip edilecek noktalar bulunur ve listeye eklenir
        for (int i = 0; i < pathPoints.transform.childCount; i++)
        {
            var point = pathPoints.transform.GetChild(i).gameObject;
            _pathPointList.Add(point);
        }

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _characterPathFollower.MoveCharacter(_pathPointList);
        }
    }
}
