using UnityEngine;
using Unity.UI;
using TMPro;
public class WinningPlayerCheck : MonoBehaviour
{

    private void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = "Player " + PlayerPrefs.GetInt("WinningPlayer") + " Wins!!";
    }
}
