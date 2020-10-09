using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElmasToplayıcı : MonoBehaviour
{
    List<Elmas> elmasListesi = new List<Elmas>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Elmas")
        {
            Elmas selected = collision.GetComponent<Elmas>();
            elmasListesi.Add(selected);
            selected.Select();
        }        
    }
}
