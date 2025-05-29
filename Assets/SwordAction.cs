using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAction : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject sword;
    [SerializeField] ParticleSystem particle;
    public ParticleLogic particlesSys;

    Rigidbody2D rb;


    public Player player;

    public EnemyLogic enemy;

    public float enemyCount;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            enemy.EnemyTakeDamage(10);
            particlesSys.ParticlePosition(other.transform);
            particle.Play();
            player.Set();
            if(enemy.EnemyCurrentHealth <= 0)
            {
                enemy.EnemyCurrentHealth = 20f;
                Destroy(other.gameObject);
                enemyCount++;

            }
            
        }
    }



}
