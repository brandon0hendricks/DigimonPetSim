using UnityEngine;

public class DigimonController : MonoBehaviour
{
 
    public DigimonInformation digimonInformation;
    public static DigimonController instance;
    public GameObject evolveObject;
    public Animator digimonAnimator;
    int currentEgg = 0;
    float eggTimer = 0f;
    int levelUpExp = 5;
    float expTimer = 0f;
    public bool moving;

    public Sprite missimon;
    public Sprite commandramon;
    public Sprite hicommandramon;
    public Sprite sealsdramon;
    public Sprite tankdramon;
    public Sprite darkdramon;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        digimonAnimator = GetComponent<Animator>();
        if(digimonInformation.currentForm == null)
        {
            digimonInformation.currentForm = "Commandramon";
        }
        GetForm();
    }

    void AssignForm()
    {
        switch (digimonInformation.currentForm)
        {
            case "egg":
                digimonAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("egg");
                break;
            case "Missimon":
                digimonAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Missimon");
                digimonInformation.portrait = missimon;
                break;
            case "Commandramon":
                digimonAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Commandramon");
                digimonInformation.portrait = commandramon;
                break;
            case "Hi-Commandramon":
                digimonAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Hi-Commandramon");
                digimonInformation.portrait = hicommandramon;
                break;
            case "Sealsdramon":
                digimonAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Sealsdramon");
                digimonInformation.portrait = sealsdramon;
                break;
            case "Tankdramon":
                digimonAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Tankdramon");
                digimonInformation.portrait = tankdramon;
                break;
            case "Darkdramon":
                digimonAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Darkdramon");
                digimonInformation.portrait = darkdramon;
                break;
        }
    }

    void Evolve()
    {
        evolveObject.SetActive(true);
        saveData.instance.SaveGame();
    }

    private void Update()
    {
        expTimer += Time.deltaTime;
        if (digimonInformation.exp >= levelUpExp + (digimonInformation.level/2))
        {
            digimonInformation.level++;
            if(digimonInformation.level == 5 || digimonInformation.level == 10 || digimonInformation.level == 20 || digimonInformation.level == 25)
            {
                Evolve();
            }
            digimonInformation.exp = 0; 
        }
        if(expTimer >= 1f)
        {
            expTimer = 0f;
            digimonInformation.exp += 1;
        }

        if (digimonInformation.currentForm == "egg")
        {
            eggTime();
            Debug.Log("egg time");
        }
    }
    public void StopMoving()
    {
        digimonAnimator.SetBool("moving", false);
        moving = false;
    }
    public void StartMoving()
    {
        digimonAnimator.SetBool("moving", true);
        moving = true;
    }

    public void GetForm()
    {
        if(digimonInformation.level == 0)
        {
            digimonInformation.currentForm = "egg";
        }
        else if(digimonInformation.level <= 2)
        {
            digimonInformation.currentForm = "Missimon";
            moving = true;
        }
        else if(digimonInformation.level <= 5 && digimonInformation.level > 2)
        {
            digimonInformation.currentForm = "Commandramon";
            moving = true;
        }
        else if((digimonInformation.level >= 10 && digimonInformation.level < 15) && digimonInformation.chaos < digimonInformation.order)
        {
            digimonInformation.currentForm = "Hi-Commandramon";
            moving = true;
        }
        else if ((digimonInformation.level >= 10 && digimonInformation.level < 15) && digimonInformation.chaos >= digimonInformation.order)
        {
            digimonInformation.currentForm = "Sealsdramon";
            moving = true;
        }
        else if (digimonInformation.level >= 20 && digimonInformation.level < 25)
        {
            digimonInformation.currentForm = "Tankdramon";
            moving = true;
        }
        else if (digimonInformation.level >= 25)
        {
            digimonInformation.currentForm = "Darkdramon";
            moving = true;
        }
        AssignForm();
    }

    void eggTime()
    {
        moving = false;
        eggTimer += Time.deltaTime; 
        if(eggTimer >= 3.5f)
        {
            currentEgg++;
            digimonAnimator.SetInteger("currentEgg", currentEgg);
            eggTimer = 0f;
        }
        if(currentEgg >= 4)
        {
            digimonInformation.level = 1;
            currentEgg = 0;
            Evolve();
        }

    }

    public void Reset()
    {
        digimonInformation.level = 0;
        currentEgg = 0;
        digimonInformation.order = 0;
        digimonInformation.chaos = 0;
        digimonInformation.exp = 0;
        moving = false;
        GetForm();
    }
}

