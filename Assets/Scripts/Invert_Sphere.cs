using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Invert_Sphere : MonoBehaviour
{
    public static string VideoName { get; set; }
    private void InvertSphere()
    {
        Vector3[] normals = GetComponent<MeshFilter>().mesh.normals;

        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = -normals[i]; // point the normal from outside to inside
        }

        GetComponent<MeshFilter>().sharedMesh.normals = normals;

        int[] triangles = GetComponent<MeshFilter>().sharedMesh.triangles;

        for (int i = 0; i < triangles.Length; i += 3)
        {
            int t = triangles[i];
            triangles[i] = triangles[i + 2];
            triangles[i + 2] = t;
        }
        GetComponent<MeshFilter>().sharedMesh.triangles = triangles;


    }
    
    public void setVideo()
    {
        // Will attach a VideoPlayer to the main camera.
        GameObject camera = GameObject.Find("Sphere");
        var videoPlayer = camera.GetComponent<VideoPlayer>();
        videoPlayer.url = "Assets/Materials/Maori_Sing.mp4";
        //videoPlayer.url = new SceneTravel().VideoName;
        videoPlayer.url = VideoName;
        videoPlayer.Play();

    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvertSphere();
        setVideo();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Test.VideoName);
    }
}
