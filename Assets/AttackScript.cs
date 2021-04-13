using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

    public Animator animator;

    public Transform attackPoint;

    public float attackRange = 0.5f;

    public LayerMask enemyLayers;

    public int attackDamage = 40;

    public float attackRate = 2f;

    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update () {
        if (Time.time >= nextAttackTime) {
            if (Input.GetKeyDown (KeyCode.Q)) {
                Attack ();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }

    void Attack () {
        //Attack Animation (make sure create an attack trigger for Terri in animator)
        animator.SetTrigger ("Attack");

        //Hit box
        Collider[] hitEnemies = Physics.OverlapSphere (attackPoint.position, attackRange, enemyLayers);

        //Damagaing Enemies
        foreach (Collider enemy in hitEnemies) {
            enemy.GetComponent<EnemyHP> ().TakeDamage (attackDamage);
        }

    }

    // Show hit box Gizmos
    void OnDrawGizmosSelected () {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere (attackPoint.position, attackRange);
    }

}