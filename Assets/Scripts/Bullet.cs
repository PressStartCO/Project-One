using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    [SerializeField]
    float speed;
    Vector2 direction;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = direction * speed;
	}

    public void Initialize (Vector2 _direction){
        direction = _direction;
    }

    //Destruir a Bala se ela sumir da camera.
    private void OnBecameInvisible(){
        Destroy(gameObject);
    }

    //Destruir a Bala se ela atingir alguma coisa.
    private void OnTriggerEnter2D(Collider2D anotherO){
        if(anotherO.gameObject.tag == "Enemy"){
            Destroy(gameObject);
        }
    }
}
