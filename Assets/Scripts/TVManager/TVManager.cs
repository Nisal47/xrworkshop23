using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TVManager : MonoBehaviour
{
    public bool _debugmode = false;
    private bool _playmode = false;
    public int currentPos = 0;

    [SerializeField] List<Material> matList;
    [SerializeField] GameObject tv_screen;

   public void NextPhoto()
   {
        if(currentPos == matList.Count - 1){
            currentPos = 0;
        }else{
            currentPos++;
        }
        
        if(_debugmode)
            Debug.Log("Next Click");

        LoadImage(currentPos);
   }

   public void PlayPhotoV()
   {
        
        if(_debugmode)
            Debug.Log("Play Click");

        _playmode = true;
        StartCoroutine(Waiter());
   }

   public void PausePhotoV()
   {
        
        if(_debugmode)
            Debug.Log("Pause Click");

        _playmode = false;
   }

   public void PrevPhoto()
   {
        if(currentPos == 0){
            currentPos = matList.Count-1;
        }else{
            currentPos--;
        }

        if(_debugmode)
            Debug.Log("Prev Click");

        LoadImage(currentPos);
   }

   void LoadImage(int imgPos)
   {
        MeshRenderer meshRenderer;
        if(tv_screen != null){
            meshRenderer = tv_screen.GetComponent<MeshRenderer>();
            meshRenderer.material = matList[imgPos];
        }
   }

void Start()
{    
    LoadImage(0);    
}


IEnumerator Waiter()
{
    while (_playmode)
    {
        NextPhoto();
        yield return new WaitForSeconds(3);
    }
    

    
}

public List<Texture2D> LoadImageAsTexture() {

    List<Texture2D> listTex2d = new List<Texture2D>();
    listTex2d.Clear();

    //Get image files info
    foreach(FileInfo imgfile in GetImagesFileInfo())
    {
        string imgfilePath = imgfile.ToString();

        Texture2D tex2dimg = null;
        byte[] fileData;

        if (File.Exists(imgfilePath))     
        {
            fileData = File.ReadAllBytes(imgfilePath);
            tex2dimg = new Texture2D(2, 2);
            tex2dimg.LoadImage(fileData);

            listTex2d.Add(tex2dimg);

        }else
        {
            Debug.Log("No File found at " +  imgfilePath);
        }
    }

     return listTex2d;
 }

 List<FileInfo> GetImagesFileInfo()
 {
    List<FileInfo> fileInfoList;

     //Setup the photo library folder. Photos folder was created to save images
     //FUTURE: Dowload function to save images in the resource folder and load it.
    string m_Path = Application.dataPath;
    DirectoryInfo dir = new DirectoryInfo(m_Path+"/Photos");

     //Read all the files except meta files in the photo folder
    fileInfoList = dir.GetFiles("*.*").Where(x => !x.Name.EndsWith(".meta")).ToList<FileInfo>();
    
    if(_debugmode)
    {
        foreach (FileInfo f in fileInfoList)
        Debug.Log(f.ToString());
    }
    
    return fileInfoList;
 }

}
