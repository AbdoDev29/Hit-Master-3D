using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDistance : MonoBehaviour
{
    public Transform enemy;
    void Update()
    {
        float distance = Vector3.Distance(transform.position, enemy.position);
        Debug.Log(distance);
    }
}
