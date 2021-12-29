using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;
public class VRGaze : MonoBehaviour
{
    [SerializeField]
    Image GazeIndicator;
    [SerializeField]
    float GazeTime = 2;

    bool gvrStatus;
    float gvrTimer;

    [SerializeField]
    float rayLength = 10f;
    GameObject prev;

    public UnityEvent gvrClick;
    [SerializeField]
    Transform canvasObject;
    [SerializeField]
    Camera mainCamera;
    float camAngle;

    private void Start()
    {
        if (DataScript.AUTO_NAV_STATUS)
        {   
            rayLength = 30f;
        }
        else
        {
            rayLength = 5f;
        }
    }
    private void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            GazeIndicator.fillAmount = gvrTimer / GazeTime;
        }
        if(gvrTimer>GazeTime)
        {
            gvrClick.Invoke();
        }
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            GameObject cur = hit.collider.gameObject;
            if (prev == cur)
            {
                if (GazeIndicator.fillAmount == 1f)
                {
                    if (cur.CompareTag("Interactable"))
                    {
                        cur.GetComponent<DoorControl>().OpenDoor();
                    }
                    else if (cur.CompareTag("teleport"))
                    {
                        cur.GetComponent<Teleport>().TeleportPlayer();
                    }
                    GVROff();
                    prev = null;
                }
                return;
            }
            if (cur.CompareTag("Interactable") )
            {
                prev = cur;
                GVROn();
            }
            else if (cur.CompareTag("teleport"))
            {
                prev = cur;
                GVROn();
            }
            else if(gvrStatus)
            {
                prev = null;
                GVROff();
            }
        }

        // camAngle = Vector3.Angle(canvasObject.position - mainCamera.gameObject.transform.position, mainCamera.gameObject.transform.forward);
        camAngle=canvasObject.rotation.y-mainCamera.gameObject.transform.rotation.y;

        
        if(Mathf.Abs(camAngle)>0.5)
        {    //canvasObject.Rotate(0, -camAngle*180, 0);
        //canvasObject.DORotate(new Vector3(0, camAngle*180, 0), 0.3f);
        canvasObject.rotation=Quaternion.Euler(canvasObject.rotation.x,mainCamera.gameObject.transform.rotation.y*180,canvasObject.rotation.z);
        }
            

        
    }

    public void GVROn()
    {
        gvrStatus = true;
        gvrTimer = 0f;
        GazeIndicator.fillAmount = 0;
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        GazeIndicator.fillAmount = 0;
    }
}
