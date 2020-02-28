using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Deactivate");

    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
        
    }



}
