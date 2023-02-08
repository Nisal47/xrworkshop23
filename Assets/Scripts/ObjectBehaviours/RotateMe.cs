using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script added to item/avatar displayer to rotate the avatar for intractive
public class RotateMe : MonoBehaviour
{
    public float RotationSpeed;
    void Update()
    {
        transform.Rotate(
            Vector3.up * RotationSpeed * Time.deltaTime,
            Space.Self);
    }
}
