using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class BeginProgram : MonoBehaviour
{

    public Canvas Ui;
    public GameObject GObject;
    public Camera ARCam;
    public Material CustomMaterial;
    public ARSessionOrigin ARSOrigin;
    public GameObject TrackingPointPrefab;


    // Start is called before the first frame update
    public void Run()
    {
        RemoveUI();
        EnableGObject();
        DisablePassthrough();
        DisableTrackingPoints();
    }

    public void RemoveUI()
    {
        GameObject.Destroy(Ui);
    }

    public void EnableGObject()
    {
        GObject.SetActive(true);
        Vector3 CameraPos = ARCam.transform.position;
        CameraPos.y -= 1.8f;
        GObject.transform.position = CameraPos;
    }

    public void DisablePassthrough()
    {
        ARCameraBackground arcbg = ARCam.GetComponent<ARCameraBackground>();
        if (arcbg == null) return;
        arcbg.useCustomMaterial = true;
        arcbg.customMaterial = CustomMaterial;
    }

    public void DisableTrackingPoints()
    {
        GameObject.Destroy(TrackingPointPrefab);
        var pcm = ARSOrigin.GetComponent<ARPointCloudManager>();
        if (pcm == null) return;
        pcm.enabled = false;
        foreach (var point in pcm.trackables)
        {
            point.gameObject.SetActive(false);
        }
        //GameObject.Destroy(pcm);
    }
}
