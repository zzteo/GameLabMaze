using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public GameObject box;

    public GameObject arrowU;
    public GameObject arrowD;
    public GameObject arrowL;
    public GameObject arrowR;
    public GameObject[] walls;

    public ParticleSystem walkParticles;
    public AudioSource dash;


   /* private float distanceToWalls;*/


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        walls = GameObject.FindGameObjectsWithTag("wall");

/*        Calculte();*/

        StartCoroutine(arrowSelector());
       
    }


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) && GameObject.Find("arrowLeft"))
        {
            InvokeRepeating("MoveLeft", 0, 0.4f);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && GameObject.Find("arrowRight"))
        {
            InvokeRepeating("MoveRight", 0, 0.4f);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && GameObject.Find("arrowUp"))
        {
            /* MoveUp();*/     
            InvokeRepeating("MoveUp", 0, 0.4f);            
            /*CancelInvoke("MoveUp");*/
        }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && GameObject.Find("arrowDown"))
        {
            InvokeRepeating("MoveDown", 0, 0.4f);
        }

       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "leftWallBox")
        {
            Vector2 boxPosition = box.transform.position;
            boxPosition.x++;
            box.transform.position = boxPosition;
        }

        if (col.gameObject.tag == "rightWallBox")
        {
            Vector2 boxPosition = box.transform.position;
            boxPosition.x--;
            box.transform.position = boxPosition;
        }

        if (col.gameObject.tag == "upWallBox")
        {
            Vector2 boxPosition = box.transform.position;
            boxPosition.y--;
            box.transform.position = boxPosition;
        }

        if (col.gameObject.tag == "downWallBox")
        {
            Vector2 boxPosition = box.transform.position;
            boxPosition.y++;
            box.transform.position = boxPosition;
        }

        if(col.gameObject.tag == "upWallBox")
        {
            CancelInvoke("MoveUp");
            CancelInvoke("MoveDown");
            CancelInvoke("MoveRight");
            CancelInvoke("MoveLeft");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            CancelInvoke("MoveUp");
            CancelInvoke("MoveDown");
            CancelInvoke("MoveRight");
            CancelInvoke("MoveLeft");
        }
    } //kinda works,the idea is good
    void MoveUp()
    {
        rb.AddForce(new Vector2(0, 0.04f));
        Instantiate(walkParticles, this.transform.position, Quaternion.Euler(90, 0, 0));
        dash.Play();
    }
    void MoveDown()
    {
        rb.AddForce(new Vector2(0, -0.04f));
        Instantiate(walkParticles, this.transform.position, Quaternion.Euler(270, 0, 0));
        dash.Play();
    }
    void MoveLeft()
    {
        rb.AddForce(new Vector2(-0.04f, 0));
        Instantiate(walkParticles, this.transform.position, Quaternion.Euler(180, 0, 0));
        dash.Play();
    }
    void MoveRight()
    {
        rb.AddForce(new Vector2(0.04f, 0));
        Instantiate(walkParticles, this.transform.position, Quaternion.Euler(0, 0, 0));
        dash.Play();
    }
    IEnumerator arrowSelector()//Coroutine for choosing direction indicated by arrows 
    {
        while (this.gameObject != null) //change this condition, it doesnt make any sense, but it works tho xd
        {
            arrowU.SetActive(true);
            yield return new WaitForSeconds(1);
            arrowU.SetActive(false);

            arrowR.SetActive(true);
            yield return new WaitForSeconds(1);
            arrowR.SetActive(false);

            arrowD.SetActive(true);
            yield return new WaitForSeconds(1);
            arrowD.SetActive(false);

            arrowL.SetActive(true);
            yield return new WaitForSeconds(1);
            arrowL.SetActive(false);
        }
    }
      
    
    /*void Calculte() //it gives the position of every wall in the scene, didnt help me yet
    {
        for (var i = 0; i < walls.Length; i++) 
        {
      
            Debug.Log(walls[i].transform.position);
          *//*  this.transform.position.y - walls[i].transform.position.y;*//*
            }
    }*/
}
