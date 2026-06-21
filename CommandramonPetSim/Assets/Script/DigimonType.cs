using System.Security.Cryptography;
using UnityEngine;

[CreateAssetMenu(fileName = "DigimonType", menuName = "Scriptable Objects/DigimonType")]
public class DigimonType : ScriptableObject
{
    public string typeName;
    public RuntimeAnimatorController animator;
    public Sprite digimonPortrait;
    enum DigimonTypeEnum { Vaccine, Data, Virus };
    DigimonTypeEnum digimonTypeEnum;
    enum DigimonAttributeEnum { Fire, Water, Earth, Wind, Light, Dark };
    DigimonAttributeEnum digimonAttributeEnum;
    public enum DigimonLevelEnum { InTraining, Rookie, Champion, Ultimate, Mega };
    public DigimonLevelEnum digimonLevelEnum;

    public DigimonType OrderEvolution;
    public DigimonType ChaosEvolution;
    public DigimonType junkEvolution;



}
