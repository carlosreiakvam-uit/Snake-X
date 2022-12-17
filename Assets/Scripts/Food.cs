using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        Instantiate(prefab, new Vector3(5f, 0f, 0f), Quaternion.identity);
    }
}