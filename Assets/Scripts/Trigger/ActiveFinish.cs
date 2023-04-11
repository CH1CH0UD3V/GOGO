using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFinish : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _camVir1;
    [SerializeField] CinemachineVirtualCamera _camVir2;
    [SerializeField] CinemachineVirtualCamera _camVir3;
    [SerializeField] GameObject _lightning;
    [SerializeField] GameObject _carLight;

    private void OnTriggerEnter (Collider other)
    {
      TruckTag Truck = other.GetComponentInParent<TruckTag> ();
        if ( Truck != null )
        {
            _camVir1.Priority = 10;
            _camVir2.Priority = 11;
            Debug.Log ("88 Miles à l'heeeeeuuuuurrree !!!!!!!");
            _lightning.SetActive (true);
            _carLight.SetActive (true);
        }
    }
}
