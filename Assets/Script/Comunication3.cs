using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class Comunication3 : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_DialogueBox;
    [SerializeField] private Text txt_Dialogue;

    private bool isDialogue = false;
    private bool isElseDialogue = false;
    private bool isElse1Dialogue = false;

    static public int Comuscore = 0;
    static public int daeho = 0;

    private int count = 0;
    private int elseCount = 0;
    private int else1Count = 0;

    public GameObject Button;
    public GameObject Button2;
    public GameObject Button3;

    public GameObject stage2Tutorial;
    public GameObject Player2;

    [SerializeField] private Dialogue[] dialogue;
    [SerializeField] private Dialogue[] elseDialogue;
    [SerializeField] private Dialogue[] else1Dialogue;
    private void Awake()
    {
        Comuscore = 0;
        daeho = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player") && (Test2.daeho == 2))
        {
            if (Comuscore == 0)
            {
                Button.SetActive(true);
            }
        }
        else if ((other.gameObject.tag == "Player") && (Quest3.keyboardScore == 100))
        {
            if (Comuscore == 2)
            {
                Button3.SetActive(true);
            }
        }
        /*else if ((other.gameObject.tag == "Player"))
        {
            Button2.SetActive(true);
        }
        else if ((other.gameObject.tag == "Player"))
        {
            Button3.SetActive(true);
        }*/

    }
    private void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.tag == "Player") && (Test2.daeho == 2))
        {
            Button.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Button.SetActive(false);
            Button2.SetActive(false);
            Button3.SetActive(false);
        }
    }
    public void ShowDialogue()
    {
        Test2.daeho = 3;
        OnOff1(true);
        Button.SetActive(false);
        count = 0;
        nextDialogue();
    }
    public void ShowDialogue2()
    {
        OnOff2(true);
        Button2.SetActive(false);
        elseCount = 0;
        twoDialogue();
    }
    public void ShowDialogue3()
    {
        Quest3.keyboardScore = 200;
        OnOff3(true);
        Button3.SetActive(false);
        else1Count = 0;
        threeDialogue();
    }
    private void OnOff1(bool _flag)
    {
        sprite_DialogueBox.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }
    private void OnOff2(bool _flag)
    {
        sprite_DialogueBox.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isElseDialogue = _flag;
    }
    private void OnOff3(bool _flag)
    {
        sprite_DialogueBox.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isElse1Dialogue = _flag;
    }
    private void Start()
    {
        sprite_DialogueBox.gameObject.SetActive(false);
        txt_Dialogue.gameObject.SetActive(false);
        Button.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        Comuscore = 0;
        daeho = 0;
    }
    private void nextDialogue()
    {
        txt_Dialogue.text = dialogue[count].dialogue;
    }
    private void twoDialogue()
    {
        txt_Dialogue.text = elseDialogue[elseCount].dialogue;
    }
    private void threeDialogue()
    {
        txt_Dialogue.text = else1Dialogue[else1Count].dialogue;
    }

    public void TutorialOff()
    {
        stage2Tutorial.SetActive(false);
        GameManager.Player.SetActive(true);
        Comuscore++;
        Quest3.isQuest = true;
    }
    void TutorialOn()
    {
        stage2Tutorial.SetActive(true);
        GameManager.Player.SetActive(false);
    }
    void Update()
    {
        if (isDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (count < dialogue.Length)
                {
                    nextDialogue();
                    count++;
                }

                else
                {
                    OnOff1(false);
                    if (Comuscore == 0)
                    {
                        TutorialOn();
                    }
                }
            }

        }
        else if (isElseDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (elseCount < elseDialogue.Length)
                {
                    twoDialogue();
                    elseCount++;
                }
                else
                {
                    OnOff2(false);
                    if ((Comuscore == 1) && (Quest3.Quest3Score == 12))
                    {
                        Comuscore++;
                        Quest3.Quest3Score++;
                    }
                }
            }
        }
        else if (isElse1Dialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (else1Count < 3)
                {
                    threeDialogue();
                    else1Count++;
                }
                else if (else1Count == 3)
                {
                    Player2.SetActive(true);
                    threeDialogue();
                    else1Count++;
                }
                else if (else1Count < dialogue.Length)
                {
                    threeDialogue();
                    else1Count++;
                }
                else
                {
                    OnOff3(false);
                    Comuscore++;
                }
            }
        }
    }
}