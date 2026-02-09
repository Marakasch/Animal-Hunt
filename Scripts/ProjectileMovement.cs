using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 10f;
    public float roation = 10f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * (Time.deltaTime * speed), Space.World);
        transform.Rotate(Vector3.up * roation);
    }
}
