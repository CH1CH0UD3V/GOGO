using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToTheFuture : MonoBehaviour
{
    #region Champs
    [SerializeField] GameObject _render;
    [SerializeField] ParticleSystem _firstLine;
    [SerializeField] ParticleSystem _secondLine;
    [SerializeField] GameObject _lightning;
    [SerializeField] GameObject _flashingLight;
    [SerializeField] GameObject _carLight;
    [SerializeField] TruckMovement _disableMap;
    //[SerializeField] float _timeBeforeDisable;
    //[SerializeField] GameObject _blackScreen;
    //[SerializeField] AudioSource _boomSound;
    //[SerializeField] GameObject _buttonNext;
    //[SerializeField] GameObject _buttonRetry;
    //[SerializeField] GameObject _buttonExit;

    #endregion

    #region OnTriggerEnter
    private void OnTriggerEnter (Collider other)
    {
        TruckTag car = other.GetComponentInParent<TruckTag> ();
        if (car != null)
        {
            _carLight.SetActive(false);
            StartCoroutine (WaitAndDisable ());
        }
    }
    #endregion


    #region Coroutine WaitAndDisable
    IEnumerator WaitAndDisable ()
    {
        _flashingLight.SetActive (true);
        yield return new WaitForSeconds(0.4f);
        _flashingLight.SetActive (false);
        //yield return new WaitForSeconds(_timeBeforeDisable);
        _render.SetActive (false);
        _firstLine.Play();
        _secondLine.Play();
        yield return new WaitForSeconds(1.25f);
        _disableMap.Disactivate ();
        _lightning.SetActive (false);
        //yield return new WaitForSeconds(4f);
        //_blackScreen.SetActive(true);
        //_boomSound.Play();
        //yield return new WaitForSeconds(1f);
        //_buttonNext.SetActive(true);
        //_boomSound.Play();
        //yield return new WaitForSeconds(1f);
        //_buttonRetry.SetActive(true);
        //_boomSound.Play();
        //yield return new WaitForSeconds(1f);
        //_buttonExit.SetActive(true);
        //_boomSound.Play();

    }
    #endregion
}
