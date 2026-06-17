using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject StatsMenu;
    [SerializeField] private TextMeshProUGUI orderValue;
    [SerializeField] private TextMeshProUGUI chaosValue;
    [SerializeField] private TextMeshProUGUI levelValue;

    [SerializeField] private GameObject TalkMenu;
    [SerializeField] private GameObject MainMenuUI;

    public DialogueBox dialogueBox;
    [SerializeField] private TextMeshProUGUI orderChoice;
    [SerializeField] private TextMeshProUGUI chaoseChoice;

    public DigimonInformation digimonInformation;

    public ConversationTypes[] conversationTypes;

    public Image[] digimonPortraits;


    void assignPortrait()
    {
        for(int i = 0; i < digimonPortraits.Length; i++)
        {
            digimonPortraits[i].sprite = digimonInformation.portrait;
        }
    }
    private void Start()
    {
        digimonInformation = DigimonController.instance.digimonInformation; //sets information needed
        dialogueBox = gameObject.GetComponent<DialogueBox>();
        assignPortrait();
    }
    public void ActivateStats()
    {
        StatsMenu.SetActive(true);
        MainMenuUI.SetActive(false);
        assignPortrait();
    }

    void getRandomConversation()
    {
        int randomIndex = Random.Range(0, conversationTypes.Length);
        dialogueBox.activateDialogue(conversationTypes[randomIndex].conversation);
        orderChoice.text = conversationTypes[randomIndex].orderResponse;
        chaoseChoice.text = conversationTypes[randomIndex].chaosResponse;

    }
    public void ActivateTalk()
    {
        TalkMenu.SetActive(true);
        dialogueBox.dialogueChoices.SetActive(false);
        getRandomConversation();
        MainMenuUI.SetActive(false);
        DigimonController.instance.StopMoving();
        assignPortrait();
    }
    public void ExitStats()
    {
        StatsMenu.SetActive(false);
        MainMenuUI.SetActive(true);
    }
    public void ExitTalk()
    {
      
        TalkMenu.SetActive(false);
        MainMenuUI.SetActive(true);
        DigimonController.instance.StartMoving();
    }
    public void OrderChoice()
    {
        digimonInformation.order++;
        digimonInformation.exp++;
        ExitTalk();
    }
    public void ChoasChoice()
    {
        digimonInformation.chaos++;
        digimonInformation.exp++;
        ExitTalk();
    }

    public void Reset()
    {
        DigimonController.instance.Reset();
    }

    private void Update()
    {
        orderValue.text = digimonInformation.order.ToString();
        chaosValue.text = digimonInformation.chaos.ToString();
        levelValue.text = digimonInformation.level.ToString();
    }
}
