using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBullet : MonoBehaviour {
    public float speed = 8f;
    public float damage = 0f;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, speed * Time.deltaTime, 0);
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Collider") {
            Destroy(gameObject);
        }
        else if(collision.tag == "Farm") {
            Vector2 dir = (collision.transform.position - transform.position).normalized;
            Destroy(gameObject);
            GameManager.GM.tankStats.AddExp(collision.GetComponent<Farm>().Hit(damage, dir));
        }
        else if(collision.tag == "Boss") {
            collision.GetComponent<Boss>().Hit(damage);
            Destroy(gameObject);
        }
    }
}
