using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Quest3 : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip well;
    bool isSound;
    bool isMenu;
    bool isReSelect;
    static public bool isQuest;
    static public int Quest3Score;
    static public int keyCapScore;
    static public int keyboardScore;

    public GameObject Guest1;
    public GameObject Guest2;
    public GameObject Guest3;
    public GameObject Guest4;
    public GameObject foodButton;
    public GameObject foodMenu;

    public GameObject NPCButton;

    public GameObject food1UI;
    public GameObject food2UI;
    public GameObject food3UI;
    public GameObject food4UI;
    public GameObject SelectFood;
    public GameObject reSelect;
    public GameObject noSelect;
    public GameObject Select;

    public GameObject Order;
    [SerializeField] private Text txt;

    public GameObject KBButton;
    public GameObject KBTutorial;
    public GameObject keyboard;
    public GameObject keyCap1;
    public GameObject keyCap2;
    public GameObject keyCap3;
    public GameObject keyCap4;
    public GameObject keyCap5;
    public GameObject keyCap6;
    public GameObject GoodCap1;
    public GameObject GoodCap2;
    public GameObject GoodCap3;
    public GameObject GoodCap4;
    public GameObject GoodCap5;
    public GameObject GoodCap6;
    public GameObject gameClear;
    public GameObject offKeyboard;
    private void Awake()
    {
        isReSelect = true;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = well;
        isSound = false;
        Quest3Score = 0;
        keyboardScore = 0;
    }
    private void Start()
    {
        Order.SetActive(false);

        Guest1.SetActive(false);
        Guest2.SetActive(false);
        Guest3.SetActive(false);
        Guest4.SetActive(false);

        food1UI.SetActive(false);
        food2UI.SetActive(false);
        food3UI.SetActive(false);
        food4UI.SetActive(false);

        SelectFood.SetActive(false);

        KBButton.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((isQuest == true) && (other.gameObject.tag == "Counter") && (Quest3Score >= 1) && (isMenu == false))
        {
            {
                foodButton.SetActive(true);
            }
        }
        else if ((isQuest == false) && (other.gameObject.tag == "Counter") && (Quest3Score == 12))
        {
            NPCButton.SetActive(true);
        }
        else if ((isQuest == true) && (other.gameObject.tag == "KeyBoard") && (Quest3Score == 13))
        {
            KBButton.SetActive(true);
        }
    }
    public void order1()
    {
        if (Quest3Score == 0)
        {
            Quest3Score = 1;
            txt.text = "볶음밥 하나 주세요~";
            Order.SetActive(true);
        }
        if (Quest3Score == 2)
        {
            food1UI.SetActive(false);
            Quest3Score = 3;
            txt.text = "맛있게 잘 먹겠습니다!";
            Order.SetActive(true);
            isSound = false;
            isReSelect = true;
            Guest1.SetActive(false);
            Guest2.SetActive(true);
        }
    }
    public void order2()
    {
        if (Quest3Score == 3)
        {
            Quest3Score = 4;
            txt.text = "신라면 하나 주세요~";
            Order.SetActive(true);
        }
        if (Quest3Score == 5)
        {
            food2UI.SetActive(false);
            Quest3Score = 6;
            txt.text = "아니 생라면을...";
            Order.SetActive(true);
            isSound = false;
            isReSelect = true;
            Guest2.SetActive(false);
            Guest3.SetActive(true);
        }
    }
    public void order3()
    {
        if (Quest3Score == 6)
        {
            Quest3Score = 7;
            txt.text = "짜파게티 하나 주세요~";
            Order.SetActive(true);
        }
        if (Quest3Score == 8)
        {
            food3UI.SetActive(false);
            Quest3Score = 9;
            txt.text = "아니 짜파게티를 생으로...";
            Order.SetActive(true);
            isSound = false;
            isReSelect = true;
            Guest3.SetActive(false);
            Guest4.SetActive(true);
        }
    }
    public void order4()
    {
        if (Quest3Score == 9)
        {
            Quest3Score = 10;
            txt.text = "불닭 하나 주세요~";
            Order.SetActive(true);
        }
        if (Quest3Score == 11)
        {
            food4UI.SetActive(false);
            Quest3Score = 12;
            txt.text = "제가 생불닭 좋아하는거 어케알고..";
            Order.SetActive(true);
            Guest4.SetActive(false);
            isQuest = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Counter")
        {
            foodButton.SetActive(false);
        }
        if (other.gameObject.tag == "KeyBoard")
        {
            KBButton.SetActive(false);
        }
    }
    public void orderOff()
    {
        Order.SetActive(false);
    }
    public void KBTutorialOn()
    {
        if (keyboardScore == 0)
        {
            KBTutorial.SetActive(true);
        }
    }
    public void KBTutorialOFf()
    {
        KBTutorial.SetActive(false);
        Keyboard();
        isQuest = true;
    }
    void Keyboard()
    {
        keyboard.SetActive(true);
    }
    public void KeyCap1()
    {
        keyCapScore = 1;
    }
    public void KeyCap2()
    {
        keyCapScore = 2;
    }
    public void KeyCap3()
    {
        keyCapScore = 3;
    }
    public void KeyCap4()
    {
        keyCapScore = 4;
    }
    public void KeyCap5()
    {
        keyCapScore = 5;
    }
    public void KeyCap6()
    {
        keyCapScore = 6;
    }
    public void Keyboard1()
    {
        if (keyCapScore == 1)
        {
            keyCap1.SetActive(false);
            GoodCap1.SetActive(true);
            keyboardScore++;
        }
        else
        {
            Select.SetActive(true);
        }
    }
    public void Keyboard2()
    {
        if (keyCapScore == 2)
        {
            keyCap2.SetActive(false);
            GoodCap2.SetActive(true);
            keyboardScore++;

        }
        else
        {
            reSelect.SetActive(true);
        }
    }
    public void Keyboard3()
    {
        if (keyCapScore == 3)
        {
            keyCap3.SetActive(false);
            GoodCap3.SetActive(true);
            keyboardScore++;
        }
        else
        {
            Select.SetActive(true);
        }
    }
    public void Keyboard4()
    {
        if (keyCapScore == 4)
        {
            keyCap4.SetActive(false);
            GoodCap4.SetActive(true);
            keyboardScore++;
        }
        else
        {
            Select.SetActive(true);
        }
    }
    public void Keyboard5()
    {
        if (keyCapScore == 5)
        {
            keyCap5.SetActive(false);
            GoodCap5.SetActive(true);
            keyboardScore++;
        }
        else
        {
            Select.SetActive(true);
        }
    }
    public void Keyboard6()
    {
        if (keyCapScore == 6)
        {
            keyCap6.SetActive(false);
            GoodCap6.SetActive(true);
            keyboardScore++;
        }
        else
        {
            Select.SetActive(true);
        }
    }
    public void foodOn()
    {
        isMenu = true;
        foodMenu.SetActive(true);
        foodButton.SetActive(false);
    }
    public void foodOff()
    {
        isMenu = false;
        foodMenu.SetActive(false);
    }
    public void food1()
    {
        foodMenu.SetActive(false);
        if (Quest3Score == 1)
        {
            isSound = true;
            food1UI.SetActive(true);
            SelectFood.SetActive(true);
            Quest3Score = 2;
            isReSelect = false;
        }
        else if (isReSelect == false)
        {
            noSelect.SetActive(true);
        }
        else
        {
            reSelect.SetActive(true);
        }
    }
    public void food2()
    {
        foodMenu.SetActive(false);
        if (Quest3Score == 4)
        {
            isSound = true;
            food2UI.SetActive(true);
            SelectFood.SetActive(true);
            Quest3Score = 5;
            isReSelect = false;
        }
        else if (isReSelect == false)
        {
            noSelect.SetActive(true);
        }
        else
        {
            reSelect.SetActive(true);
        }
    }
    public void food3()
    {
        foodMenu.SetActive(false);
        if (Quest3Score == 7)
        {
            isSound = true;
            food3UI.SetActive(true);
            SelectFood.SetActive(true);
            Quest3Score = 8;
            isReSelect = false;
        }
        else if (isReSelect == false)
        {
            noSelect.SetActive(true);
        }
        else
        {
            reSelect.SetActive(true);
        }
    }
    public void food4()
    {
        foodMenu.SetActive(false);
        if (Quest3Score == 10)
        {
            isSound = true;
            food4UI.SetActive(true);
            SelectFood.SetActive(true);
            Quest3Score = 11;
            isReSelect = false;
        }
        else if (isReSelect == false)
        {
            noSelect.SetActive(true);
        }
        else
        {
            reSelect.SetActive(true);
        }
    }
    public void keyboardReSelectOff()
    {
        Select.SetActive(false);
    }
    public void selectOff()
    {
        SelectFood.SetActive(false);
        foodMenu.SetActive(true);
    }
    public void selectoff()
    {
        SelectFood.SetActive(false);
    }
    public void reSelectOff()
    {
        reSelect.SetActive(false);
        foodMenu.SetActive(true);
    }
    public void noSelectOff()
    {
        noSelect.SetActive(false);
        foodMenu.SetActive(true);
    }
    public void OffKeyboard()
    {
        keyboard.SetActive(false);
        offKeyboard.SetActive(false);
    }
    void Update()
    {
        StartSound();
        Debug.Log("Quest3Score : " + Quest3Score);
        if (keyboardScore == 6)
        {
            StartCoroutine("Clear");
        }
    }
    void StartSound()
    {
        if ((Comunication3.Comuscore == 1) && (isSound == false) && (Quest3Score == 0))
        {
            Guest1.SetActive(true);
            isSound = true;
            audioSource.Play();
        }
        else if ((Quest3Score == 3) && (isSound == false))
        {
            isSound = true;
            audioSource.Play();
        }
        else if ((Quest3Score == 6) && (isSound == false))
        {
            isSound = true;
            audioSource.Play();
        }
        else if ((Quest3Score == 9) && (isSound == false))
        {
            isSound = true;
            audioSource.Play();
        }
        if (Quest3Score == 13)
        {
            KBButton.SetActive(true);
        }
    }
    IEnumerator Clear()
    {
        gameClear.SetActive(true);
        yield return new WaitForSeconds(3);
        gameClear.SetActive(false);
        keyboardScore = 100;
        offKeyboard.SetActive(true);
        isQuest = false;
    }
}