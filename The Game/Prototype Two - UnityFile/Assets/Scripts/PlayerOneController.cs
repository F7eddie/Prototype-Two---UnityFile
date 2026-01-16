using UnityEngine;

public class PlayerOneController : MonoBehaviour
{
    void Start()
    {

    }

    public GameObject projectilePrefab;
    public bool canMove = false;
    public float horizontalImput;
    public float speed = 10.0f;
    public float pizzahight = 2f;


    public float MaxX = 10;
    public float MinX = -10;
    void Update()
    {
        if (!canMove)
            return;
        if (Input.GetKey(KeyCode.A))
        {
            horizontalImput = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalImput = 1;
        }
        else
        {
            horizontalImput = 0;
        }
        transform.Translate(Vector3.right * horizontalImput * Time.deltaTime * speed);
        if (transform.position.x < MinX)
        {
            transform.position = new Vector3(MinX, transform.position.y, transform.position.z);
        }
        if (transform.position.x > MaxX)
        {
            transform.position = new Vector3(MaxX, transform.position.y, transform.position.z);
        }



        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 spawnPos = transform.position;
            spawnPos.y += pizzahight;

            GameObject pizza = Instantiate(projectilePrefab, spawnPos, projectilePrefab.transform.rotation);
            pizza.tag = "Player1Pizza";
        }
    }
}