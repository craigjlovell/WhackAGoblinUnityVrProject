using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrab : XRGrabInteractable
{

    private Vector3 initialAttLocolPos;
    private Quaternion initialAttLocolRot;

    // Start is called before the first frame update
    void Start()
    {
        if(!attachTransform)
        {
            GameObject grab = new GameObject("Grab Pivot");
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;
        }
        initialAttLocolPos = attachTransform.localPosition;
        initialAttLocolRot = attachTransform.localRotation;
    }

    // Update is called once per frame
    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        if (interactor is XRDirectInteractor)
        {
            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;
        }
        else
        {
            attachTransform.localPosition = initialAttLocolPos;
            attachTransform.localRotation = initialAttLocolRot;
        }

        base.OnSelectEntering(interactor);
    }
}
