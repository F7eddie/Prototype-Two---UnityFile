using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class KeepToBounds : MonoBehaviour
{

    public float MaxX = 10;
    public float MinX = -10;
    void Update()
    {
        if (transform.position.x < MinX)
        {
            transform.position = new Vector3(MinX, transform.position.y, transform.position.z);
        }
        if (transform.position.x > MaxX)
        {
            transform.position = new Vector3(MaxX, transform.position.y, transform.position.z);
        }
    }
}
