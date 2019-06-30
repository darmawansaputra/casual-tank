using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {
    public Transform player;
    public float fireCooldown = 2f;
    public BossBullet bullet;
    public Transform bulletPoint;

    public GameObject panelPlayer;

    public float bulletSpeed = 12f;
    public float bulletDamage = 35f;

    public float maxHealth = 500f;
    public float healthRegen = 5f;

    public Image healthBar;

    float currentHealth = 500f;
    float fireCooldownCounter = 0f;

    // Start is called before the first frame update
    void Start() {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update() {
        Health();
        DoStronger();

        if(CheckDistance()) {
            LookPlayer();

            if(fireCooldownCounter <= 0f)
                Fire();
        }

        fireCooldownCounter -= Time.deltaTime;
    }

    void DoStronger() {
        if(currentHealth == maxHealth) {
            maxHealth += 0.03f * Time.deltaTime;
            currentHealth = maxHealth;
        }
        else {
            maxHealth += 0.03f * Time.deltaTime;
        }

        healthRegen += 0.03f * Time.deltaTime;
        bulletSpeed += 0.05f * Time.deltaTime;
        bulletDamage += 0.03f * Time.deltaTime;
    }

    void Health() {
        if(currentHealth < maxHealth) {
            currentHealth += healthRegen * Time.deltaTime;
            healthBar.fillAmount = currentHealth / maxHealth;

            if(!healthBar.transform.parent.parent.gameObject.activeSelf)
                healthBar.transform.parent.parent.gameObject.SetActive(true);

            if (currentHealth >= maxHealth)
                healthBar.transform.parent.parent.gameObject.SetActive(false);
        }
    }

    void Fire() {
        fireCooldownCounter = fireCooldown;

        BossBullet tb = Instantiate(bullet, bulletPoint.position, transform.rotation);
        tb.damage = bulletDamage;
        tb.speed = bulletSpeed;
        Destroy(tb.gameObject, 5f);
    }

    bool CheckDistance() {
        float dist = Vector3.Distance(player.position, transform.position);
  
        if(dist <= 20)
            return true;

        return false;
    }

    void LookPlayer() {
        var dir = player.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    public void Hit(float damage) {
        currentHealth -= damage;

        if(currentHealth <= 0f) {
            print("Player Win");

            Time.timeScale = 0;
            panelPlayer.SetActive(true);

            GameManager.GM.SaveLeaderboard();
        }
    }
}
