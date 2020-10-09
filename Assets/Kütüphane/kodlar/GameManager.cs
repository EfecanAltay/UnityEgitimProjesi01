using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Helper helper;
    public GameObject menuPanel;
    public bool IsGameStarted = true;
    public bool IsPousedInputHandler = false;

    public void PauseInputsHandler()
    {
        IsPousedInputHandler = true;
    }

    public void StartInputsHandler()
    {
        IsPousedInputHandler = false;
    }

    public void StartGame()
    {
        helper.StartHelper();
        menuPanel.SetActive(false);
        IsGameStarted = true;
        IsPousedInputHandler = false;
    }
}
