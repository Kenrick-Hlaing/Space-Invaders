using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 5f;
  	public GameObject bullet;
  	public Transform shottingOffset;

  	void Start()
  	{
        // subscribe to the OnEmenyDied Event
	    Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
  	}

    void OnDestroy()
    {
        // Before the player object is deleted, unsubscribe from the Event
        Enemy.OnEnemyDied -= EnemyOnOnEnemyDied;
    }

    void EnemyOnOnEnemyDied(int pointWorth)
	{
  		Debug.Log($"player received 'EnemyDied' worth {pointWorth}");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            // Debug.Log("Bang!");
            Destroy(shot, 3f);
            GetComponent<Animator>().SetTrigger("Shoot Trigger");
        }

        float horizontalMovement = Input.GetAxis("Horizontal");
        if(Math.Abs(transform.position.x) <= 9){
            Vector3 newPosition = transform.position + new Vector3(horizontalMovement, 0f, 0f) 
                * movementSpeed * Time.deltaTime;
            transform.position = newPosition;
        } else {
            if(transform.position.x > 0){
                transform.position = new Vector3(9f, -4f, 0f);
            } else {
                transform.position = new Vector3(-9f, -4f, 0f);
            }
            
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Ouch!");
        Destroy(other.gameObject);
        GetComponent<Animator>().SetTrigger("Death Trigger");
    }

    void DeathAnimationComplete()
    {
        Debug.Log("Player died");
        Destroy(gameObject);
    }
}
