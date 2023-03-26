using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo_movimiento : MonoBehaviour
{   
    public bool EsDerecha;
    public float Horizontal;
    public float contadorT;
    public float Tiempo_Cambio = 2f;
    public float speed = 4f;

    Animator anim;
    Rigidbody2D rb2d;
    Vector2 mov;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        contadorT=Tiempo_Cambio;
    }

    // Update is called once per frame
    void Update(){
       
        if(EsDerecha==true){
            Horizontal=1;
        }
         if(EsDerecha==false){
              Horizontal=-1;
         }

        mov = new Vector2(
            Horizontal,
            0
        );
        
        if(mov != Vector2.zero){
        anim.SetFloat("MovX",mov.x);
        anim.SetFloat("MovY",mov.y);
        anim.SetBool("walking",true);
        }else{
            anim.SetBool("walking",false);
        }


contadorT-= Time.deltaTime;



    if (contadorT<=0){
         contadorT=Tiempo_Cambio;
    EsDerecha=!EsDerecha;
    }

    }
        //prueba
    void FixedUpdate(){

        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }    

}

