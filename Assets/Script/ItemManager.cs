using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject mongTaJu;
    public GameObject mongTaJuOnButton;
    public void OnMongTaJu()
    {
        mongTaJu.SetActive(true);
        mongTaJuOnButton.SetActive(false);
    }
    public void OffMongTaJu()
    {
        mongTaJu.SetActive(false);
        mongTaJuOnButton.SetActive(true);
    }
}
