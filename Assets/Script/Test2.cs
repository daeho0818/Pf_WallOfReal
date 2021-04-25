using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue2
{
    [TextArea]
    public string dialogue;
}
public class Test2 : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_DialogueBox;
    [SerializeField] private Text txt_Dialogue;
    public GameObject text;

    private bool isDialogue = false;
    private bool isElseDialogue = false;

    private int count = 0;
    private int elsecount = 0;
    static public int daeho = 0;

    [SerializeField] private Dialogue[] dialogue;
    [SerializeField] private Dialogue[] elseDialogue;
    private void Awake()
    {
        daeho = 0;
    }
    public void ShowDialogue()
    {
        OnOff(true);
        count = 0;
        text.SetActive(true);
        NextDialogue();
    }
    public void Show2Dialogue()
    {
        OnOff2(true);
        elsecount = 0;
        TwoDialogue();
        daeho++;
    }
    private void OnOff(bool _flag)
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
    private void Start()
    {
        ShowDialogue();
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player") && (daeho == 0))
        {
            Show2Dialogue();
        }
    }
    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count].dialogue;
        count++;
    }
    private void TwoDialogue()
    {
        txt_Dialogue.text = elseDialogue[elsecount].dialogue;
        elsecount++;
    }

    void Update()
    {
        if (isDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (count < dialogue.Length)
                    NextDialogue();
                else
                    OnOff(false);
            }
        }
        else if (isElseDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (elsecount < elseDialogue.Length)
                    TwoDialogue();
                else
                {
                    OnOff2(false);
                    daeho = 2;
                }
            }
        }
    }
}
