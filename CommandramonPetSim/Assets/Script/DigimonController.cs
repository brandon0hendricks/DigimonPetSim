using UnityEngine;

public class DigimonController : MonoBehaviour
{
    public static DigimonController instance;

    public DigimonInformation digimonInformation; //holds current digimon information
                                                  //Refrence DigimonType to get information about
                                                  //the current digimon and to determine next evolution
    
    public Animator digimonAnimator;              //Only animation changes on digimon visualy

    public bool moving;
    public bool inAction;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        digimonInformation.setDigimonInfo(this);
    }


    private void Start()
    {
        digimonAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        controlMovement();

    }


    //evolve when level is high enough and gain EXP passiveley
    void manageLevel()
    {
        if(digimonInformation.digimonType.evolveLevel <= digimonInformation.level)
        {
            startEvolution();
        }
    }

    public void gainExp(int expGained) //This is called when the player wins a battle, it adds exp and checks if the digimon should evolve
    {
        digimonInformation.exp += expGained;
        if(digimonInformation.exp >= 2)
        {
            digimonInformation.level++;
            digimonInformation.exp = 0;
            manageLevel();
        }
    }

    void startEvolution() //Starts evolution process, triggers animation and freezes movement
    {
        inAction = true;
        evolve();
        //digimonAnimator.SetTrigger("evolve");
    }


    //Function is called at the end of the evolution animation
    void evolve() //this triggers the change in digimon information and the change in the digimon visualy
    {
        if(digimonInformation.order >= digimonInformation.chaos)
        {
            digimonInformation.Evolve("order");
            digimonInformation.setDigimonInfo(this);
        }
        else
        {
            digimonInformation.Evolve("chaos");
            digimonInformation.setDigimonInfo(this);
        }
        inAction = false;
    }

    void controlMovement()
    {
        digimonAnimator.SetBool("moving", moving);
        if (inAction)
        {
            moving = false;
        }
        else
        {
            moving = true;
        }
    }

    public void Reset() //Used to reset the digimon information when the player dies or wants to start over
    {
        digimonInformation.level = 0;
        digimonInformation.order = 0;
        digimonInformation.chaos = 0;
        digimonInformation.exp = 0;
        moving = false;
    }
}

