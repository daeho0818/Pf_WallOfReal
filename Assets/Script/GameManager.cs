using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameObject Player;
    public GameObject Esc;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        Esc.SetActive(false);
    }
    private void Update()
    {
        Debug.Log("Comu3SCore : " + Comunication3.Comuscore);
        Debug.Log("keyboardScore : " + Quest3.keyboardScore);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Esc.SetActive(true);
            Player.SetActive(false);
        }
    }
    public void gotoGame()
    {
        Esc.SetActive(false);
        if (Test.isPlayerOn == true)
        {
            Player.SetActive(true);
        }
    }
}