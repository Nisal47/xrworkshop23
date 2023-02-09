using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TakeMe : MonoBehaviour
{
     public void GrabCopyofObject(GameObject prefabSelected)
    {
        GameObject iniatedobj = Instantiate(prefabSelected, prefabSelected.transform.position, prefabSelected.transform.rotation);
        iniatedobj.AddComponent<XRGrabInteractable>();
    }
}
