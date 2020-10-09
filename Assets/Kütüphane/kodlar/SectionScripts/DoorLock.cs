using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public PlayerScore pscore; 
    public Console console; 
    public GameObject door;
    public int BlueDiamond;
    public int RedDiamond;
    void Start()
    {
        pscore = GameObject.FindObjectOfType<PlayerScore>();
        console = GameObject.FindObjectOfType<Console>();
    }

    void Update()
    {
        
    }
    
    void OpenDoor()
    {
        Destroy(door);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if(pscore.RedDiamondScore >= RedDiamond && pscore.BlueDiamondScore >= BlueDiamond)
            {
                console.ShowMessage("Kapı Açıldı");
                pscore.AddBlueDimond(-BlueDiamond);
                pscore.AddRedDimond(-RedDiamond);
                OpenDoor();
            }
            else
            {
                console.ShowMessage("Yeterli Elmasın yok!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        console.HideMessage();
    }
}
