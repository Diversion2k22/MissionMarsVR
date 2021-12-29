using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DoorControl : MonoBehaviour
{
    public enum DoorType
    {
        NORMAL,
        ELEVATOR
    }

    [SerializeField]
    DoorType Type = DoorType.NORMAL;

    [SerializeField]
    Transform t;
    
    [SerializeField]
    Vector3 RotationVector;
    bool status = false;

    public bool PermanentCloseStatus = false;

    [SerializeField]
    Vector3 ModifiedScale;
    Vector3 OriginalScale;

    public void PermanentClose()
    {
        PermanentCloseStatus = true;
        StartCoroutine(Close2());
        gameObject.tag = "NonInteractable";
    }
    private void Start()
    {
        if (t == null)
        {
            t = transform;
        }
        OriginalScale = t.localScale;
    }
    public void OpenDoor()
    {
        if (Type == DoorType.NORMAL && !status)
        {
            status = true;
            t.DOLocalRotate(RotationVector, 1.5f);
            StartCoroutine(Close());
        }
        else if (Type == DoorType.ELEVATOR && !status)
        {
            status = true;
            t.DOScale(ModifiedScale, 0.75f);
            StartCoroutine(Close2());
        }
    }

    IEnumerator Close()
    {
        yield return new WaitForSeconds(3f);
        t.DOLocalRotate(Vector3.zero, 1f);
        yield return new WaitForSeconds(2f);
        status = false;
    }

    IEnumerator Close2()
    {
        yield return new WaitForSeconds(3f);
        t.DOScale(OriginalScale, 0.75f);
        yield return new WaitForSeconds(2f);
        status = false;
    }
}
