using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//þessi scrip átti upprunalega að vera bara controller er varð svo bara fyrir allt sem tengdist player

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
        effect.clip = jumpPlay; // stilli sound effect
    }


   
    private void FixedUpdate()
    {
        //direction
        // takkar sem skal nota

        float move = Input.GetAxis("Horizontal"); // unity takka sett
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topspeed, GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) & jumps > 0) // ef space er notað er addað force up
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpforce;
            animator.SetBool("inAir", true); // jumping animation
            effect.Play();// mario jump sound effect
            jumps--;//tek burtu eitt jump í hvert skipti
        }

        animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal"))); //running animation


        
    }
    
    
    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.name == "GrassJoinHillRight2(Clone)")
        {
           animator.SetBool("inAir",false); // end jumping animation ef hann lendir á platformi
            jumps = 0;
            jumps = 3;

        }

        if (coll.gameObject.name == "coin(Clone)") // ef hann nær coin
        {
            Destroy(coll.collider.transform.root.gameObject);//eyði coin
            scoreINT++; //bæti við score
            score.text = ""+scoreINT;//print score
        }

        
        if (coll.gameObject.name == "DeathBarDOWN")
        {
            endgame.text = "Game Over \n Your score is: " + scoreINT;
            Destroy(GameObject.Find("spawner"));
            //hætti að spawna platforms þegar player er eytt
        }
    }



    }
