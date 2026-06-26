using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ExpBar : MonoBehaviour
{
    [SerializeField] Image fillBar;
    [SerializeField] TextMeshProUGUI leveltext;
    //Values for fill
    float maxExp;
    float currentExp;

    float fillValue;
    public float fillspeed = 2f;
    float targetAmount;


    DigimonInformation digimonInfo;
    int level;

    private void Start()
    {
        fillBar.fillAmount = currentExp;
        digimonInfo = DigimonController.instance.digimonInformation;

    }
    void getValues()
    {
        maxExp = digimonInfo.maxExp;
        currentExp = digimonInfo.exp;
        level = digimonInfo.level;
    }

    // Update is called once per frame
    void Update()
    {
        getValues();
        getCurrentFill();
        fillBar.fillAmount = fillValue;
        leveltext.text = level.ToString();
    }

    void getCurrentFill()
    {
        targetAmount = currentExp != 0 ? currentExp / maxExp : 0;

        fillBar.color = digimonInfo.canEvolve() ? Color.red : Color.white;
  
        fillValue = Mathf.Lerp(fillValue, targetAmount, fillspeed);
    }
}
