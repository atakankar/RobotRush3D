using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    private bool laneChange = false;
    private bool CanJump = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("State", 1);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, PlayerStats.PlayerSpeed);
        StartCoroutine(stopLaneCH());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a") && laneChange == false && transform.position.x > -.9 && CanJump == true)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-2, 0, PlayerStats.PlayerSpeed);
            laneChange = true;
            StartCoroutine(stopLaneCH());
        }
        else if (Input.GetKey("d") && laneChange == false && transform.position.x < .9 && CanJump == true)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(2, 0, PlayerStats.PlayerSpeed);
            laneChange = true;
            StartCoroutine(stopLaneCH());
        }

        else if (Input.GetKey("space") && CanJump == true && laneChange == false)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 1.5f, PlayerStats.PlayerSpeed);
            CanJump = false;
            animator.SetInteger("State", 2);
            StartCoroutine(stopJump());
        }
        else if(GetComponent<Rigidbody>().velocity.z != PlayerStats.PlayerSpeed && CanJump == true && laneChange == false)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, PlayerStats.PlayerSpeed);
        }
    }

    IEnumerator stopJump()
    {
        yield return new WaitForSeconds(.75f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, -1.5f, PlayerStats.PlayerSpeed);
        yield return new WaitForSeconds(.75f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, PlayerStats.PlayerSpeed);
        CanJump = true;
        animator.SetInteger("State", 1);
    }

    IEnumerator stopLaneCH()
    {
        yield return new WaitForSeconds(.5f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, PlayerStats.PlayerSpeed);
        laneChange = false;
    }

    //Brackeys Kodları
    /*
    public Rigidbody PlayerBody;
    public float forwardForce = 1000f;
    public float sideWaysForce = 500f;


    void FixedUpdate()
    {
        PlayerBody.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            PlayerBody.AddForce(sideWaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            PlayerBody.AddForce(-sideWaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

    }*/





}
