using UnityEngine;
using UnityEngine.InputSystem;

public class HealthSystem : MonoBehaviour 
{
    public int maxHealth = 100;
    public int HP = 100;
    [SerializeField] private bool IsPlayer = true;
    [SerializeField] GameObject DeathScene;
    private void OnEnable()
    {
        if (HP > maxHealth) { HP = maxHealth; }
    }
    public void DealDamage(float damage)
    {
        if (HP > 0)
        {
            HP -= (int)damage;      
        }
        if (HP <= 0)
        {
            HP = 0;
            if (DeathScene != null) 
            {
                Debug.Log("InDeathScene");
                if (GetComponentInChildren<PlayerInput>() != null)
                {
                    if (GetComponentInChildren<PlayerInput>().user.index == 0)
                    PlayerPrefs.SetInt("WinningPlayer", 2);
                    else PlayerPrefs.SetInt("WinningPlayer", 1);
                }
                DeathScene.GetComponent<SceneLoader>().LoadScene(); 
                
            }
            if (!IsPlayer) Destroy(gameObject);
        }
    }
    public void HealDamage(float damage)
    {
        if (HP < maxHealth)
        {
            HP += (int)damage;
        }
        if (HP >= maxHealth)
        {
            HP = maxHealth;
        }
    }

}
