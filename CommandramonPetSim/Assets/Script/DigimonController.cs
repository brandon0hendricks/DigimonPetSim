using UnityEngine;


//Responsible for controll over player digimon
//Holds current information and it's state
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
        digimonInformation.setDigimonAnimator(this);
    }


    private void Start()
    {
        digimonAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        controlMovement();
        if(digimonInformation.level == 1 && digimonInformation.digimonType.typeName != "Commandramon")
        {
            startEvolution();
        }


    }

    

    void startEvolution() //Starts evolution process, triggers animation and freezes movement
    {
        inAction = true;
        digimonAnimator.SetTrigger("evolve");
    }


    //Function is called at the end of the evolution animation
    void evolve() //this triggers the change in digimon information and the change in the digimon visualy
    {
        if(digimonInformation.order >= digimonInformation.chaos)
        {
            digimonInformation.Evolve("order");
            digimonInformation.setDigimonAnimator(this);
        }
        else
        {
            digimonInformation.Evolve("chaos");
            digimonInformation.setDigimonAnimator(this);
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

