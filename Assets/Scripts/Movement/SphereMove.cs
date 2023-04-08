using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMove : MonoBehaviour
{
    [SerializeField] float _sphereRotation;
    [SerializeField] float _sphereX;
    [SerializeField] float _sphereY;
    [SerializeField] float _sphereZ;

    private void Update ()
    {
        transform.rotation = Quaternion.Euler (_sphereRotation * Time.smoothDeltaTime, 0,0);
        transform.Translate (_sphereX * Time.smoothDeltaTime, _sphereY * Time.smoothDeltaTime, _sphereZ * Time.smoothDeltaTime);
    }
}
