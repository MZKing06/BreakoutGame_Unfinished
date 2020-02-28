﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {

        GM.instance.LoseLife();
        other.gameObject.SetActive(false);
    }

    

}
