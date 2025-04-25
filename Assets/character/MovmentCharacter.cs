using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentCharacter : MonoBehaviour
{
    GameObject character;
    bool Move;
    private Animator MyAnimator;
    GameObject hips;
    private int y;
    private float timer;
    bool stop;


    // Start is called before the first frame update
    void Start()
    {
        stop = false;
        timer = 6;
        Move = false;
        character = this.gameObject;
        MyAnimator = GetComponent<Animator>();
        hips = GameObject.Find("mixamorig1:Hips");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {           
            transform.position = new Vector3(hips.transform.position.x, 0, hips.transform.position.z - 0.01119749f);
            if (transform.position.x < 0)
            {
                y = -90;
            }
            else
            {
                y = 90;
            }
            character.transform.localEulerAngles = new Vector3(0, y, 0);
            Move = true;     
        }

        if (Move)
        {
            character.transform.position += transform.forward * (2*Time.deltaTime);
            timer -= Time.deltaTime;
            if(timer<= 0)
            {
                Move = false;
                stop = true;
                timer = 4;
            }
        }

        MyAnimator.SetBool("Move",Move);
        MyAnimator.SetBool("Stop", stop);
    }
}
