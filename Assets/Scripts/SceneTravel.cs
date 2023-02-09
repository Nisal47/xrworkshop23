using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneTravel : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    public string VideoName;
    public void LoadScene()
    {
        Invert_Sphere.VideoName = VideoName;
        SceneManager.LoadScene(1);
    }
    public void OnClick(BaseEventData data)
    {
        Debug.Log("On click triggered");
        SceneManager.LoadScene(2);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("On click triggered");
    }
    
}
