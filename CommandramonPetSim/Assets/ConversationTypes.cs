using UnityEngine;

[CreateAssetMenu(fileName = "ConversationTypes", menuName = "Scriptable Objects/ConversationTypes")]
public class ConversationTypes : ScriptableObject
{
    [TextArea(3, 10)]
    public string conversation;

    [TextArea(5, 5)]
    public string orderResponse;

    [TextArea(5, 5)]
    public string chaosResponse;
}
