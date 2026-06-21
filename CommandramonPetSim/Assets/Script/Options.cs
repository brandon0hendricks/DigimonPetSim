using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{

    [SerializeField]Sprite[] optionImages;
    //0 is Digimon line
    //1 is chat
    //2 is evolve
    int currentOption;
    Image Option;

    private void Awake()
    {
        Option = GetComponent<Image>();
    }
    void AssignCurrentImage()
    {
        Option.sprite = optionImages[currentOption];
    }
    public void LeftClick()
    {
        if (currentOption == 0)
        {
            currentOption = optionImages.Length;
        }
        else
        {
            currentOption--;
        }
        AssignCurrentImage();
    }
    public void RightClick() 
    {
        if (currentOption == optionImages.Length)
        {
            currentOption = 0;
        }
        else
        {
            currentOption++;
        }
        AssignCurrentImage();
    }

    public void OptionClick()
    {
        switch (currentOption)
        {
            case 0:
                Debug.Log("Digimon Line");
                break;
            case 1:
                Debug.Log("Start Chat");
                break;
            case 2:
                if(DigimonController.instance.digimonInformation.canEvolve() == true)
                {
                    Debug.Log("Evloving");
                    DigimonController.instance.startEvolution();
                }
                break;

        }
    }


}
