using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;




public class Player : MonoBehaviour
{

    // Start is called before the first frame update

    [SerializeField] float Speed;
    [SerializeField] GameObject sword;
    [SerializeField] float force = 15f;
    [SerializeField] Rigidbody2D rb;
    public Transform swordTrans;
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth = 100;

    public Health healthbar;
    public Energybar energyBar;

    Vector3 mousePos;
    public Camera cam;
    Vector3 ourScreenPos;
    Vector3 Napryam;

    public GameObject gameOver;
    // Reference to the prefab

    // Define the range for random positions
    Vector2 spawnAreaMin; // Bottom-left corner
    Vector2 spawnAreaMax; // Top-right corner
    public GameObject prefabToSpawn;
    EnemyLogic enemyLogic;

    public float energy = 100f;
    





    void Start()
    {
        InvokeRepeating("RefillEnergy", 1f, 2f);
        prefabToSpawn = Resources.Load("Enemy") as GameObject;
        Debug.Log(prefabToSpawn);
        InvokeRepeating("SpawnObject", 1f, 2f);
        cam = cam.GetComponent<Camera>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        energyBar.SetMaxEnergy(100f);
        ourScreenPos = cam.WorldToScreenPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        transform.Translate(moveX, moveY, 0);
        if (Input.GetMouseButtonDown(0) && energy >= 10)
        {
            sword.SetActive(true);
            Attacking();
            Invoke("Set", 2f);
        }

    }

    public void Set()
    {
        sword.SetActive(false);
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);
    }

    public void Attacking()
    {
        energy -= 10;
        energyBar.SetEnergy(energy);
        Debug.Log(energy);
        mousePos = Input.mousePosition;
        ourScreenPos.z = 0;
        mousePos.z = 0;
        Napryam = mousePos - ourScreenPos;
        Napryam.Normalize();
        swordTrans.right = Napryam;
        rb.AddForce(Napryam * force);
        swordTrans.position = new Vector3(transform.position.x + 1f, transform.position.y + 0.41f, 0);

    }
    

    public void checkAndGameOver()
    {
        if (currentHealth <= 0)
        {
            gameOver.SetActive(true);
            Invoke("goToMenu", 2f);
            
        }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public void SpawnObject()
    {
        spawnAreaMin.x = transform.position.x - 7;
        spawnAreaMin.y = transform.position.y - 4;
        spawnAreaMax.x = transform.position.x + 6;
        spawnAreaMax.y = transform.position.y + 6;
        
        // Generate a random position within the defined area
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 randomPosition = new Vector2(randomX, randomY);

        // Instantiate the prefab at the random position
        
        Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);

    }

    public void RefillEnergy()
    {
        energy += 10;
        energyBar.SetEnergy(energy);

    }

    public void goToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

}

