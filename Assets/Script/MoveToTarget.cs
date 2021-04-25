using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveToTarget : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject Player2;
    bool isPos;
    bool isEnd;
    void Awake()
    {
        isPos = false;
        isEnd = false;
    }
    void Update()
    {
        move();
    }
    private void move()
    {
        if ((isEnd) && (transform.position == targets[1].transform.position))
        {
            Player2.SetActive(false);
        }
        if (isPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targets[1].transform.position, 5f*Time.deltaTime);
            isEnd = true;
        }
        else if ((transform.position != targets[0].transform.position)&&(!isPos))
        {
            transform.position = Vector3.MoveTowards(transform.position, targets[0].transform.position, 1f*Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "target")
        {
            isPos = true;
        }
    }
}