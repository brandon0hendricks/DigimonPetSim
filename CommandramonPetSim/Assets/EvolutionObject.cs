using UnityEngine;

public class EvolutionObject : MonoBehaviour
{
    void changeform() //used in animation to change form 
    {
        DigimonController.instance.GetForm(); 
    }

    void disable()
    {
        gameObject.SetActive(false);
    }
}
