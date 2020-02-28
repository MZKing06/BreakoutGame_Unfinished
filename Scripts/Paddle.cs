using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float paddleSpeed = 20f;

    Vector3 paddlePos = new Vector3(0, -12.5f, 0);

    private GM _gameManager;

    public GameObject barrier;


    //reference to the GM script
    //_gameManager = GameObject.Find("GM").GetComponent<GM>();

    void FixedUpdate()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * Time.deltaTime * paddleSpeed);
        paddlePos = new Vector3(Mathf.Clamp(xPos, -16f, 15.8f), -12.57f, 0f);
        transform.position = paddlePos;
    }

    //When Brick gets Destroyed
    //Spawn a powerup
    //if paddle collects power up
    //add one extra life

    //(will need to talk to the GM, the bricks script and the paddle script)!!!!


    //check the collision of the paddle with the powerup
    void OnTriggerEnter(Collider other)
    {
        //if the tag is powerup add an extra life and update the lives text then deactivate the powerup object
        if  (other.tag == "Powerup")
        {
            GM.instance.lives = GM.instance.lives + 1;
            GM.instance.textMeshLives.text = "Lives: " + GM.instance.lives;
            GM.instance.livesArray[GM.instance.lives-1].SetActive(true);
            other.gameObject.SetActive(false);

        }

        if (other.tag == "Shield")
        {
            GM.instance.barrier.gameObject.SetActive(true);
            other.gameObject.SetActive(false);
            //barrier.gameObject.SetActive(true);
        

        }








    }

}