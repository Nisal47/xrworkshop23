using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class InputReader : MonoBehaviour
{
    //Creating a List of Input Devices to store our Input Devices in
    List<InputDevice> inputDevices = new List<InputDevice>();
    // Start is called before the first frame update
    void Start()
    {
        //We will try to Initialize the InputReader here, but all components may not be loaded
        InitializeInputReader();
    }

    //This will try to initialize the InputReader by getting all the devices and printing them to the debugger.
    void InitializeInputReader()
    {

        //InputDevices.GetDevices(inputDevices);
       // InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller, inputDevices);
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller, inputDevices);

        foreach (var inputDevice in inputDevices)
        {
            inputDevice.TryGetFeatureValue(CommonUsages.menuButton, out bool triggerValue);
            Debug.Log(inputDevice.name + " " + triggerValue);
            if (triggerValue)
            {
                SceneManager.LoadScene(0);
            }
            
            //Debug.Log(inputDevice.name + " " + inputDevice.characteristics);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //We should have a total of 3 Input Devices. If it's less, then we try to initialize them again.
        if (inputDevices.Count < 2)
        {
            InitializeInputReader();
        }
    }
}