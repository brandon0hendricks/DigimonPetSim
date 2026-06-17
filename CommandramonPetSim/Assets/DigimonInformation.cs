using UnityEngine;

[CreateAssetMenu(fileName = "DigimonInformation", menuName = "Scriptable Objects/DigimonInformation")]
public class DigimonInformation : ScriptableObject
{


    //basic information about the digimon
    public int level;
    public Sprite portrait;
    public int exp;
    public string currentForm;

    //used to detirmine next evolution
    public int chaos;
    public int order;

}
