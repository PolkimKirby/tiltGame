﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltControl : MonoBehaviour
{
    Vector3 dir;
    Rigidbody rb;

    public bool debug = true;
    public int speed = 20;

    public Transform arrowIndicator;

    public Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dir = Vector3.zero;

        dir.x = Input.acceleration.x;
        dir.z = Input.acceleration.y;
        

        if(debug) {
            Debug.DrawRay(this.transform.position, dir * 2, Color.red, 0.5f);
        }
    }

    void LateUpdate() {
        arrowIndicator.rotation = Quaternion.LookRotation(dir, Vector3.up);
        Vector3 scale = Vector3.one;
        scale.z = dir.magnitude;
        arrowIndicator.localScale = scale;
    }

    void FixedUpdate() {
        rb.AddForce(dir * speed);
    }
    

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("CustomCam")) {
            mainCam.gameObject.SetActive(false);
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("CustomCam")) {
            mainCam.gameObject.SetActive(true);
            other.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
