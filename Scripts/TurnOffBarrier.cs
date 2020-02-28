using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffBarrier : MonoBehaviour
{

    void Start()
    {

    }



    //When the ball collides with the barrier deactivate the barrier
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Ball")
        {
            Debug.Log("Collision Detected MORY");
            this.gameObject.SetActive(false);

        }



    }

  








}
