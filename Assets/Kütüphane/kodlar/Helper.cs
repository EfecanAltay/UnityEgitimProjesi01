using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour
{
    Console console;
    public GameObject downKey;
    public GameObject upKey;
    public GameObject leftKey;
    public GameObject rightKey;

    private int currentStateOrder = -1;
    private float timer;

    KeyCode[] keys = new[] { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.LeftArrow };

    void Awake()
    {
        console = FindObjectOfType<Console>();
    }

    public void StartHelper()
    {
        currentStateOrder = 0;
        CheckActiveButtons();
        console.ShowMessage("Yön Tuşlarıyla Hareket Et");
    }

    void CheckActiveButtons()
    {
        switch (currentStateOrder)
        {
            case 0:
                upKey.SetActive(true);
                break;
            case 1:
                upKey.SetActive(false);
                downKey.SetActive(true);
                break;
            case 2:
                downKey.SetActive(false);
                rightKey.SetActive(true);
                break;
            case 3:
                rightKey.SetActive(false);
                leftKey.SetActive(true);
                break;
            default:
                upKey.SetActive(false);
                downKey.SetActive(false);
                rightKey.SetActive(false);
                leftKey.SetActive(false);
                break;
        }
    }

    void FixedUpdate()
    {
        if (currentStateOrder >= 0 && currentStateOrder < 4)
        {
            if (Input.GetKey(keys[currentStateOrder]))
            {
                timer += Time.deltaTime;
                if (timer > .5f)
                {
                    timer = 0;
                    currentStateOrder++;
                    CheckActiveButtons();
                }
            }
        }
        /*
        else if(currentStateOrder == 4)
        {
            console.ShowMessage("Doğru elmasları topla");
        }
        */
        else if (currentStateOrder > 4)
        {
            currentStateOrder = -1;
            timer = 0;
            Complated();
        }
    }

    void Complated()
    {
        CheckActiveButtons();
        console.HideMessage();
    }
}
