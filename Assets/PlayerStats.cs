using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int PlayerPoint;
    public static float PlayerSpeed = 3;
    int i = 1;

    public static int Healt;

    public Text pointText;
    public Text HealtText;

    // Start is called before the first frame update
    void Start()
    {
        
        PlayerPoint = 1;
        PlayerSpeed = 3;
        Healt = 3;
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = PlayerPoint.ToString();
        HealtText.text = Healt.ToString();
        SpeedScale();

    }

    void SpeedScale()
    {
        if (PlayerPoint % (i * 10) == 0)
        {
            PlayerSpeed = PlayerSpeed * 1.2f;
            i = i * 2;
        }
    }
    
}
