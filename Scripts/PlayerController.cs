using System;
using UnityEngine;
    
public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float playerSpeed = 25f;
    private readonly float beginBorderZ = 16f;
    private readonly float topBeginBorderX = 18f;
    private readonly float bottomBeginBorderX = 5f;
    public GameObject projectilePrefab;
    private SpawnManager spawnManager;

    private void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnManager.isGameActive)
        {
            BorderZAxis();
            BorderXAxis();
            PlayerMovement();
        }
    }

    private void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * (Time.deltaTime * playerSpeed * horizontalInput));
        transform.Translate(Vector3.forward * (Time.deltaTime * playerSpeed * verticalInput));
        FireProjectile();
    }
    
    private void FireProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Instantiate(projectilePrefab, transform.position + Vector3.up * 1.2f, projectilePrefab.transform.rotation);
        }
    }

    private void BorderXAxis()
    {
        if(transform.position.x < bottomBeginBorderX) 
        {
            transform.position = new Vector3(bottomBeginBorderX, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > topBeginBorderX) 
        {
            transform.position = new Vector3(topBeginBorderX, transform.position.y, transform.position.z);
        }
    }

    private void BorderZAxis()
    {
        if(transform.position.z < -beginBorderZ) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -beginBorderZ);
        }
        else if(transform.position.z > beginBorderZ) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, beginBorderZ);
        }
    }
}
