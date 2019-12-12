using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public float timeToWiat = 2.0f;
    void Start()
    {
        StartCoroutine("MakeDead", timeToWiat);
    }

    void MakeDead()
    {
        gameObject.SetActive(false);
    } 
}
