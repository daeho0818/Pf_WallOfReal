using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest2 : MonoBehaviour
{
    public GameObject HButton;
    public GameObject WButton;
    public GameObject HWaterButton;

    static public int QuestScore2;

    public GameObject HoneyUI;
    public GameObject WaterUI;
    public GameObject HoneyWaterUI;


    public GameObject getWater;
    public GameObject getHoney;
    public GameObject clearHWater;


    int hScore;
    int wScore;
    static public int hwScore;
    void Start()
    {
        HButton.SetActive(false);
        WButton.SetActive(false);
        HWaterButton.SetActive(false);
        HoneyUI.SetActive(false);
        WaterUI.SetActive(false);
        HoneyWaterUI.SetActive(false);
        getWater.SetActive(false);
        getHoney.SetActive(false);
        clearHWater.SetActive(false);
    }
    private void Awake()
    {
        QuestScore2 = 0;
        hScore = 0;
        wScore = 0;
        hwScore = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if ((hScore == 0) && (Comunication2.Comuscore2 == 1))
            {
                HButton.SetActive(true);
            }
            if ((wScore == 0) && (Comunication2.Comuscore2 == 1))
            {
                WButton.SetActive(true);

            }
            else if ((hScore == 1) && (wScore == 1))
            {
                HWaterButton.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HButton.SetActive(false);
            WButton.SetActive(false);
            HWaterButton.SetActive(false);
        }
    }
    void Update()
    {
        if (Comunication2.daeho2 == 1)
        {
            HoneyWaterUI.SetActive(false);
        }
        if ((Input.GetKeyDown(KeyCode.Space)) && (hScore == 1))
        {
            getHoney.SetActive(false);
        }
        if ((Input.GetKeyDown(KeyCode.Space)) && (wScore == 1))
        {
            getWater.SetActive(false);
        }
        else if ((hScore == 1) && (wScore == 1))
        {
            HWaterButton.SetActive(true);
        }
        if ((QuestScore2 == 1) && (Input.GetKeyDown(KeyCode.Space)))
        {
            clearHWater.SetActive(false);
            QuestScore2++;
        }
        
    }
    public void HoneyQuest()
    {
        hScore++;
        HButton.SetActive(false);
        HoneyUI.SetActive(true);
        getHoney.SetActive(true);        
    }
    public void WaterQuest()
    {
        WButton.SetActive(false);
        WaterUI.SetActive(true);
        getWater.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            getWater.SetActive(false);
        }
        wScore++;
    }
    public void HWaterQuest()
    {
        hwScore++;
        HWaterButton.SetActive(false);
        clearHWater.SetActive(true);
        WaterUI.SetActive(false);
        HoneyUI.SetActive(false);
        HoneyWaterUI.SetActive(true);
        QuestScore2++;
        Quest.QuestScore = 100;
        hScore--; wScore--;
    }
}
