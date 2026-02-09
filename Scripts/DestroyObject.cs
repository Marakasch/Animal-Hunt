using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private readonly float maxDistanceBottom = -7f;
    private readonly float maxDistanceTop = 22f;
    private readonly float maxDistanceHorizontal = 30f;
    //private static int _animalCounter = 0; 
  
    // Update is called once per frame
    void Update()
    {
         DestroyObjectOutOfBorder();
    }

    private void DestroyObjectOutOfBorder() 
    {
        if (transform.position.x < maxDistanceBottom || transform.position.x > maxDistanceTop)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -maxDistanceHorizontal || transform.position.z > maxDistanceHorizontal)
        {
            Destroy(gameObject);
        }
    }
}
