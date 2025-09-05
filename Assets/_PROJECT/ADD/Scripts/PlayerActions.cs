using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    private InputActionAsset inputActions;
    private InputActionMap player;
    private InputAction Ability1;
    private InputAction Ability2;

    public Camera playerCam;

    [SerializeField] private GameObject A1Panel;
    [SerializeField] private GameObject A2Panel;

    private Image A1Image;
    private Image A2Image;

    [SerializeField] public GameObject MagicSpawn;
    [SerializeField] private float Ability1ManaCost = 15f;
    [SerializeField] private float Ability2ManaCost = 40f;

    [SerializeField] private float Ability1Cooldown = 5f;
    [SerializeField] private float Ability2Cooldown = 30f;
    [SerializeField] private int Ability2Balls = 3;

    private Vector3 castDirection;

    private bool A1Ready = true;
    private bool A2Ready = true;

    private float A1Timer = 0;
    private float A2Timer = 0;

    private ManaSystem manaSystem;
    private void Awake()
    {
        inputActions = this.GetComponentInChildren<PlayerInput>().actions;
        player = inputActions.FindActionMap("Player");
        A1Image = A1Panel.GetComponent<Image>();
        A2Image = A2Panel.GetComponent<Image>();
    }

    private void OnEnable()
    {
        player.Enable();
        Ability1 = player.FindAction("Ability1");
        Ability2 = player.FindAction("Ability2");
        manaSystem = GetComponent<ManaSystem>();
    }

    private void OnDisable()
    {
        player.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        if (!GamePauseSystem.inPausedState && Ability1.IsPressed())
        {
            Debug.Log("Ability1");
            if (A1Ready && manaSystem.MP >= Ability1ManaCost)
            {

                Debug.Log("Ability1 Cast");
                manaSystem.DrainMana(Ability1ManaCost);
                Cast(1);
            }
            else
            {
                Debug.Log("Ability 1 not Ready");
            }
        }
        if (!GamePauseSystem.inPausedState && Ability2.IsPressed()) 
        {

            Debug.Log("Ability2");
            if (A2Ready && manaSystem.MP >= Ability2ManaCost)
            {
                manaSystem.DrainMana(Ability2ManaCost);
                StartCoroutine(AbilityMultipleCast(Ability2Balls,2));
                Debug.Log("Ability2 Cast");
            }
            else
            {
                Debug.Log("Ability 2 not Ready");
            }
        }
    }

    private void FixedUpdate()
    {
        if (!A1Ready && A1Timer == 0)
        {
            A1Timer = Ability1Cooldown;
            A1Image.fillAmount = 1;
        }
        if (!A1Ready)
        {
            A1Timer -= Time.deltaTime;
            A1Image.fillAmount = A1Timer / Ability1Cooldown;
            
        }
        if (A1Timer <= 0)
        {
            A1Ready = true;
            A1Timer = 0;
            A1Image.fillAmount = 0;
        }
        if (!A2Ready && A2Timer == 0)
        {
            A2Timer = Ability2Cooldown;
            A2Image.fillAmount = 1;
        }
        if (!A2Ready)
        {
            A2Timer -= Time.deltaTime;
            A2Image.fillAmount = A2Timer / Ability2Cooldown;
            
        }
        if (A2Timer <= 0)
        {
            A2Ready = true;
            A2Timer = 0;
            A2Image.fillAmount = 0;
        }
    }

    private void Cast(int AbilityIndex)
    {
        GameObject ability = ObjectPool.instance.GetPooledObject();
        if (ability != null)
        {
            switch (AbilityIndex) { 
                case 1:
                    A1Ready = false;
                    //StartCoroutine(AbilityCooldown(AbilityIndex));
                    ability.transform.rotation = Quaternion.identity;
                    ability.transform.position = MagicSpawn.transform.position;
                    ability.SetActive(true);
                    castDirection = CalculateDirection().normalized;
                    ability.transform.forward = castDirection;
                    ability.GetComponent<Rigidbody>().AddForce(castDirection * ability.GetComponent<CastedMagic>().speed, ForceMode.Impulse);

                    SoundManager.Instance.PlayAbilitySound(Ability.Fire); //Hard Coded Audio

                    break;
                case 2:
                    A2Ready = false;
                    //StartCoroutine(AbilityCooldown(AbilityIndex));
                        ability.transform.rotation = Quaternion.identity;
                        ability.transform.position = MagicSpawn.transform.position;
                        ability.SetActive(true);
                        castDirection = CalculateDirection().normalized;
                        ability.transform.forward = castDirection;
                        ability.GetComponent<Rigidbody>().AddForce(castDirection * ability.GetComponent<CastedMagic>().speed, ForceMode.Impulse);

                    SoundManager.Instance.PlayAbilitySound(Ability.Fire); //Hard Coded Audio
                    break;
                };
           
        }

    }
    private IEnumerator AbilityMultipleCast(int CastAmount, int AbilityIndex) {

        for (int i = 0; i < CastAmount; i++)
        {
            Cast(AbilityIndex);
            yield return new WaitForSeconds(0.2f);
        }
        
    }
    public Vector3 CalculateDirection()
    {
        Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 targetPoint = Physics.Raycast(ray, out var hit) ? hit.point : ray.GetPoint(100);
        Vector3 direction = targetPoint - MagicSpawn.transform.position;
        return direction;
    }
}
