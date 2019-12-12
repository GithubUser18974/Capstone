using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Timer;
    public float timeLeft = 50.0f;
    bool beginCounting = true;

    void Start()
    {
        
    }
    // Update is called once per frame
    private void Update()
    {
        if (beginCounting)
        {
            timeLeft -= Time.deltaTime;
            int tmp = (int)timeLeft;
            if (timeLeft >= 0)
            {
                Timer.text = ""+ tmp+" S";
            }
            if (timeLeft < 0)
            {
                if (SceneManager.sceneCount >SceneManager.GetActiveScene().buildIndex)
                {
                    PlayerPrefs.SetInt("ending", 5);
                }
                else
                {
                    GameManager.Instance.PlayerWin();
                }

            }
          
        }
    }




}
