using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    //Components
    [SerializeField] public TextMeshProUGUI dialogueText;
    [HideInInspector] public static bool inDialogue = false;

    private float textSpeed = 0.01f;
    public GameObject dialogueChoices;
    public void activateDialogue(string textToDisplay) //Start Dialogue
    {
        StartCoroutine(enableDialogue(textToDisplay));
    }

    private IEnumerator enableDialogue(string textToDisplay)
    {
        Debug.Log("Dialogue Box Activated");
        dialogueText.text = ""; //clear text;
        Debug.Log("Dialogue Box Enabled");

        char[] chars = textToDisplay.ToCharArray(); //characters to be displayed;
        for (int b = 0; b < chars.Length; b++)
        {
            dialogueText.text += chars[b];
            yield return new WaitForSeconds(textSpeed);
        }

        dialogueChoices.SetActive(true);
       
        textToDisplay = ""; //clear text to display;
    }

}
