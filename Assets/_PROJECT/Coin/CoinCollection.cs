using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;                                               //links to ui to show coin counter
public class CoinCollection : MonoBehaviour
{
    private int Coin = 0;

   // public TextMeshProUGUI cointext;                        //links to ui to show coin counter

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Coin")
        {
            if(other.transform.tag == "Coin")
            {
                Coin++;
              //  cointext.text = "Coin: " + Coin.ToString();    //links to ui to show coin counter
                Debug.Log(Coin);

                SoundManager.Instance.PlayCoinSound();

                Destroy(other.gameObject);
            }
        }
    }
}
