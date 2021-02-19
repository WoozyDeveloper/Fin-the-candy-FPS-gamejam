using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Candy : MonoBehaviour
{
    getAudio audioMan;
    public Button collect;
    public bool isPicked;
    script pl;
    // Start is called before the first frame update
    void Start()
    {
        audioMan = FindObjectOfType<getAudio>();
        isPicked = false;
        pl = FindObjectOfType<script>();
    }

  
    public void OnCollisionStay(Collision collision)
    {
        isPicked = true;
        if (pl.took == true && collision.gameObject.tag == "Player")
        {
            Debug.Log(pl.took);
            pl.totalCandy++;
            audioMan.PlayWrapper();
            pl.cc.score.text = pl.totalCandy + " / 12 wrappers";
            Destroy(gameObject);
            pl.took = false;
        }
    }
  
}
