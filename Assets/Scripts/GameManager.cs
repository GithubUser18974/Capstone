using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
     int totalScore=0;
    public Text scoreText;
    public Transform[] spawnTransform;
    public GameObject robotPref;
    int counter = 0;
    public float timeToInsetiateEveryObject=3f;
    public GameObject incrementScoreEffect;
    public GameObject playergitHit;
    public GameObject[] imagesHeart;
    public int lifeCount = 3;
    public AudioClip robotDieAudioClip;
    public GameObject robotDestroyEffect;
    public AudioSource audioSourcing;
    public AudioClip wellDoneClip;
    public AudioClip gameOverClip;
    public AudioClip WinClip;
    bool canPlayWellSDone = true;
    bool canPlayWinGame = true;
    public GameObject restartButton;
    public bool isSurvivalMode = true;
    public GameObject player;
    public bool isPlayerAlife = true;
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    // Use this for initialization
    void Start () {
        if (isSurvivalMode)
        {
            InvokeRepeating("CreateNewEnemy", 5, timeToInsetiateEveryObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(totalScore%5==0&&totalScore>0&&canPlayWellSDone)
        {
            PlayWellDone();
            canPlayWellSDone = false;
        }
        if(totalScore % 5 == 1&&canPlayWellSDone==false)
        {
            canPlayWellSDone = true;

        }
    }
    public void IncrementScore()
    {
        totalScore++;
        incrementScoreEffect.SetActive(true);
        incrementScoreEffect.transform.localScale = new Vector3(8,8,8);
        scoreText.text = ""+totalScore;
    }
    public void DecrementCounter()
    {
        counter--;
    }
    public void MakeRobotDead(Vector3 pos)
    {       
       robotDestroyEffect.SetActive(true);
        robotDestroyEffect.transform.position = pos;    
    }
    Transform GetRandonmPostion()
    {
        int t = 0;
        t = Random.Range(0, spawnTransform.Length);
        return spawnTransform[t];
    }

    void CreateNewEnemy()
    {
        GameObject g = Instantiate(robotPref, GetRandonmPostion().localPosition,GetRandonmPostion().rotation);
        g.transform.parent = null;
    }
    void CancelCreation()
    {
        CancelInvoke("CreateNewEnemy");
    } 
    public void PlayerGetHit()
    {
        playergitHit.SetActive(true);
        if (lifeCount >= 0)
        {
            if (lifeCount != 0)
            {
                imagesHeart[lifeCount - 1].SetActive(false);
            }
            else
            {
                CancelInvoke();
                CancelCreation();
                imagesHeart[0].SetActive(false);
                PlayerIsDead();
            }
            lifeCount--;
        }
        else
        {
            CancelInvoke();
            CancelCreation();
        }
    }
    public void PlayerIsDead()
    {
        isPlayerAlife = false;
        PlayGameOver();
        ShowRestartButton();

    }
    public AudioClip RobotDie()
    {
        return robotDieAudioClip;
    }
    public void PlayerWin()
    {
        if (isPlayerAlife)
        {
            PlayWInGame();
            ShowRestartButton();
        }
    }
    public void PlayWellDone()
    {
        if (audioSourcing.isPlaying == false && audioSourcing != null)
        {
            audioSourcing.clip = wellDoneClip;
            audioSourcing.Play();
        }
    }
    public void PlayGameOver()
    {
        if (audioSourcing.isPlaying == false && audioSourcing != null)
        {
            audioSourcing.clip = gameOverClip;
            audioSourcing.Play();
        }
    }
    public void PlayWInGame()
    {
        if (audioSourcing.isPlaying == false && audioSourcing != null&&canPlayWinGame)
        {
            audioSourcing.clip = WinClip;
            audioSourcing.Play();
            canPlayWinGame = false;
        }
    }
    public void ShowRestartButton()
    {
        restartButton.SetActive(true);
    }
    public void RestartScene()
    {
        Destroy(player);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GotoHome()
    {
        SceneManager.LoadScene(0);

    }
}
