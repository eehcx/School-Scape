using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{   
    public float speed = 4f;

    Animator anim;
    Rigidbody2D rb2d;
    Vector2 mov;


    CircleCollider2D attackCollider;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        attackCollider.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {

        mov = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
/*
        Vector3 mov = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
        );
        transform.position = Vector3.MoveTowards(

            transform.position,
            transform.position+ mov,
            speed * Time.deltaTime
        );
*/

        if(mov != Vector2.zero){
        anim.SetFloat("movX",mov.x);
        anim.SetFloat("movY",mov.y);
        anim.SetBool("walking",true);
        }else{
            anim.SetBool("walking",false);
        }
        //prueba


        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool attacking = stateInfo.IsName("player_attack");
        if (Input.GetKeyDown("space") && !attacking ){
                anim.SetTrigger("attacking");
        }


        if (mov != Vector2.zero) attackCollider.offset = new Vector2(mov.x/2,mov.y/2);
    

    if (attacking){
        float playbackTime = stateInfo.normalizedTime;
        if (playbackTime > 0.33 && playbackTime < 0.66) attackCollider.enabled=true;
        else attackCollider.enabled= false;


    }
    }
    void FixedUpdate(){

        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }
}
