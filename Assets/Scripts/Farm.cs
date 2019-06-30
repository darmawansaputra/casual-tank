using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Farm : MonoBehaviour {
    public float health;
    public float exp;
    public float forcePower;
    public Image healthBar;

    float currentHealth;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        currentHealth = health;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float Hit(float dmg, Vector2 dir) {
        print("Hit Farm");

        currentHealth -= dmg;
        transform.GetChild(0).gameObject.SetActive(true);
        healthBar.fillAmount = currentHealth / health;
        //rb.AddForce(dir * 5);

        if(currentHealth <= 0) {
            Destroy(gameObject);
            return exp;
        }

        return 0f;
    }
}
