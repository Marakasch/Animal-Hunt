using UnityEngine;

public class MoveInThreeDirections : MonoBehaviour
{
    private float minSpeed = 5f;
    private float maxSpeed = 10f;
    
    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.eulerAngles.y <= 0)
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * Random.Range(minSpeed,maxSpeed)), Space.World);
        }
        else if (transform.rotation.eulerAngles.y >= 180)
        {
            transform.Translate(Vector3.back * (Time.deltaTime * Random.Range(minSpeed,maxSpeed)), Space.World);
        }
        else
        {
            transform.Translate(Vector3.right * (Time.deltaTime * Random.Range(minSpeed,maxSpeed)), Space.World);
        }
    }
}

