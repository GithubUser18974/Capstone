using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FullGuideWaits : MonoBehaviour
{
    public GameObject[] objectsToDisbale;
    public float timeToStart=1.5f;
    public GameObject GuideCharachter;
    public float timeToEnd = 10.0f;
    bool isCalling = false; 
    public GameObject EndingGuide;
    // Start is called before the first frame update
    AudioSource _AudioSource;
    public AudioClip _StartClip, _EndClip;
    public AudioClip Etb3ny;
    void Start()
    {
        print(SceneManager.sceneCount);
        _AudioSource = gameObject.AddComponent<AudioSource>();
        if (_StartClip != null)
        {
            timeToStart = _StartClip.length;
        }
        if (_EndClip != null)
        {
            timeToEnd = _EndClip.length ;
            timeToEnd += Etb3ny.length;
        }

        PlayerPrefs.SetInt("ending", 0);
        PlayerPrefs.SetInt("begin", 0);
        SetGameToDisbale();
        _AudioSource.clip = _StartClip;
        _AudioSource.Play();
        StartCoroutine("BeginTheGame");
        
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("begin")>0)
        {
            EndOfConversation();
        }
        if (PlayerPrefs.GetInt("ending") > 0 && !isCalling)
        {
            _AudioSource.clip = _EndClip;
            _AudioSource.Play();
            SetGameToDisbale();
            EndingGuide.SetActive(true);
            isCalling = true;
            StartCoroutine("PlayEtb3ny");
        }
    }
    IEnumerator BeginTheGame()
    {
        yield return new WaitForSeconds(timeToStart);
        PlayerPrefs.SetInt("begin", 5);
  
        
    }
    IEnumerator PlayEtb3ny()
    {
        yield return new WaitForSeconds(_EndClip.length+1f);
        _AudioSource.clip = Etb3ny;
        _AudioSource.Play();
        Invoke("GoToTheNextScene", Etb3ny.length + 0.5f);

    }
    void EndOfConversation()
    {
        GuideCharachter.SetActive(false);
        PlayerPrefs.SetInt("begin", 0);
        for (int i = 0; i < objectsToDisbale.Length; i++)
        {
            objectsToDisbale[i].SetActive(true);
        }
         
    }
    void GoToTheNextScene()
    {
       
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    void SetGameToDisbale()
    {
        for (int i = 0; i < objectsToDisbale.Length; i++)
        {
            objectsToDisbale[i].SetActive(false);
        }
    }
}
