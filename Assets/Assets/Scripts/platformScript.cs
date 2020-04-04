using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour
{

    public GameObject door;
    public ParticleSystem doorParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "box")
        {
            Instantiate(doorParticles, door.transform.position, Quaternion.identity);
            Destroy(door);
            Debug.Log("platforma a detectat cutia");
        }
    }
}
