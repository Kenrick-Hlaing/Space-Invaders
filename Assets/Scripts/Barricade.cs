using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    public int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Ouch!");
        Destroy(other.gameObject);
        GotHit();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Ouch!");
        if(collision.gameObject.name == "Bullet(Clone)"){
            Destroy(collision.gameObject);
            GotHit();
        }
    }

    void GotHit()
    {
        lives--;
        if(lives > 0){
            transform.localScale = new Vector3(transform.localScale.x - 0.2f, transform.localScale.x - 0.2f, transform.localScale.x - 0.2f);
        } else {
            Destroy(gameObject);
        }
        
    }
}
