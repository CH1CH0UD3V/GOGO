using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGenkiDama : MonoBehaviour
{
    [SerializeField] Rigidbody _rbGenkiDama;
    [SerializeField] GameObject _lookAtCarTarget;
    [SerializeField] float _speedLaunch;
    public void GenkiDama ()
    {
        transform.LookAt (_lookAtCarTarget.transform);
        _rbGenkiDama.AddForce (Vector3.forward * _speedLaunch * Time.deltaTime, ForceMode.Impulse);
        //transform.Translate ((transform.position - _lookAtCarTarget.transform.position) * _speedLaunch);
    }
}
