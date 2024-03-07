using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points = 3;
    public delegate void EnemyDied(int pointWorth);
    public static event EnemyDied OnEnemyDied;
    public GameObject laser;

    private float stutterTime;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Ouch!");
        if(collision.gameObject.name == "Bullet(Clone)"){
            Destroy(collision.gameObject);
            OnEnemyDied.Invoke(points);
            GetComponent<Animator>().SetTrigger("Death Trigger");
        }
    }

    void DeathAnimationComplete()
    {
        // Debug.Log("Enemy died");
        Destroy(gameObject);
    }

    void Update()
    {
        if(gameObject.name == "Enemy Rank 4(Clone)" && Time.time - stutterTime >= 3.0f){
            stutterTime = Time.time;
            Vector3 laserPos = new Vector3(transform.position.x, transform.position.y - 1, 0f);
            GameObject shot = Instantiate(laser, laserPos, Quaternion.identity);
            // Debug.Log("Bang!");
            Destroy(shot, 3f);
        }
    }
}
