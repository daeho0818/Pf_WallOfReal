using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class sceneManager : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("ChoiceStage");
    }
    public void SeeStory()
    {
        SceneManager.LoadScene("SeeStory");
    }
    public void ShutDown()
    {
        Application.Quit();
    }
    public void gotoTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void gototutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }
    public void gotostage1()
    {
        SceneManager.LoadScene("Stage1Scene");
    }
    public void gotostage2()
    {
        if (ScoreManager.stageScore == 1)
            SceneManager.LoadScene("Stage2Scene");
    }
    public void gotostage3()
    {
        if(ScoreManager.stageScore == 2)
        {
            SceneManager.LoadScene("Stage3Scene");
        }
    }
    public void Ending1()
    {
        SceneManager.LoadScene("Ending1");
    }
    public void Ending2()
    {
        SceneManager.LoadScene("Ending2");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Comunication3.Comuscore == 3)
        {
            ScoreManager.stageScore = 2;
            SceneManager.LoadScene("Stage3Scene");
        }
    }
}