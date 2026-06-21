using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{

    [SerializeField]Sprite[] optionImages;
    //0 is Digimon line
    //1 is chat
    //2 is evolve
    //3 is Exit
    int currentOption;
    Image Option;

    [SerializeField] GameObject TalkUi;

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
            currentOption = 3;
        }
        else
        {
            currentOption--;
        }
        AssignCurrentImage();
    }
    public void RightClick() 
    {
        if (currentOption == 3)
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
                Reset();
                TalkUi.SetActive(false);
                break;
            case 1:
               
                TalkUi.SetActive(true);
                break;
            case 2:
                if(DigimonController.instance.digimonInformation.canEvolve() == true)
                {
                    TalkUi.SetActive(false);
                    Debug.Log("Evloving");
                    DigimonController.instance.startEvolution();
                }
                break;
            case 3:

                TalkUi.SetActive(false);
                break;

        }
    }

    private void Reset()
    {
        DigimonController.instance.digimonInformation.Reset();
    }


}
