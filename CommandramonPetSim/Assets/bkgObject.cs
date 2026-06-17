using UnityEngine;

public class bkgObject : MonoBehaviour
{

    public float speed = .5f; // Speed at which the background moves

    public Sprite[] sprites;
    float timer = 0f;

    private void Start()
    {
        // Randomly select a sprite from the array and assign it to the SpriteRenderer
        if (sprites.Length > 0)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        }
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        // Move the background to the left
        if (DigimonController.instance.moving)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        // If the background has moved too far to the left, reset its position
        if (transform.position.x < -20f) // Adjust this value based on your background width
        {
            transform.position = new Vector3(20f, transform.position.y, transform.position.z); // Reset to the right side
        }
        if(timer > 65f)
        {
            Destroy(gameObject);
        }
    }

}
