using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 8f;
    public float damage = 0f;

    // Start is called before the first frame update
    void Start() {
        
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
        }
        else if(collision.tag == "Player") {
            GameManager.GM.tankStats.Hit(damage);
            Destroy(gameObject);
        }
    }
}
