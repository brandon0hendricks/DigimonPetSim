using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    //Components
    [SerializeField] public TextMeshProUGUI dialogueText;
    [HideInInspector] public static bool inDialogue = false;

    private float textSpeed = 0.04f;
    public GameObject dialogueChoices;

    [SerializeField] private TextMeshProUGUI orderChoice;
    [SerializeField] private TextMeshProUGUI chaoseChoice;

    public Image digimonPortrait;

    public ConversationTypes[] conversationTypes;

    private void OnEnable()
    {
        getRandomConversation();
        dialogueChoices.SetActive(false);
    }

    private void OnDisable()
    {
        
    }

    void getRandomConversation()
    {
        int randomIndex = Random.Range(0, conversationTypes.Length);
        activateDialogue(conversationTypes[randomIndex].conversation);
        orderChoice.text = conversationTypes[randomIndex].orderResponse;
        chaoseChoice.text = conversationTypes[randomIndex].chaosResponse;

    }

    public void activateDialogue(string textToDisplay) //Start Dialogue
    {
        StartCoroutine(enableDialogue(textToDisplay));
    }

    private IEnumerator enableDialogue(string textToDisplay)
    {
        Debug.Log("Dialogue Box Activated");
        dialogueText.text = ""; //clear text;

        char[] chars = textToDisplay.ToCharArray(); //characters to be displayed;
        for (int b = 0; b < chars.Length; b++)
        {
            dialogueText.text += chars[b];
            yield return new WaitForSeconds(textSpeed);
        }

        dialogueChoices.SetActive(true);
       
        textToDisplay = ""; //clear text to display;
    }

    public void orderOption()
    {
        DigimonController.instance.digimonInformation.order++;
        dialogueText.text = "";
        dialogueChoices.SetActive(false);
        getRandomConversation();
    }

    public void chaosOption()
    {
        DigimonController.instance.digimonInformation.chaos++;
        dialogueText.text = "";
        dialogueChoices.SetActive(false);
        getRandomConversation();
    }

}
