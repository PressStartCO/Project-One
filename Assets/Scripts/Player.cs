using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
public float fastmove;
	void Start () {
			
	}
	
	void Update () {
		    Rigidbody2D rididbody = GetComponent<Rigidbody2D>();	
		//movimento_horizontal
			float move = Input.GetAxis("Horizontal");
			rididbody.velocity = new Vector2(move*fastmove,rididbody.velocity.y);
        //virar o sprite para a esqueda.
            if (move < 0){
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if(move > 0){
                GetComponent<SpriteRenderer>().flipX = false;
            }
        //Animação Walking.
        if(move != 0) {
            GetComponent<Animator>().SetBool("IsWalking", true);
        }
        else {
            GetComponent<Animator>().SetBool("IsWalking", false);
        }
		//jump
			if(Input.GetKeyDown(KeyCode.Space))
			{rididbody.AddForce(new Vector2(0,200));}
    }
}
