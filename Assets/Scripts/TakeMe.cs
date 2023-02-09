using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TakeMe : MonoBehaviour
{

    public void GrabCopyofObject(GameObject prefabSelected)
    {
        GameObject iniatedobj = Instantiate(prefabSelected, new Vector3(0, 0, 0), Quaternion.identity);
        iniatedobj.AddComponent<XRGrabInteractable>();
        
    }
}
