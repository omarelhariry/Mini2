using UnityEngine;
using System.Collections;
using System;

public class move : MonoBehaviour {

    private int orientation;
    private float xlocation;
    private float ylocation;
    private bool run;
    private bool front;
    private bool back;
    public Animator a;
	// Use this for initialization
	void Start () {
        a = GetComponent<Animator>();
        xlocation = 0;
        ylocation = 0;
        orientation = 0;
        run = false;
        front = false;
        back = false;
    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(ylocation, 0, xlocation);
       // transform.position = new Vector3(ylocation, 0, xlocation);
        transform.Rotate(0, orientation, 0 );

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (run)
            {
                xlocation = 0.06f* Mathf.Cos(orientation * Mathf.PI / 180.0f);
                ylocation = 0.06f* Mathf.Sin(orientation * Mathf.PI / 180.0f);
            }
            else
            {
                xlocation = 0.02f* Mathf.Cos(orientation * Mathf.PI / 180.0f);
                ylocation = 0.02f* Mathf.Sin(orientation * Mathf.PI / 180.0f);
            }
            front = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            xlocation = 0;
            ylocation = 0;
            front = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            //orientation -= 10;
            orientation = -5;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            //orientation -= 10;
            orientation = 0;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            //orientation += 10;
            orientation = 5;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            //orientation += 10;
            orientation = 0;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            xlocation = -0.02f* Mathf.Cos(orientation * Mathf.PI / 180.0f);
            ylocation = -0.02f* Mathf.Sin(orientation* Mathf.PI / 180.0f);
            back = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            xlocation = 0;
            ylocation = 0;
            back = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!run && xlocation == 0.02f * Mathf.Cos(orientation * Mathf.PI / 180.0f) )
            {
                xlocation = 0.06f * Mathf.Cos(orientation * Mathf.PI / 180.0f);
                ylocation = 0.06f * Mathf.Sin(orientation * Mathf.PI / 180.0f);
                run = true;
            }
            else if (run && xlocation == 0.06f * Mathf.Cos(orientation * Mathf.PI / 180.0f))
            {
                xlocation = 0.02f * Mathf.Cos(orientation * Mathf.PI / 180.0f);
                ylocation = 0.02f * Mathf.Sin(orientation * Mathf.PI / 180.0f);
                run = false;
            }
            else
            {
                run = !run;
            }
            Debug.Log(run);
        }

        a.SetBool("walk", front);
        a.SetBool("back", back);
        a.SetBool("run", run);

    }
}
