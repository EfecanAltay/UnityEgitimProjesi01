using UnityEngine;

public class ComputerObject : MonoBehaviour
{
    public Computer computer;
    void Start()
    {
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            computer.OpenComputer();
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            computer.ExitComputer();
        }
    }
}
