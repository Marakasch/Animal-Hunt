using UnityEngine;
using UnityEngine.UI;

public class DetectCollisionPlayer : MonoBehaviour
{
    private SpawnManager spawnManager;
    public Slider playerHealthSlider;
    private readonly float playerMaxHealth = 100f;
    public float playerHealth;
    
    private int playerLives = 4;
    private int score;
    private readonly int playerDamage = 25;

    void Start()
    {
        playerHealth = playerMaxHealth;
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(("BoneProjectile")))
        {
            playerHealth -= playerDamage;
            if (playerHealthSlider.value != playerHealth)
            {
                playerHealthSlider.value = playerHealth;
            }
            
            playerLives--;
            if(playerLives == 0)
            {
                spawnManager.GameOver(score);
            }
           
            if (playerHealth <= 1)
            {
                Destroy(gameObject);
            } 
        }
    }

    public void IncreaseScore()
    {
        score += 10;
        spawnManager.scoreText.text = $"Score: {score}";
    }
}
