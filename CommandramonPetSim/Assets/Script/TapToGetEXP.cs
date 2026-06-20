using UnityEngine;
using UnityEngine.InputSystem;

public class TapToGetEXP : MonoBehaviour
{
    InputAction tap;
    InputAction tapPosition;

    Vector2 touchPosition;
    [SerializeField]GameObject Exp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        tap = InputSystem.actions.FindAction("Tap");
        tapPosition = InputSystem.actions.FindAction("TapPosition");
    }


    private void OnEnable()
    {
        tap.performed += TapPressed;
    }

    private void OnDisable()
    {
        tap.performed -= TapPressed;
    }

    void TapPressed(InputAction.CallbackContext context)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(tapPosition.ReadValue<Vector2>());
        position.z = transform.position.z;
        Debug.Log(position);
        GameObject expCreated = Instantiate(Exp, position, Quaternion.identity);
        expCreated.GetComponent<ExpBehavior>().digimon = transform;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Exp"))
        {
            DigimonController.instance.StartGainingExpCoroutine();
            Destroy(collision.gameObject);
        }
    }
}
