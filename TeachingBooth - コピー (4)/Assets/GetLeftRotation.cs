﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLeftRotation : MonoBehaviour
{
    static public float leftrotx,leftrotz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);


    }
}
