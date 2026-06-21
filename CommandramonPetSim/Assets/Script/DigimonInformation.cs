using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "DigimonInformation", menuName = "Scriptable Objects/DigimonInformation")]
public class DigimonInformation : ScriptableObject
{
    //This holds a current Digimon information

    //basic information about the digimon
    public int level;
    [SerializeField]int evolveLevel = 1;
    public float exp;
    [HideInInspector]public float maxExp;
    public float baseMaxExp = 5;

    public DigimonType digimonType;

    //used to detirmine next evolution
    public int chaos;
    public int order;


    private void Awake()
    {
        maxExp = (baseMaxExp + level);
    }
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
        if (exp >= maxExp)
        {
            maxExp = (baseMaxExp + level);
            level++;
            exp = 0;
        }
    }

    public bool canEvolve()
    {
        if (level >= evolveLevel)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void getEvolveLevel()
    {
        switch (digimonType.digimonLevelEnum)
        {
            case DigimonType.DigimonLevelEnum.InTraining:
                evolveLevel = 1; 
            break;
            case DigimonType.DigimonLevelEnum.Rookie:
                evolveLevel = 2;
                break;
            case DigimonType.DigimonLevelEnum.Champion:
                evolveLevel = 3;
                break;
            case DigimonType.DigimonLevelEnum.Ultimate:
                evolveLevel = 3;
                break;
            case DigimonType.DigimonLevelEnum.Mega:
                evolveLevel = 4;
                break;
        }
    }

    public void Evolve() //gets the next evolutin and sets the new digimon type
    {
        if(order > chaos)
        {
            changeDigimonType(digimonType.OrderEvolution);
        }
        else if(order < chaos)
        {
            changeDigimonType(digimonType.ChaosEvolution);
        }
        else
        {
            changeDigimonType(digimonType.junkEvolution);
        }
        getEvolveLevel();
    }
}
    

