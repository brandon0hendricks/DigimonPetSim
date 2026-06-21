using System.Collections;
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

    IEnumerator ExpGain;

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
        ExpGain = flavorGainExp();
    }
    private void Update()
    {
        controlMovement();
    }

    

    public void startEvolution() //Starts evolution process, triggers animation and freezes movement
    {
        inAction = true;
        digimonAnimator.SetTrigger("evolve");
    }


    //Function is called at the end of the evolution animation
    void Evolve() //this triggers the change in digimon information and the change in the digimon visualy
    {
        digimonInformation.Evolve();
        digimonInformation.setDigimonAnimator(this);
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

    public void StartGainingExpCoroutine()
    {

        StopCoroutine(ExpGain);
        ExpGain = flavorGainExp();
        transform.localScale = Vector3.one;
        StartCoroutine(ExpGain);
    }

    //Adds impact to gaining exp
    IEnumerator flavorGainExp()
    {
        Vector3 sizeincrease = transform.localScale * 1.02f;
        while(transform.localScale != sizeincrease)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, sizeincrease, .15f);
            yield return null;
        }
        digimonInformation.gainExp(1);
        while (transform.localScale != Vector3.one)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, .15f);
            yield return null;
        }
        transform.localScale = Vector3.one;
    }
}

