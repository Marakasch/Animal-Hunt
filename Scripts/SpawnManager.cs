using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject titleScreen;
    public GameObject playerHealthBar;
    public GameObject gameHud;
    public GameObject endScreen;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI difficultyText;
    private readonly float rndSpawnRangeHorizontal = 10f;
    private readonly float spawnPosX = -3f;
    
    private readonly float rndSpawnRangeBottom = 5f;
    private readonly float rndSpawnRangeTop = 17.8f;
    private readonly float spawnPosZ = 25f;
    
    private float timer;
    private float difficultyTimer;
    public int spawnInterval = 3;

    public bool isGameActive;
    
    
    void Start()
    {
        difficultyText.text = $"Difficulty: Easy";
        scoreText.text = $"Score: 0";
        //InvokeRepeating("SpawnRandomAnimal", 2, 1.5f) simple solution to spawn objects
    }
    
    
    // Update is called once per frame
    void Update()
    {
       AnimalSpawner();
    }

    private void AnimalSpawner()
    {
        if (isGameActive)
        {
            timer += Time.deltaTime;
            timer = SpawnRandomAnimal(timer, spawnInterval);
            
            difficultyTimer += Time.deltaTime;
            spawnInterval = IncreaseDifficulty(difficultyTimer, spawnInterval);
        }
    }
    private float SpawnRandomAnimal(float spawnTimer, float currentSpawnInterval)
    {
        if (spawnTimer >= currentSpawnInterval)
        {
            Vector3 rndPosBottom = new Vector3(spawnPosX, 0, Random.Range(-rndSpawnRangeHorizontal, rndSpawnRangeHorizontal));
            Vector3 rndPosLeft = new Vector3(Random.Range(rndSpawnRangeBottom, rndSpawnRangeTop), 0, -spawnPosZ);
            Vector3 rndPosRight = new Vector3(Random.Range(rndSpawnRangeBottom, rndSpawnRangeTop), 0, spawnPosZ);
            
            Quaternion bottomRotation = Quaternion.Euler(0, 90, 0);
            Quaternion leftRotation = Quaternion.Euler(0, 0, 0);
            Quaternion rightRotation = Quaternion.Euler(0, -180, 0);
            
            Instantiate(animalPrefabs[Random.Range(0, animalPrefabs.Length)], rndPosBottom, bottomRotation);
            Instantiate(animalPrefabs[Random.Range(0, animalPrefabs.Length)], rndPosLeft, leftRotation);
            Instantiate(animalPrefabs[Random.Range(0, animalPrefabs.Length)], rndPosRight, rightRotation);

            return 0f;
        }
        return spawnTimer;
    }
    
    private int IncreaseDifficulty(float currentDifficultyTime, int currentSpawnInterval)
    {
        int roundedTime = Mathf.RoundToInt(currentDifficultyTime);
        
        if (roundedTime == 15 && currentSpawnInterval == 3)
        {
            difficultyText.text = $"Difficulty: Medium";
            currentSpawnInterval = 2;
        }
        else if (roundedTime == 30 && currentSpawnInterval == 2)
        {
            difficultyText.text = $"Difficulty: Hard";
            currentSpawnInterval = 1;
        }
        
        return currentSpawnInterval;
    }

    public void StarGame()
    {
        isGameActive = true;
        titleScreen.SetActive(false);
        playerHealthBar.SetActive(true);
        gameHud.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GameOver(int score)
    {
        endScreen.SetActive(true);
        isGameActive = false;
        gameHud.SetActive(false);
        playerHealthBar.SetActive(false);
        finalScoreText.text = $"Final Score: {score}";
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
