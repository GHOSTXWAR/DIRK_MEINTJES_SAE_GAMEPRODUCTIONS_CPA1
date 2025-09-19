using TMPro;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public int PlayerIndex = 0;

    private string PlayerNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (PlayerIndex == 0)
        {
            PlayerNumber = "Player 1 Points:";
            GetComponent<TextMeshProUGUI>().color = Color.blue;
        }
        else if (PlayerIndex == 1) {
            PlayerNumber = "Player 2 Points:";
            GetComponent<TextMeshProUGUI>().color = Color.red;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerNumber;
    }
}
