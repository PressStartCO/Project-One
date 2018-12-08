using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float fastmove;
    bool IsShoting;
    [SerializeField]
    private GameObject BulletPosition;
    [SerializeField]
    private GameObject Bullet;
    Animator animator;


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

			if(Input.GetKeyDown(KeyCode.Space)){
                rididbody.AddForce(new Vector2(0,200));
            }

        //Atirar.

        if (Input.GetMouseButtonDown(0)){
            IsShoting = true;
            Action();
        }

        reset();
    }

    private void FixedUpdate() {
        Action();
    }

    void Action(){
        if (IsShoting == true && !animator.GetCurrentAnimatorStateInfo(1).IsName("Shot")){
            animator.SetTrigger("Shot");
            Shot();
        }
    }

    void Shot(){
        GameObject tmpBullet = (GameObject)(Instantiate(Bullet, BulletPosition.transform.position, Quaternion.identity));
        if(GetComponent<SpriteRenderer>().flipX = false){
            tmpBullet.GetComponent<Bullet>().Initialize(Vector2.right);
        }
        else{
            tmpBullet.GetComponent<Bullet>().Initialize(Vector2.left);
        }
    }

    void reset(){
        IsShoting = false;
    }
}
