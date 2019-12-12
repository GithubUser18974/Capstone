using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daeding : MonoBehaviour
{
    public float timeToWiat = 2.0f;
    bool wait = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FuckingDead", 1f);
    }
    private void Update()
    {
        if (gameObject.activeInHierarchy == true && !wait)
        {
            Invoke("FuckingDead", timeToWiat);
            wait = true;
        }
    }
    // Update is called once per frame
    void FuckingDead()
    {
        this.gameObject.SetActive(false);
        wait = false;
    }
}
