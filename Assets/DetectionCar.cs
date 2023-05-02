//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class DetectionCar : MonoBehaviour
//{
//    [SerializeField] Rigidbody _rbGenkiDama;
//    //[SerializeField] float _lauchedDistance; //distance de lancement de la GenkiDama.
//    [SerializeField] float _speedLaunch;
//    [SerializeField] Animator _animationCharacter;
//    [SerializeField] Animator _animationGenkiDama;
//
//    bool _isCharging;
//    bool _isActivate;
//    bool _isLaunched;
//
//    //private void OnTriggerEnter (Collider other)
//    //{
//    //    Shoot ();
//    //}
//    //
//    private void OnTriggerStay (Collider other)
//    {
//        Shoot (other);
//    }
//
//    private void Shoot (Collider other)
//    {
//        var car = other.GetComponentInParent<TruckTag> ();
//        //float distance = Vector3.Distance (transform.parent.position, car.transform.position);
//        //Debug.Log ($"la voiture est à {distance} mètres");
//        if (car != null)
//        {
//            transform.parent.LookAt (car.transform);//regarde la voiture
//            _isCharging = true;
//            _isActivate = true;
//            if (_isCharging && _isActivate)
//            {
//                _animationCharacter.SetBool ("IsCharging", _isCharging);//il lève les bras pour charger le GenkiDama.
//                _animationGenkiDama.SetBool ("IsActivate", _isActivate);//il lance l'animation de chargement du genkidama.
//            }
//            _isLaunched = true;
//            if (_isLaunched)
//            {
//                _animationCharacter.SetBool ("IsLaunched", _isLaunched);//il lance le genkidama.
//                //_rbGenkiDama.AddForce ((car.transform.position - transform.parent.position) * _speedLaunch);
//                _rbGenkiDama.AddForce (Vector3.up * _speedLaunch);
//            }
//
//            #region voir plus tard
//if (distance < _lauchedDistance)
//{
//    _isLaunched = true;
//    if (_isLaunched)
//    {
//        _animationCharacter.SetBool ("IsLaunched", _isLaunched);//il lance le genkidama.
//        _rbGenkiDama.AddForce (car.transform.position,ForceMode.Force);
//    }
//}
              //#endregion
//
//        }
//        _isCharging = false;
//        _isLaunched = false;
//    }
//}






using UnityEngine;

public class DetectionCar : MonoBehaviour
{
    //[SerializeField] Rigidbody _rbGenkiDama;
    //[SerializeField] GameObject _targetCar;
    //[SerializeField] float _speedLaunch;
    [SerializeField] Animator _animationCharacter;
    [SerializeField] Animator _animationGenkiDama;
    [SerializeField] LaunchGenkiDama _lGen;

    bool _isCharging;
    bool _isActivate;
    bool _isLaunched;

    private void OnTriggerEnter (Collider other)
    {
        var car = other.GetComponentInParent<TruckTag> ();
        if (car != null)
        {
            transform.parent.LookAt (car.transform);
            _isCharging = true;
            _isActivate = true;

            if (_isCharging && _isActivate)
            {
                _animationCharacter.SetBool ("IsCharging", _isCharging);
                _animationGenkiDama.SetBool ("IsActivate", _isActivate);
            }

            _isLaunched = true;
        }
    }

    private void Update ()
    {
        if (_isLaunched)
        {            
           _animationCharacter.SetBool ("IsLaunched", _isLaunched);
            _lGen.GenkiDama ();
            //_rbGenkiDama.AddForce (_targetCar.transform.position * _speedLaunch * Time.deltaTime, ForceMode.Acceleration);
           _isCharging = false;
           _isActivate = false;
           _isLaunched = false;            
        }
    }
}
