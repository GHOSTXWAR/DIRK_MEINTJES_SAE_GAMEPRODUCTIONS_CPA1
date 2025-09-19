using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    //gives value to the coin to pick up and destroy afterwards
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Coin"))
        {
            Destroy(collider2D.gameObject);

            ScoreManager.instance.Addpoint();
        }
    }
}

