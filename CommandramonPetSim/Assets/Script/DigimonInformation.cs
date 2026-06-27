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
    public int maxLevel;
    public DigimonType digimonType;

    //used to detirmine next evolution
    public int chaos;
    public int order;
    
    //Used to revert to previous Evolutions
    DigimonType[] unlockedEvolutions;

    [SerializeField]DigimonType baseDigimonType;

    //changes animator
    public void setDigimonAnimator(DigimonController controller)
    {
        controller.digimonAnimator.runtimeAnimatorController = digimonType.animator;
        maxExp = (baseMaxExp + level);
        getEvolveLevel();
    }

    void changeDigimonType(DigimonType newType)
    {
        digimonType = newType;  
    }
    public void gainExp(int expGained) //This is called when the player wins a battle, it adds exp and checks if the digimon should evolve
    {
        if (exp < maxExp)
        {
            exp += expGained;
        } 
        if (exp >= maxExp && !canEvolve() && level <= maxLevel)
        {
            level++;
            exp = 0;
            maxExp = (baseMaxExp + level);
        }
    }

    public bool canEvolve()
    {
        return level >= evolveLevel ? true : false;
    }

    void getEvolveLevel()
    {
        switch (digimonType.digimonLevelEnum)
        {
            case DigimonType.DigimonLevelEnum.InTraining:
                evolveLevel = 5; 
            break;
            case DigimonType.DigimonLevelEnum.Rookie:
                evolveLevel = 10;
                break;
            case DigimonType.DigimonLevelEnum.Champion:
                evolveLevel = 15;
                break;
            case DigimonType.DigimonLevelEnum.Ultimate:
                evolveLevel = 90;
                break;
            case DigimonType.DigimonLevelEnum.Mega:
                evolveLevel = 90;
                break;
        }
    }

    public void Reset()
    {
        changeDigimonType(baseDigimonType);
        maxLevel += 20;
        setDigimonAnimator(DigimonController.instance);
        order = 0;
        chaos = 0;
        level = 0;
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
    

