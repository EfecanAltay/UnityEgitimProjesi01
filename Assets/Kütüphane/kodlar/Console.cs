using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
    public GameObject MessagePanel;
    public Text MessageText;

    public void ShowMessage(string text)
    {
        MessagePanel.SetActive(true);
        MessageText.text = text;
    }

    public void HideMessage()
    {
        MessagePanel.SetActive(false);
    }

    void Update()
    {
        
    }
}
