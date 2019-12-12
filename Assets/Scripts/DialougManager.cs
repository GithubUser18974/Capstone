using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialougManager : MonoBehaviour
{

    public Text[] textUI;
    private Queue<string> attachedWords;
    int counterText = 0;
    public float typingSpeed = 1.0f;
    public float typingSpeed2 = 0.08f;
    // Use this for initialization
    private void Awake()
    {
        attachedWords = new Queue<string>();

        foreach (var item in textUI)
        {
            attachedWords.Enqueue(item.text);
        }
        foreach (var item in textUI)
        {
            item.text = "";
        }
        StartDialogue();
    }

    public void StartDialogue()
    {
        
        StartCoroutine(WaitAndPrint(1));
    }

    public void DisplayNextSentence()
    {
        if (attachedWords.Count == 0)
        {
            EndConversation();
            print("End");
            return;
        }

        string sentence = attachedWords.Dequeue();
        StopAllCoroutines();
        StartCoroutine(ShowWords(sentence));
        StartCoroutine(WaitAndPrint(typingSpeed));

    }

    IEnumerator ShowWords(string sentence)
    {
        
        textUI[counterText].text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            textUI[counterText].text += letter;
            yield return new WaitForSeconds(typingSpeed2);

            yield return null;
        }
        
            counterText++;
        
    }

    void EndConversation()
    {
       

    }
     private IEnumerator WaitAndPrint(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        DisplayNextSentence();

    }
}