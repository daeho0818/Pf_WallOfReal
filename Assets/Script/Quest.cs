using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public GameObject Button;
    public GameObject clearBook;
    static public int QuestScore;
    public GameObject BookUI;
    void Start()
    {
        Button.SetActive(false);
        BookUI.SetActive(false);
        clearBook.SetActive(false);
    }
    private void Awake()
    {
        QuestScore = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player") && (Comunication.Comuscore == 1))
        {
            if (QuestScore == 0)
            {
                Button.SetActive(true);

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Button.SetActive(false);
        }
    }
    void Update()
    {
        if (Comunication.Comuscore == 1)
        {
            if (QuestScore == 1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    clearBook.SetActive(false);
                }
            }
        }
        if (Comunication.daeho == 1)
        {
            BookUI.SetActive(false);
        }
    }
    public void bookQuest()
    {
        BookUI.SetActive(true);
        clearBook.SetActive(true);
        Button.SetActive(false);
        QuestScore++;
    }
}