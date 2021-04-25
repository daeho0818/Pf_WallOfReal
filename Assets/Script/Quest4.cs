using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Quest4 : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_DialogueBox;
    [SerializeField] private Text txt_Dialogue;
    private bool isDialogue;
    [SerializeField] private Dialogue[] dialogue;
    private int count = 0;
    bool isDialogENd = false;
    public bool isNotEnding;
    public GameObject black;
    public bool isEnding2;
    public GameObject SelectEnding;
    public GameObject Player2;
    public GameObject Player3;
    AudioSource audioSource;
    public AudioClip clock;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player2")
        {
            if (isDialogENd == false)
            {
                Debug.Log(">");
                ShowDialogue();
            }
        }
    }
    private void Awake()
    {
        count = 0;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clock;
    }
    public void ShowDialogue()
    {
        OnOff(true);
        nextDialogue();
    }
    void OnOff(bool _flag)
    {
        sprite_DialogueBox.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }
    void nextDialogue()
    {
        txt_Dialogue.text = dialogue[count].dialogue;
    }
    void Update()
    {
        Debug.Log("count : " + count);
        if (isDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space");
                if (count < dialogue.Length)
                {
                    nextDialogue();
                    count++;
                }
                else
                {
                    OnOff(false);
                    if (isNotEnding)
                    {
                        SelectEnding.SetActive(true);
                    }
                    else
                    {
                        isDialogENd = true;
                        StartCoroutine("Fight");
                        StartCoroutine("End");
                    }
                }
            }
        }
    }
    IEnumerator Fight()
    {
        Debug.Log("3");
        audioSource.Play();
        black.SetActive(true);
        yield return new WaitForSeconds(3);
        Player2.SetActive(false);
        black.SetActive(false);
        Debug.Log("4");
        Player3.SetActive(true);
    }
    IEnumerable End()
    {
        yield return new WaitForSeconds(7);
        Application.Quit();
    }
}