
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HUDBarUpdate : MonoBehaviour
{
    public Image HPfillBar;
    public TextMeshProUGUI HPfillBarText;
    public Image SPfillBar;
    public TextMeshProUGUI SPfillBarText;
    public Image MPfillBar;
    public TextMeshProUGUI MPfillBarText;
    public bool showMaxValue = false;
    
    private float HPmaxVal;
    private float HPVal;
    private float SPmaxVal;
    private float SPVal;
    private float MPmaxVal;
    private float MPVal;

    public GameObject HPBar;
    public GameObject SPBar;
    public GameObject MPBar;

    public GameObject player;
    private SPSystem staminaSys;
    private HealthSystem healthSys;
    private ManaSystem manaSys;
    private void Awake()
    {
        staminaSys = player.GetComponent<SPSystem>();
        healthSys = player.GetComponent<HealthSystem>();
        manaSys = player.GetComponent<ManaSystem>();
                    HPmaxVal = healthSys.HP;
                    SPmaxVal = staminaSys.SP;
                    MPmaxVal = manaSys.MP;

    }
    private void FixedUpdate()
    {
                HPVal = healthSys.HP;
                UpdateFieldHP();
               
                SPVal = staminaSys.SP;
                UpdateFieldSP();
              
                MPVal = manaSys.MP;
                UpdateFieldMP();    
    }
    private void UpdateFieldHP()
    {
        
        HPfillBar.fillAmount = Mathf.Clamp(HPVal / HPmaxVal, 0f, 1f);
        if (showMaxValue)
            HPfillBarText.text = "HP"+ $" {(int)HPVal}/{(int)HPmaxVal}";
        else HPfillBarText.text = "HP"+ $" {(int)HPVal}";
    }
    private void UpdateFieldSP()
    {

        SPfillBar.fillAmount = Mathf.Clamp(SPVal / SPmaxVal, 0f, 1f);
        if (showMaxValue)
            SPfillBarText.text = "SP"+ $" {(int)SPVal}/{(int)SPmaxVal}";
        else SPfillBarText.text = "SP"+ $" {(int)SPVal}";
    }
    private void UpdateFieldMP()
    {

        MPfillBar.fillAmount = Mathf.Clamp(MPVal / MPmaxVal, 0f, 1f);
        if (showMaxValue)
            MPfillBarText.text = "MP"+ $" {(int)MPVal}/{(int)MPmaxVal}";
        else MPfillBarText.text = "MP"+ $" {(int)MPVal}";
    }

}
