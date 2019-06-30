using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {
    public TankBullet bulletPrefab;
    public Transform bulletPoint;

    AudioSource fireAudio;

    TankStats stats;
    float fireReloadCount = 0f;

	// Use this for initialization
	void Awake () {
        stats = GetComponent<TankStats>();
        fireAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //Movement
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * stats.movementSpeed;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * stats.movementSpeed;

        transform.parent.Translate(x, y, 0, Space.World);

        //Rotation
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angle;

        transform.rotation = Quaternion.Euler(0, 0, angleDeg - 90f);

        if(Input.GetMouseButton(0)) {
            Fire();
        }
        fireReloadCount -= Time.deltaTime;
    }

    void Fire() {
        if(fireReloadCount <= 0f) {
            bulletPrefab.speed = stats.bulletSpeed;
            bulletPrefab.damage = stats.bulletDamage;
            TankBullet tb = Instantiate(bulletPrefab, bulletPoint.position, transform.rotation);
            Destroy(tb.gameObject, stats.bulletDurability);
            fireReloadCount = stats.reloadSpeed;

            fireAudio.Play();
        }
    }
    
}
