using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ExpBar : MonoBehaviour
{


    [SerializeField]Image fillBar;

    //Values for fill
    float maxExp;
    float currentExp;
    float fillValue;
    float targetAmount;

    int level;
    [SerializeField]TextMeshProUGUI leveltext;

    public float fillspeed = 2f;


    private void Start()
    {
        fillBar.fillAmount = currentExp;
    }
    void getValues()
    {
        maxExp = DigimonController.instance.digimonInformation.maxExp;
        currentExp = DigimonController.instance.digimonInformation.exp;
        level = DigimonController.instance.digimonInformation.level;
    }

    // Update is called once per frame
    void Update()
    {
        getCurrentFill();
        fillBar.fillAmount = fillValue;
        leveltext.text = level.ToString();
        getValues();
    }

    void getCurrentFill()
    {
        if (currentExp != 0)
        {
            targetAmount = currentExp / maxExp;
        }
        else
        {
            targetAmount = 0;
        }
        fillValue = Mathf.Lerp(fillValue, targetAmount, fillspeed);
    }
}
