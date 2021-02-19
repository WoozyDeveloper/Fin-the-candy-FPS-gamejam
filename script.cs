using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;


public class script : MonoBehaviour
{
    public AudioSource victory;
    public CandyCounter cc;
    public bool took;
    Candy candy;
    bool pickCandy;
    private float CameraAngle, CameraAngleSpeed, mid;
    public int speed;
    private Rigidbody player;
    public Joystick joystick1,joystick2;
    float vInput, hInput;
    Vector3 inputForce;
    const int candyNo = 10;
    public int totalCandy;
    void Start()
    {
        cc = FindObjectOfType<CandyCounter>();
        Application.targetFrameRate = 90;
        took = false;
        candy = FindObjectOfType<Candy>();
        CameraAngleSpeed = 2f;
        mid = Screen.width / 2;
        player = GetComponent<Rigidbody>();
        totalCandy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (totalCandy == 11)
            victory.Play();
        
       
        #region player_movement
        //daca nu e collider cu treptele
        transform.position = new Vector3(transform.position.x, 323f, transform.position.z);
        //player.transform.position = new Vector3(player.transform.position.x, 392.62f, player.transform.position.z);
        vInput = joystick1.Vertical;
        hInput = joystick1.Horizontal;
        Vector3 dir = Camera.main.transform.position;
        player.velocity = Camera.main.transform.forward * speed * vInput + Camera.main.transform.right * speed * hInput + new Vector3(0,1,0);
        #endregion

        #region camera rotation
        
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 0.5f - Camera.main.transform.position, Vector3.up);
        CameraAngle += joystick2.Horizontal * CameraAngleSpeed;
        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 0.1f, -3);
        StartCoroutine(Rotate(-transform.forward, joystick2.Vertical * 50f, 1.0f * Time.deltaTime));
        #endregion

        if (!victory.isPlaying && totalCandy >= 11)
            SceneManager.LoadScene(0);
    }
    public void PickPress()
    {
       if(candy.isPicked==true)
        {
            took = true;
        }
    }

    IEnumerator Rotate(Vector3 axis, float angle, float duration)
    {
        Quaternion from = Camera.main.transform.rotation;
        Quaternion to = Camera.main.transform.rotation;
        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            Camera.main.transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        Camera.main.transform.rotation = to;
    }
}
