using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionCar : MonoBehaviour
{
    [SerializeField] Rigidbody _rbGenkiDama;
    //[SerializeField] float _lauchedDistance; //distance de lancement de la GenkiDama.
    [SerializeField] float _speedLaunch;
    [SerializeField] Animator _animationCharacter;
    [SerializeField] Animator _animationGenkiDama;

    bool _isCharging;
    bool _isActivate;
    bool _isLaunched;

    private void OnTriggerEnter (Collider other)
    {
        StartCoroutine (Shoot (other));
    }

    private void OnTriggerStay (Collider other)
    {
        StartCoroutine(Shoot (other));
    }

    IEnumerator Shoot (Collider other)
    {
        var car = other.GetComponentInParent<TruckTag> ();
        //float distance = Vector3.Distance (transform.parent.position, car.transform.position);
        //Debug.Log ($"la voiture est à {distance} mètres");
        if (car != null)
        {
            transform.parent.LookAt (car.transform);//regarde la voiture
            _isCharging = true;
            _isActivate = true;
            if (_isCharging && _isActivate)
            {
                _animationCharacter.SetBool ("IsCharging", _isCharging);//il lève les bras pour charger le GenkiDama.
                yield return new WaitForSeconds (2f);
                _animationGenkiDama.SetBool ("IsActivate", _isActivate);//il lance l'animation de chargement du genkidama.
            }
            _isLaunched = true;
            if (_isLaunched)
            {
                yield return new WaitForSeconds (1f);
                _animationCharacter.SetBool ("IsLaunched", _isLaunched);//il lance le genkidama.
                //_rbGenkiDama.AddForce ((car.transform.position - transform.parent.position) * _speedLaunch);
                _rbGenkiDama.AddForce (Vector3.up * _speedLaunch);
            }

            #region voir plus tard
            //if (distance < _lauchedDistance)
            //{
            //    _isLaunched = true;
            //    if (_isLaunched)
            //    {
            //        _animationCharacter.SetBool ("IsLaunched", _isLaunched);//il lance le genkidama.
            //        _rbGenkiDama.AddForce (car.transform.position,ForceMode.Force);
            //    }
            //}
            #endregion

        }
        _isCharging = false;
        _isLaunched = false;
    }
}
