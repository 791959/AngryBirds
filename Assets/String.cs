﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class String : MonoBehaviour
{
    GameObject birdObj;
    Rigidbody2D rb;
    Vector3 launchPos;
    public Text remainText;
    public Text resultLayout;
    public GameObject layout;
    public AudioClip woodAudio;
    public AudioClip[] audioClip;
    public AudioSource audioSource;
    public AudioClip[] audioClipTwo;
    public AudioSource audioSourceTwo;
    public GameObject[] birdPre;
    public GameObject launchSpot;
    public GameObject leftS;
    public GameObject rightS;
    public int winNum = 10;

    public float vMu = 600.0f;
    public bool aimMode = false;
    Vector3 old ;
    private LineRenderer left;
    LineRenderer right;
    public static String instance;
    int num = 0;
    public Text text;
    public int remainNum=10;
    // Start is called before the first frame update
    private void Awake()
    {
        launchSpot.SetActive(false);
        launchPos = launchSpot.transform.position;

        left = leftS.GetComponent<LineRenderer>();
        left.SetPosition(0, leftS.transform.position);
        left.enabled = false;

        right = rightS.GetComponent<LineRenderer>();
        right.SetPosition(0, rightS.transform.position);
        right.enabled = false;

    }
    void Start()
    {
        instance = this;
    }
    public void AddScore()//小鸟撞到 加分的函数
    {
        num++;
        text.text = "Score:" + num;
    }
    void SetOutput(string result)
    {
        layout.SetActive(true);
        resultLayout.text = result;
    }
    // Update is called once per frame
    void Update()
    {

        if (remainNum <= 0)
        {
            SetOutput("Fail!");
        }
        if (num >= winNum)
        {
            SetOutput("Win!");
        }

        if (!aimMode)
            return;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDelta =  launchPos-mousePos ;
        mouseDelta.z = 0;
        
        float maxMagnitude = this.GetComponent<CircleCollider2D>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            // mousePos = Camera.main.WorldToScreenPoint(mousePos);
            mouseDelta = old;
           // mouseDelta.magnitude = maxMagnitude;
        }
        else
        {
            old = mouseDelta;
        }

        birdObj.transform.position = launchPos - mouseDelta;
        left.SetPosition(1, birdObj.transform.position);
        right.SetPosition(1, birdObj.transform.position);

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("2");
            aimMode = false;

            left.enabled = false;
            right.enabled = false;
            
            Vector3 a = new Vector3(-mouseDelta.x, -mouseDelta.y, 0);
            Debug.Log(a);
            Debug.Log(mouseDelta + " mouse");
            // GetComponent<Rigidbody2D>().velocity = prevVelocity;
            //rb.AddForce(a*vMu,ForceMode2D.Force);
            rb.velocity = mouseDelta* vMu;

            FollowCam.S.target = birdObj;
            birdObj = null;
            PlayAudio();
            remainNum--;
            remainText.text ="Remain Birds:"+ remainNum.ToString();
        }
    }
    private void OnMouseEnter()
    {
       // Debug.Log("1");
        launchSpot.SetActive(true);
    }
    private void OnMouseExit()
    {
        launchSpot.SetActive(false);
    }
    private void OnMouseDown()
    {
        aimMode = true;
        left.enabled = true;
        right.enabled = true;

        birdObj = Instantiate(birdPre[Random.Range(0,birdPre.Length)]);
        birdObj.transform.position = launchPos;

        rb = birdObj.GetComponent<Rigidbody2D>();
       // rb.bodyType = RigidbodyType2D.Kinematic;
        launchSpot.SetActive(false);
    }
    public void PlayAudio()
    {
        audioSource.clip = audioClip[Random.Range(0, audioClip.Length)];
        audioSource.Play();
    }
    public void DieAudio(int i)
    {
        if (i == 0)
        {
            audioSourceTwo.clip = audioClipTwo[Random.Range(0, audioClipTwo.Length-1)];
        }
        else
        {
            audioSourceTwo.clip = audioClipTwo[2];
        }
        audioSourceTwo.Play();
    }
    public void PlayWoodAudio()
    {
        audioSource.clip = woodAudio;
        audioSource.Play();
    }
}
