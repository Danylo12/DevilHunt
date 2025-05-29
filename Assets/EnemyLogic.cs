using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
	[SerializeField] public float speed = 20.0f;
	[SerializeField] public float minDist = 1.5f;
	public Transform target;

	bool attackNow = true;
	double n = 0;
	public Player player;
	public float EnemymaxHealth = 20f;
	public float EnemyCurrentHealth;
	


	// Use this for initialization
	void Start()
	{

		// if no target specified, assume the player
		if (target == null)
		{

			if (GameObject.FindWithTag("Player") != null)
			{
				target = GameObject.FindWithTag("Player").GetComponent<Transform>();
				player = GameObject.FindWithTag("Player").GetComponent<Player>();
			}

		}

	}
		
	

	// Update is called once per frame
	void Update()
	{
		n += 0.01;
		//Debug.Log(n);
		if (n >= 7f)
        {
			Debug.Log("On the House");
			attackNow = true;
			n = 0; 
        }
		float distance = Vector2.Distance(transform.position, target.position);

		if (distance > minDist)
		{
			transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

		}
		else if (distance < minDist)
        {
            if (attackNow)
            {
				player.TakeDamage(10);
				player.checkAndGameOver();
				attackNow = false;
            }
        }


	}
		

	// Set the target of the chaser
	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}

	public void EnemyTakeDamage(float EnemyDamage)
    {
		EnemyCurrentHealth -= EnemyDamage;
		Debug.Log(EnemyCurrentHealth);
	}
	




}

