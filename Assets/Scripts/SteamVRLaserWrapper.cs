using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SteamVRLaserWrapper : MonoBehaviour
{
     SteamVR_LaserPointer steamVrLaserPointer;
    public Image image;
    public GameObject player;
     AudioSource audio1;
    public GameObject audioobject;
    public string str;

    private void Awake()
    {
        steamVrLaserPointer = gameObject.GetComponent<SteamVR_LaserPointer>();
        steamVrLaserPointer.PointerIn += OnPointerIn;
        steamVrLaserPointer.PointerOut += OnPointerOut;
       // steamVrLaserPointer.OnPointerClick += OnPointerClick;
        audio1 = audioobject.GetComponent<AudioSource>();
    }

    private void OnPointerClick(object sender, PointerEventArgs e)
    {
        IPointerClickHandler clickHandler = e.target.GetComponent<IPointerClickHandler>();
    
  
        audio1.Play();

        str = e.target.gameObject.name;
        Debug.Log("pointer is clicked this object  " +str);
        if (str=="Araby")
        {
            SceneManager.LoadScene("MainScene");
            Destroy(player);
        }


        if (clickHandler == null)
        {
            return;
        }


        clickHandler.OnPointerClick(new PointerEventData(EventSystem.current));
    }

    private void OnPointerOut(object sender, PointerEventArgs e)
    {
        //  Debug.Log("pointer is out this object" + e.target.name);
        image.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        
      

        IPointerExitHandler pointerExitHandler = e.target.GetComponent<IPointerExitHandler>();
        if (pointerExitHandler == null)
        {
            return;
        }

        pointerExitHandler.OnPointerExit(new PointerEventData(EventSystem.current));
    }

    private void OnPointerIn(object sender, PointerEventArgs e)
    {
        // Debug.Log("pointer is inside this object" + e.target.name);
        image.GetComponent<Image>().color = new Color32(8, 255, 0, 255);
             audio1.Play();

        IPointerEnterHandler pointerEnterHandler = e.target.GetComponent<IPointerEnterHandler>();
        if (pointerEnterHandler == null)
        {
            return;
        }

        pointerEnterHandler.OnPointerEnter(new PointerEventData(EventSystem.current));
    }
}