using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float move;
    public float fastmove;
    bool lookingRight = true;
    bool IsShoting = false;
    [SerializeField]
    private GameObject BulletPosition;
    [SerializeField]
    private GameObject Bullet;
    Animator animator;


    void Start () {
        IsShoting = false;
    }
	
	void Update () {

		    Rigidbody2D rididbody = GetComponent<Rigidbody2D>();	

		//movimento_horizontal

			move = Input.GetAxis("Horizontal");
			rididbody.velocity = new Vector2(move*fastmove,rididbody.velocity.y);
       
        //virar o sprite para a esqueda.

            if (move < 0){
                GetComponent<SpriteRenderer>().flipX = true;
                lookingRight = false;
            }
            else if(move > 0){
                GetComponent<SpriteRenderer>().flipX = false;
                lookingRight = true;
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

        if (Input.GetMouseButtonDown(0))
        {
            IsShoting = true;

            Shot();
        }


        //Setando Animação de Atirar
        if (IsShoting == true){
            GetComponent<Animator>().SetBool("IsShoting", true);
        }
        else{
            GetComponent<Animator>().SetBool("IsShoting", false);
        }

    }

   /* private void FixedUpdate() {
        Action();
    }

    void Action(){
        if (IsShoting == true && !animator.GetCurrentAnimatorStateInfo(0).IsName("Shot")){
            animator.SetBool("IsShoting", true);
            Shot();
        }
    }
    */

    //Execução do tiro.
    void Shot(){
        GameObject tmpBullet = (GameObject)Instantiate(Bullet, BulletPosition.transform.position, Quaternion.identity);
        
        if (lookingRight){
            tmpBullet.GetComponent<Bullet>().Initialize(Vector2.right);
        }
        else {
            tmpBullet.GetComponent<Bullet>().Initialize(Vector2.left);
        }
        
    }

    //Rester a animação do tiro (Ainda não funcionando bem).
    void reset(){
        IsShoting = false;
    }
}
