using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{
    public PlayerScore playerScore;
    public GameManager gameManager;
    public Image Stage1Light;
    public Image Stage2Light;
    public Image Page1Light;
    public Image Page2Light;

    public GameObject Page1;
    public GameObject Page2;
    public GameObject ComplatedPage;

    bool complatedStage1 = false;
    bool complatedStage2 = false;

    public Color SelectedLightColor;

    private int selectedPage = 0;

    public InputField page1Input1;
    public InputField page2Input1;
    public InputField page2Input2;

    public GameObject btnDebug;

    public Text ComputerMessage;

    void ShowLights()
    {
        if (complatedStage1)
        {
            Stage1Light.color = Color.green;
        }
        else
        {
            Stage1Light.color = Color.red;
        }
        if (complatedStage2)
        {
            Stage2Light.color = Color.green;
        }
        else
        {
            Stage2Light.color = Color.red;
        }
    }

    public void OpenPage(int pageNumber)
    {
        selectedPage = pageNumber;
        switch (pageNumber)
        {
            case 0:
                Page1Light.color = SelectedLightColor;
                Page2Light.color = Color.white;
                Page1.SetActive(true);
                Page2.SetActive(false);
                break;
            case 1:
                Page1Light.color = Color.white;
                Page2Light.color = SelectedLightColor;
                Page1.SetActive(false);
                Page2.SetActive(true);
                break;
        }
    }

    public void OpenComputer()
    {
        gameManager.PauseInputsHandler();
        gameObject.SetActive(true);
        ShowLights();
    }

    public void ExitComputer()
    {
        gameManager.StartInputsHandler();
        gameObject.SetActive(false);
    }

    public void DebugCode()
    {
        switch (selectedPage)
        {
            case 0:
                if(page1Input1.text == "36;")
                {
                    Debug.Log("Bilgisayar : Kodun Doğru :) Derleme başarılı !");
                    complatedStage1 = true;
                }
                else
                {
                    Debug.Log($"Bilgisayar : {page1Input1.text} Yazdığım Kod Hatalı");
                    // Hata...
                }
                break;
            case 1:
                if (page2Input1.text.Equals("KırmızıElmasÜret();"))
                {
                    Debug.Log("Bilgisayar : ilk Kodun Doğru :) Devam Et !");
                    if (page2Input2.text.ToLower().Contains("debug.log(") && page2Input2.text.ToLower().Contains(");"))
                    {
                        Debug.Log("Bilgisayar : Kodun Doğru :) Derleme başarılı !");
                        complatedStage2 = true;
                    }
                    else
                    {
                        Debug.Log($"Bilgisayar : {page2Input2.text} Yazdığım Kod Hatalı");
                    }
                }
                else
                {
                    Debug.Log($"Bilgisayar : {page2Input1.text} Yazdığım Kod Hatalı");
                }
                break;
        }
        ShowLights();

        if(complatedStage1 && complatedStage2)
        {
            Page1.SetActive(false);
            Page2.SetActive(false);
            Stage1Light.GetComponent<EventTrigger>().enabled = false;
            Stage2Light.GetComponent<EventTrigger>().enabled = false;
            btnDebug.SetActive(false);
            ComplatedPage.SetActive(true);
        }
    }

    public void Translate()
    {
        if(playerScore.BlueDiamondScore >= 2)
        {
            playerScore.AddBlueDimond(-2);
            playerScore.AddRedDimond(+1);
            ComputerMessage.text = "Üretim başarılı +1 Kırmızı Elmas!";
        }
        else
        {
            ComputerMessage.text = "Yeterince mavi elmas yok !";
        }
    }
}
