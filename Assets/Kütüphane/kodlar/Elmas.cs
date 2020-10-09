using System;
using TMPro;
using UnityEngine;

public class Elmas : MonoBehaviour
{
    public int value;
    public TextMeshPro text;
    public Action OnSelectCallback;
    void Start()
    {
        text.text =""+ value;
    }

    public void Select()
    {
        OnSelectCallback?.Invoke();
    }
}