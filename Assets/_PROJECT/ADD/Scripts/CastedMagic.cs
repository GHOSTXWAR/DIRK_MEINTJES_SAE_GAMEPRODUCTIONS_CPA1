using System.Collections;
using UnityEngine;

public class CastedMagic : MonoBehaviour
{
    [SerializeField] public float speed = 10f;
    [SerializeField] private float MagicLifetime = 3f;
    
    private Rigidbody rb;


    
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(MagicLife(MagicLifetime));
        rb.linearVelocity = new Vector3(0, 0, 0);
        
    }

    private IEnumerator MagicLife(float LifeDuration)
    {
        yield return new WaitForSeconds(LifeDuration);
        gameObject.SetActive(false);
    }
   
    private void OnCollisionEnter(Collision collision)
    {
            gameObject.SetActive(false);   
    }
    

}
