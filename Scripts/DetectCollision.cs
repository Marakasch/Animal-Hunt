using System;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollision : MonoBehaviour
{
    public Slider animalHealthSlider;
    private DetectCollisionPlayer dcPlayer;
    private float animalHealth;
    private float animalmaxHealth = 100f;
    private static int animalDamage = 33;

    void Start()
    {
        animalHealth = animalmaxHealth;
        dcPlayer = GameObject.Find("Player").GetComponent<DetectCollisionPlayer>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //Collision with Animal
        if (other.CompareTag("BoneProjectile"))
        {
            animalHealth -= animalDamage;
            if (animalHealthSlider.value != animalHealth)
            {
                animalHealthSlider.value = animalHealth;
            }
            Destroy(other.gameObject);

            if (animalHealth <= 1)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                dcPlayer.IncreaseScore();
            }
        }
    }
}
