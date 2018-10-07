using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class controller : MonoBehaviour {
    public Animator animator;
    //carecter speed
    public float topspeed = 10f;
    public float jumpforce = 8f;
    int jumps = 3;
    int scoreINT;
    public Text score;
    public Text endgame;
    public AudioClip jumpPlay;
    public AudioSource effect;

    private void Start()
    {
        effect.clip = jumpPlay;
    }


    //caracter direction
    // bool faceingRight = true;

    private void FixedUpdate()
    {
        //direction
        

        float move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topspeed, GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) & jumps > 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpforce;
            animator.SetBool("inAir", true);
            effect.Play();
            jumps--;
        }

        animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));


        
    }
    
    
    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.name == "GrassJoinHillRight2(Clone)")
        {
           animator.SetBool("inAir",false);
     
        }

        if (coll.gameObject.name == "coin(Clone)")
        {
            Destroy(coll.collider.transform.root.gameObject);
            scoreINT++;
            score.text = ""+scoreINT;
        }

        if (coll.gameObject.name == "GrassJoinHillRight2(Clone)")
        {
            jumps = 0;
            jumps = 3;
        }
        
        if (coll.gameObject.name == "DeathBarDOWN")
        {
            endgame.text = "Game Over \n Your score is: " + scoreINT;
            Destroy(GameObject.Find("spawner"));
        }
    }



    }
