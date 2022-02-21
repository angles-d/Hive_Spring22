using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TrackingQualityEnforcer : MonoBehaviour
{
    public ARSession Ars;
    public Canvas Notifier;
    public Text Msg;

    // Update is called once per frame
    void Update()
    {
        switch(ARSession.notTrackingReason)
        {
            case NotTrackingReason.None:
                DisableNotifier();
                SetText("You shouldn't be able to see this");
                break;
            case NotTrackingReason.Initializing:
                EnableNotifier();
                SetText("Initializing Tracker");
                break;
            case NotTrackingReason.Relocalizing:
                EnableNotifier();
                SetText("I'm trying to find where I am...");
                break;
            case NotTrackingReason.InsufficientLight:
                EnableNotifier();
                SetText("It's too dark!");
                break;
            case NotTrackingReason.InsufficientFeatures:
                EnableNotifier();
                SetText("I don't know what I'm seeing!");
                break;
            case NotTrackingReason.ExcessiveMotion:
                EnableNotifier();
                SetText("TOO FAST DLFKJGLDFKJG");
                break;
            case NotTrackingReason.Unsupported:
                EnableNotifier();
                SetText("I don't know what broke!");
                break;
            default:
                EnableNotifier();
                SetText("I literally do not know");
                break;
        }
    }

    private void DisableNotifier()
    {
        if (Notifier.enabled) Notifier.enabled = false;
    }

    private void EnableNotifier()
    {
        if (!Notifier.enabled) Notifier.enabled = true;
    }

    private void SetText(string t)
    {
        Msg.text = t;
    }
}
