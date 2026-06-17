using System.Security.Cryptography;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "DigimonType", menuName = "Scriptable Objects/DigimonType")]
public class DigimonType : ScriptableObject
{
    public string typeName;
    public RuntimeAnimatorController animator;
    public int evolveLevel;
    public Sprite digimonPortrait;
    enum DigimonTypeEnum { Vaccine, Data, Virus };
    DigimonTypeEnum digimonTypeEnum;
    enum DigimonAttributeEnum { Fire, Water, Earth, Wind, Light, Dark };
    DigimonAttributeEnum digimonAttributeEnum;
    enum DigimonLevelEnum { Rookie, Champion, Ultimate, Mega };
    DigimonLevelEnum digimonLevelEnum;

    public DigimonType OrderEvolution;
    public DigimonType ChaosEvolution;
    public DigimonType junkEvolution;



}
