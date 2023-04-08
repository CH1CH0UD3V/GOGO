using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudmove : MonoBehaviour
{
    [SerializeField] float _speedCloud;
    [SerializeField] float _timeBeforeRemove;

    void Start()
    {
        StartCoroutine(MoveAndRemove ());
    }

    private void Update ()
    {
        _timeBeforeRemove -= 1 * Time.deltaTime;
        Debug.Log ($"Rotation dans {_timeBeforeRemove} Secondes mon COCO");
        transform.Translate(Vector3.forward * _speedCloud * Time.deltaTime,Space.Self);
    }

    IEnumerator MoveAndRemove ()
    {
        yield return new WaitForSeconds(_timeBeforeRemove);
        transform.rotation = Quaternion.Euler (0f, 90f, 0f);
        //transform.Translate(Vector3.forward * _speedCloud * Time.deltaTime,Space.Self);
        yield return new WaitForSeconds(_timeBeforeRemove);
        transform.rotation = Quaternion.Euler (0f, 180f, 0f);
        //transform.Translate (Vector3.forward * _speedCloud * Time.deltaTime, Space.Self);
        yield return new WaitForSeconds(_timeBeforeRemove);
        transform.rotation = Quaternion.Euler (0f, 270f, 0f);
        yield return new WaitForSeconds(_timeBeforeRemove);
        transform.rotation = Quaternion.Euler (0f, 360f, 0f);
        yield return new WaitForSeconds(_timeBeforeRemove);
    }
}
