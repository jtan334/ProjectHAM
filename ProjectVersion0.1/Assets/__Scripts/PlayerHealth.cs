﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    static public PlayerHealth H;

    public Animator animator;

    //Original method
    //public int maxHealth = 100;
    //int currentHealth;

    //My Method
    public static int MAXHEALTH = 100;
    int currentHealth;

    public void TakeDamage(int damage)
    {
        Debug.Log("Hit");

        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Takes damage after colliding with enemies
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit");

            currentHealth = currentHealth - 25;

            animator.SetTrigger("Hurt");

            if (currentHealth < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Singleton check
        if (H == null)
        {
            H = this;
        }
        else
        {
            Debug.LogError("There can not be one Player Health Script!");
        }

        currentHealth = MAXHEALTH;
    }
}
