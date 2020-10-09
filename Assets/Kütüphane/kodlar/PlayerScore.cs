using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public Text BlueDiamondText;
    public Text RedDiamondText;
    public int RedDiamondScore = 0;
    public int BlueDiamondScore = 0;
    
    public void AddRedDimond(int diamond)
    {
        RedDiamondScore += diamond;
        if(RedDiamondScore + diamond < 0)
        {
            RedDiamondScore = 0;
        }
        RedDiamondText.text = "" + RedDiamondScore;
    }

    public void AddBlueDimond(int diamond)
    {
        BlueDiamondScore += diamond;
        if (BlueDiamondScore + diamond < 0)
        {
            BlueDiamondScore = 0;
        }
        BlueDiamondText.text =""+ BlueDiamondScore;
    }
}
