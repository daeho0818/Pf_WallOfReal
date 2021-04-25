using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class Comunication2 : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_DialogueBox;
    [SerializeField] private Text txt_Dialogue;

    private bool isDialogue = false;
    private bool isElseDialogue = false;
    private bool isElse1Dialogue = false;

    static public int Comuscore2 = 0;
    static public int daeho2 = 0;

    private int count = 0;
    private int elseCount = 0;
    private int else1Count = 0;

    public GameObject Button;
    public GameObject Button2;
    public GameObject Button3;

    public GameObject gotoStage2Button;

    [SerializeField] private Dialogue[] dialogue;
    [SerializeField] private Dialogue[] elseDialogue;
    [SerializeField] private Dialogue[] else1Dialogue;
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player") && (Quest.QuestScore == 2))
        {
            Button.SetActive(true);
        }
        else if ((other.gameObject.tag == "Player") && (Quest2.QuestScore2 == 2))
        {
            Button2.SetActive(true);
        }
        else if ((other.gameObject.tag == "Player") && (Quest.QuestScore == 4))
        {
            Button3.SetActive(true);
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
        OnOff1(true);
        Button.SetActive(false);
        count = 0;
        nextDialogue();
    }
    public void ShowDialogue2()
    {
        daeho2++;
        OnOff2(true);
        Button2.SetActive(false);
        elseCount = 0;
        twoDialogue();
    }
    public void ShowDialogue3()
    {
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
        gotoStage2Button.SetActive(false);
        Comuscore2 = 0;
        daeho2 = 0;
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
                    if (Comuscore2 == 0)
                    {
                        Comuscore2++;
                        isDialogue = false;
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
                    if ((Comuscore2 == 1) && (Quest2.QuestScore2 == 2))
                    {
                        Comuscore2++;
                        Quest.QuestScore++;
                        isElseDialogue = false;
                        gotoStage2Button.SetActive(true);
                    }
                }
            }
        }
        else if (isElse1Dialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (else1Count < else1Dialogue.Length)
                {
                    threeDialogue();
                    else1Count++;
                }
                else
                {
                    OnOff3(false);
                    isElse1Dialogue = false;
                }
            }
        }
    }
    public void gotoStage2()
    {
        SceneManager.LoadScene("Stage2Scene");
        if (ScoreManager.stageScore == 0)
        {
            ScoreManager.stageScore++;
        }
    }
}