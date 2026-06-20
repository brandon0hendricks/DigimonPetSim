using System.Collections;
using UnityEngine;

public class ExpBehavior : MonoBehaviour
{

    //Variables for moving
    public Transform digimon;
    Vector2 targetPosition;
    Vector2 startDirection;
    Vector2 currentDirection;
    Rigidbody2D rb;


    [SerializeField] float angleRange;
    [SerializeField] float directionChangeSpeed;
    [SerializeField] float baseSpeed;

    private void Start()
    {
        targetPosition = digimon.position - transform.position;
        getStartDirection();
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(targetPosition);
        StartCoroutine(Accelerate());
       
    }

    //Gets Starting direction
    void getStartDirection()
    {
        Vector2 direction = (digimon.position - transform.position).normalized * -1;
        float randomAngle = Random.Range(-angleRange, angleRange);
        startDirection = Quaternion.Euler(0,0, randomAngle) * direction;
        currentDirection = startDirection;
    }

    void ChangeDirection()
    {
        targetPosition = digimon.position - transform.position;
        currentDirection = Vector2.Lerp(currentDirection, targetPosition, Time.deltaTime * directionChangeSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = (currentDirection * baseSpeed);
        ChangeDirection();
    }

    IEnumerator Accelerate()
    {
        yield return new WaitForSeconds(.8f);
        while (baseSpeed <= 10)
        {
            baseSpeed += 1.5f;
            yield return new WaitForSeconds(.1f);
        }
    }
}
