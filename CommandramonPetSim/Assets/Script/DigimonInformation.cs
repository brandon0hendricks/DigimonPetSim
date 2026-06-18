using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "DigimonInformation", menuName = "Scriptable Objects/DigimonInformation")]
public class DigimonInformation : ScriptableObject
{
    //This holds a current Digimon information

    //basic information about the digimon
    public int level;
    public int exp;

    public DigimonType digimonType;

    //used to detirmine next evolution
    public int chaos;
    public int order;


    //changes animator
    public void setDigimonAnimator(DigimonController controller)
    {
        controller.digimonAnimator.runtimeAnimatorController = digimonType.animator;
    }

    void changeDigimonType(DigimonType newType)
    {
        digimonType = newType;
    }
    public void gainExp(int expGained) //This is called when the player wins a battle, it adds exp and checks if the digimon should evolve
    {
        exp += expGained;
        if (exp >= 2)
        {
            level++;
            exp = 0;
        }
    }

    public void Evolve(string evolutionType) //gets the next evolutin and sets the new digimon type
    {
        switch (evolutionType)
        {
            case "order":
                changeDigimonType(digimonType.OrderEvolution);
                break;
            case "chaos":
                changeDigimonType(digimonType.ChaosEvolution);
                break;
            default:
                changeDigimonType(digimonType.junkEvolution);
                break;
        }
    }
}
    

