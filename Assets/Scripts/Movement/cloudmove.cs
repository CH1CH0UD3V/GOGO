using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudmove : MonoBehaviour
{
    [SerializeField] float _speedCloud;
    
    private void Update ()
    {
        transform.Translate (Vector3.forward * _speedCloud * Time.smoothDeltaTime);
    }

}
