using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    Animator animPlayer;

    private void Awake()
    {
        animPlayer = GetComponentInChildren<Animator>();
    }
 
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, maxSpeed * Time.deltaTime, 0);
            animPlayer.SetTrigger("isBack");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -maxSpeed * Time.deltaTime, 0);
            animPlayer.SetTrigger("isFront");
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-maxSpeed * Time.deltaTime, 0, 0);
            animPlayer.SetTrigger("isLeft");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(maxSpeed * Time.deltaTime, 0, 0);
            animPlayer.SetTrigger("isRight");
        }
    }
}