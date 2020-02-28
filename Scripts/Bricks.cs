using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public GameObject brickParticle;

    public int hit = 0;

    //material we want to change
    public Material[] damagedMaterial;

    //the gameobject (each individual brick mesh renderer)
    private Renderer childColor;

    public GameObject SpawnPowerup;

    public GameObject shieldPW;

    private int  chance;

    private int randomPowerup;

    void Awake()
    {
        childColor = GetComponent<Renderer>();
        childColor.enabled = true;

        hit = 0;

        chance = Random.Range(0, 100);

        randomPowerup = Random.Range(0, 100);
    }



    void OnCollisionEnter(Collision other)
    {
        Debug.Log("something has been hit");

        hit += 1;

        //Brick = 1 Hit
        Check1Hit();

        //Brick = 2 Hit
        Check2Hit();

        //Brick = 3 Hit
        Check3Hit();

        //Brick = 4 Hit
        Check4Hit();

        //Brick = 5hit
        Check5Hit();
    }

    IEnumerator SpawnParticles()
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        GM.instance.DestroyBrick();
        gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
    }

    //This brick only takes 1 collision to be destroyed
    void Check1Hit()
    {
        if (this.gameObject.tag == ("Hit1") && hit == 1)
        {
            StartCoroutine("SpawnParticles");
        }
    }

    void Check2Hit()
    {
        if (this.gameObject.tag == ("Brick_X2") && hit == 1)
        {
            childColor.sharedMaterial = damagedMaterial[0];
        }
        else if (this.gameObject.tag == ("Brick_X2") && hit == 2)
        {
            Instantiate(brickParticle, transform.position, Quaternion.identity);
            print(chance);
            print(randomPowerup);
            GM.instance.DestroyBrick();

            if (chance <= 15)
            {
                if (chance <= 15 && randomPowerup <= 50)
                {
                    Instantiate(SpawnPowerup, transform.position, Quaternion.identity);
                }
                else if (chance <= 15 && randomPowerup >= 51)
                {
                    Instantiate(shieldPW, transform.position, Quaternion.identity);
                }
            }
            gameObject.SetActive(false);
        }
    }
    //Check for 3 hit brick
    void Check3Hit()
    {
        if (this.gameObject.tag == ("Brick_X3") && hit == 0)
        {
            childColor.sharedMaterial = damagedMaterial[2];
        }
        if (this.gameObject.tag == ("Brick_X3") && hit == 1)
        {
            childColor.sharedMaterial = damagedMaterial[1];
        }
        else if (this.gameObject.tag == ("Brick_X3") && hit == 2)
        {
            childColor.sharedMaterial = damagedMaterial[0];
        }
        else if (this.gameObject.tag == ("Brick_X3") && hit == 3)
        {
            Instantiate(brickParticle, transform.position, Quaternion.identity);
            print(chance);
            print(randomPowerup);
            GM.instance.DestroyBrick();

            if (chance <= 20)
            {

                if (chance <= 20 && randomPowerup <= 50)
                {
                    Instantiate(SpawnPowerup, transform.position, Quaternion.identity);
                }
                else if (chance <= 20 && randomPowerup >= 51)
                {
                    Instantiate(shieldPW, transform.position, Quaternion.identity);
                }
            }
            gameObject.SetActive(false);
        }
    }

    void Check4Hit()
    {
        if (this.gameObject.tag == ("Brick_X4") && hit == 1)
        {
            childColor.sharedMaterial = damagedMaterial[2];
        }
        else if (this.gameObject.tag == ("Brick_X4") && hit == 2)
        {
            childColor.sharedMaterial = damagedMaterial[1];
        }
        else if (this.gameObject.tag == ("Brick_X4") && hit == 3)
        {
            childColor.sharedMaterial = damagedMaterial[0];
        }      
        else if (this.gameObject.tag == ("Brick_X4") && (hit == 4))
        {
            Instantiate(brickParticle, transform.position, Quaternion.identity);
            GM.instance.DestroyBrick();

            if (chance <= 30)
            {
                if (chance <= 30 && randomPowerup <= 50)
                {
                    Instantiate(SpawnPowerup, transform.position, Quaternion.identity);
                }
                else if (chance <= 30 && randomPowerup >= 51)
                {
                    Instantiate(shieldPW, transform.position, Quaternion.identity);
                }
            }
            gameObject.SetActive(false);
        }
    }

    void Check5Hit()
    {
        if (this.gameObject.tag == ("Brick_X5") && hit == 1)
        {
            childColor.sharedMaterial = damagedMaterial[3];
        }
        else if (this.gameObject.tag == ("Brick_X5") && hit == 2)
        {
            childColor.sharedMaterial = damagedMaterial[2];
        }
        else if (this.gameObject.tag == ("Brick_X5") && hit == 3)
        {
            childColor.sharedMaterial = damagedMaterial[1];
        }
        else if (this.gameObject.tag == ("Brick_X5") && hit == 4)
        {
            childColor.sharedMaterial = damagedMaterial[0];
        }
        else if (this.gameObject.tag == ("Brick_X5") && (hit == 5))
        {
            Instantiate(brickParticle, transform.position, Quaternion.identity);
            GM.instance.DestroyBrick();

            if (chance <= 35)
            {
                if (chance <= 35 && randomPowerup <= 50)
                {
                    Instantiate(SpawnPowerup, transform.position, Quaternion.identity);
                }
                else if (chance <= 35 && randomPowerup >= 51)
                {
                    Instantiate(shieldPW, transform.position, Quaternion.identity);
                }
            }
            gameObject.SetActive(false);
        }
    }


}





