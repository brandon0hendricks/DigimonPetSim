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
    private Vector3 originalScale;

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
        originalScale = gameObject.transform.localScale;
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
        moving = inAction ? true : false; 
    }
    public void StartGainingExpCoroutine()
    {
        digimonInformation.gainExp(1);
        StopCoroutine(ExpGain);
        ExpGain = flavorGainExp();
        transform.localScale = Vector3.one;
        StartCoroutine(ExpGain);
    }

    //Adds impact to gaining exp
    IEnumerator flavorGainExp()
    {
        Vector3 targetScale = originalScale * 1.05f;
        float duration = 0.1f;
        float elapsed = 0f;

        // Punch Out
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / duration);
            yield return null;
        }

        // Return back to standard sizing safely
        elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsed / duration);
            yield return null;
        }

        transform.localScale = originalScale;
    }
}

