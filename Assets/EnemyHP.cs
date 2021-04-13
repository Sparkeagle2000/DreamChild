using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start () {
        currentHealth = maxHealth;

    }

    public void TakeDamage (int damage) {
        currentHealth -= damage;
        
        //Need the Hurt Trigger in the enemy animator
        animator.SetTrigger ("Hurt");
        if (currentHealth <= 0) {
            Die ();
        }
    }

    void Die () {
        Debug.Log ("Enemy Died!");
        //Die Animation (need to create the IsDead bool)
        animator.SetBool ("IsDead", true);
        GetComponent<Collider> ().enabled = false;
        this.enabled = false;
    }
}