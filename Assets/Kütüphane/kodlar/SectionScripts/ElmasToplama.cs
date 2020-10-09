using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElmasToplama : MonoBehaviour
{
    public TextMeshPro SoruText;
    public GameObject ElmasNesnesi;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;

    List<GameObject> elmasListesi = new List<GameObject>();
    PlayerScore score;
    int currentAnswer = 2;

    private float waitingTime = 3f;
    private float timer = 0;

    void Start()
    {
        score = GameObject.FindObjectOfType<PlayerScore>();
        StartGame();
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = 0;
                CreateQuestion();
            }
        }
    }

    void StartGame()
    {
        CreateQuestion();
    }

    void CreateQuestion()
    {
        int x1 = Random.Range(2, 9);
        int x2 = Random.Range(2, 9);
        currentAnswer = x1 * x2;
        SoruText.text = $"{x1} x {x2} = ?";
        int randAns1 = Random.Range(-9, 9) + currentAnswer;
        int randAns2 = Random.Range(-9, 9) + currentAnswer;
        List<int> answers = new List<int> { randAns1, randAns2, currentAnswer };
        answers.Sort();
        CreateDiamonds(answers[0], answers[1], answers[2]);
    }

    void CreateDiamonds(int number1, int number2, int number3)
    {
        var Go = GameObject.Instantiate(ElmasNesnesi, pos1.position,pos1.rotation);
        elmasListesi.Add(Go);
        var elmasScript = Go.GetComponent<Elmas>();
        elmasScript.value = number1;
        elmasScript.OnSelectCallback += () =>
        {
            SelectedNumber(number1);
            
        };
        Go = GameObject.Instantiate(ElmasNesnesi, pos2.position, pos2.rotation);
        elmasListesi.Add(Go);
        elmasScript = Go.GetComponent<Elmas>();
        elmasScript.value = number2;
        elmasScript.OnSelectCallback += () =>
        {
            SelectedNumber(number2);
        };
        Go = GameObject.Instantiate(ElmasNesnesi, pos3.position, pos3.rotation);
        elmasListesi.Add(Go);
        elmasScript = Go.GetComponent<Elmas>();
        elmasScript.value = number3;
        elmasScript.OnSelectCallback += () =>
        {
            SelectedNumber(number3);
        };

    }

    void RemoveDiamonts()
    {
        foreach (var item in elmasListesi)
        {
            Destroy(item);
        }
        elmasListesi.Clear();
    }

    void SelectedNumber(int number)
    {
        RemoveDiamonts();
        if (number == currentAnswer)
        {
            score.AddBlueDimond(1);
            SoruText.text = $"Doğru !!!! + 1 Elmas";
        }
        else
        {
            score.AddBlueDimond(-1);
            SoruText.text = $"Yanlış :( {currentAnswer} olacaktı. - 1 Elmas";
        }
        timer = waitingTime;
    }
}
