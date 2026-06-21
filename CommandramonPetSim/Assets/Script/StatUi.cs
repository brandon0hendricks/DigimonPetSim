using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatUi : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI orderValue;
    [SerializeField] TextMeshProUGUI chaosValue;

    void Update()
    {
        orderValue.text = DigimonController.instance.digimonInformation.order.ToString();
        chaosValue.text = DigimonController.instance.digimonInformation.chaos.ToString();
    }
}
