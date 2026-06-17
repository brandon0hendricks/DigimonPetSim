using UnityEngine;

public class bkgSpawner : MonoBehaviour
{

    public GameObject bkgobject;
    private float spawnTimer = 0f;


    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > 5f && DigimonController.instance.moving) 
        {
            createBkgObject();
            spawnTimer = 0f;
        }
    }

    private void Start()
    {
        createBkgObject();
    }
    void createBkgObject()
    {
        Instantiate(bkgobject, gameObject.transform.position, Quaternion.identity);
    }
}
