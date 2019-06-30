using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankStats : MonoBehaviour {
    public GameObject panelBoss;
    public float movementSpeed = 4f;
    public float bulletSpeed = 8f;
    public float reloadSpeed = 0.75f;
    public float bulletDurability = 1f;
    public float bulletDamage = 10f;
    public float healthRegen = 1f;
    public float maxHealth = 100f;
    public float bodyDamage = 0.5f;

    public float experience = 0f;
    public int lastExpIndex = -1;
    public int level = 1;
    public int pointStat = 0;

    public Image healthBar;

    float currentHealth;

    GameManager GM;

    // Use this for initialization
    void Start () {
        GM = GameManager.GM;
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentHealth < maxHealth) {
            currentHealth += healthRegen * Time.deltaTime;
            healthBar.fillAmount = currentHealth / maxHealth;

            if(!healthBar.transform.parent.parent.gameObject.activeSelf)
                healthBar.transform.parent.parent.gameObject.SetActive(true);

            if (currentHealth >= maxHealth)
                healthBar.transform.parent.parent.gameObject.SetActive(false);
        }
	}

    public void AddExp(float xp) {
        if (level >= 29 || xp <= 0)
            return;

        experience += xp;
        bool next = false;

        do {
            next = false;

            print(GM);

            if(experience >= GM.expTarget[lastExpIndex + 1]) {
                level++;
                lastExpIndex++;
                pointStat++;
                next = true;

                print("Level Up To " + level);
            }
        }
        while (next);

        UIManager.UM.UpdateUIProfile(level, experience, GM.expTarget[lastExpIndex + 1]);
        UIManager.UM.UpdateUIUpgrade(pointStat);
    }

    void OnCollisionStay2D(Collision2D collision) {
        if (collision.transform.tag == "Farm") {
            //Decrease the farm health
            Vector2 dir = (collision.transform.position - transform.position).normalized;
            GameManager.GM.tankStats.AddExp(collision.transform.GetComponent<Farm>().Hit(bodyDamage * Time.deltaTime, dir));

            //Decrease the tank health
            currentHealth -= (bodyDamage * 2 / 3) * Time.deltaTime;

            if(currentHealth <= 0f) {
                print("Boss Win");

                Time.timeScale = 0;
                panelBoss.SetActive(true);
            }
        }
    }

    public void Hit(float damage) {
        currentHealth -= damage;

        if(currentHealth <= 0f) {
            print("Boss Win");

            Time.timeScale = 0;
            panelBoss.SetActive(true);
        }
    }
}
