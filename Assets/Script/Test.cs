using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue;
}
public class Test : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_DialogueBox;
    [SerializeField] private Text txt_Dialogue;
    public GameObject Button;
    public GameObject Book;
    public GameObject text;

    static public bool isPlayerOn;

    private bool isDialogue = false;

    private int count = 0;

    [SerializeField] private Dialogue[] dialogue;

    private void Awake()
    {
        isPlayerOn = false;
    }
    public void ShowDialogue()
    {
        isPlayerOn = true;
        GameManager.Player.SetActive(true);
        OnOff(true);
        Button.SetActive(false);
        count = 0;
        Book.SetActive(true);
        text.SetActive(true);
        NextDialogue();
    }
    private void OnOff(bool _flag)
    {
        sprite_DialogueBox.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }
    private void Start()
    {
        Button.SetActive(true);
        sprite_DialogueBox.gameObject.SetActive(false);
        txt_Dialogue.gameObject.SetActive(false);
        Book.SetActive(false);
        text.SetActive(false);
    }
    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count].dialogue;
        count++;
    }

    void Update()
    {
        if(isDialogue)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (count < dialogue.Length)
                    NextDialogue();
                else
                    OnOff(false);
            }
    }
}
