using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocCatapult : MonoBehaviour
{
    [SerializeField] GameObject _blueBuilding;
    [SerializeField] ParticleSystem _deepImpact;
    [SerializeField] float _speedRoc;

    void Update()
    {
        transform.LookAt(_blueBuilding.transform);
        transform.Translate ((transform.position + _blueBuilding.transform.position) * _speedRoc * Time.smoothDeltaTime);
        _deepImpact.Play();
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.name == "blue building")
        {
            GameObject blueB = collision.gameObject;
            if (blueB != null)
            {
                _deepImpact.Stop ();
            }
        }

    }
}
