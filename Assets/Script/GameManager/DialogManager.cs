using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Queue<string> sentences;
    public Text nameText;
    public Text DialogueText;
    public AudioClip textSound;
    AudioSource audioSource;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        audioSource = GetComponent<AudioSource>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        anim.SetBool("isUp", true);
        DialogueText.text = dialogue.name;

        sentences.Clear();
        foreach(string sentence in dialogue.senteces)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
   
   public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeText(sentence));
    }
    IEnumerator TypeText(string sentence)
    {
        DialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(0.03f) ;
            audioSource.PlayOneShot(textSound);
        }
    }
    void EndDialogue()
    {
        Debug.Log("fine dialogo");
        anim.SetBool("isUp", false);
    }
}
