using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    //speed this powerup moves down at
    [SerializeField]
    private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        


    }





    // Update is called once per frame
    void Update()
    {
        //it moves down on its own
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        //if this powerup hits <-20 on the y axis deactivate this gameobject
        if (transform.position.y < -20)
        {
            this.gameObject.SetActive(false);

        }

    }





}
