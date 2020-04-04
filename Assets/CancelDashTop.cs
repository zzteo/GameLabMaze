using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelDashTop : MonoBehaviour
{
    public playerScript a;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "wall")
        {
            a.CancelInvoke("MoveUp");
            Debug.Log("collidesTop");
        }
    }
}
//this script works but gives an  error in the console, dont know exactly why 
//NullReferenceException: Object reference not set to an instance of an object
//CancelDashTop.OnTriggerEnter2D(UnityEngine.Collider2D collision) (at Assets/CancelDashTop.cs:12)
