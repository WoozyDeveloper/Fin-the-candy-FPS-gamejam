﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandyCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public Text score;
    void Awake()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
   
}
