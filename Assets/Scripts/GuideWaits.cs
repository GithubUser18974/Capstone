using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuideWaits : MonoBehaviour
{
    public GameObject[] objectsToDisbale;
    public float timeToStart=1.5f;
    public GameObject GuideCharachter;
    public float timeToEnd = 10.0f;
    bool isCalling = false; 
    public GameObject EndingGuide;
    // Start is called before the first frame update
    public AudioClip _StartClip, _EndClip;
    public AudioSource audiou;
    void Start()
    {
        if (_StartClip != null)
        {
            timeToStart = _StartClip.length+2.0f+_EndClip.length;
        }
    

        SetGameToDisbale();
        audiou.clip = _StartClip;
        audiou.Play();
        StartCoroutine("BeginTheGame");
        
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("begin")>0)
        {
            EndOfConversation();
        }
    
    }
    IEnumerator BeginTheGame()
    {
        yield return new WaitForSeconds(timeToStart);
        audiou.clip = _EndClip;
        audiou.Play();
        PlayerPrefs.SetInt("begin", 5);
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
        }
        
    }
    IEnumerator PlayEtb3ny()
    {
        yield return new WaitForSeconds(_StartClip.length+1.0f);
        audiou.clip = _EndClip;
        audiou.Play();
        Invoke("GoToTheNextScene", 2);

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
       
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    void SetGameToDisbale()
    {
        for (int i = 0; i < objectsToDisbale.Length; i++)
        {
            objectsToDisbale[i].SetActive(false);
        }
    }
}
