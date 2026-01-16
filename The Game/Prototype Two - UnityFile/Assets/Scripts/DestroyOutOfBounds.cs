using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float bottomBound = -30;
    private float animaltopBound = 40;
    private float animalbottomBound = -40;

    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < bottomBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > animaltopBound) { 
            Destroy(gameObject);
        }
        else if (transform.position.x < animalbottomBound)
        {
            Destroy(gameObject);
        }
    }
}
