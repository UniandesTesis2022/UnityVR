using System;
using System.IO;
using System.Collections;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour {

    private static ScreenshotHandler instance;

    [SerializeField] GameObject uiPlayer;

    //Save path
    public static string savePath = "Photos/";

    private void Awake() {
        instance = this;
    }

    public static void TakePhoto(Camera camera, string folder, string name){
        instance.CaptureSavePhoto(camera, folder, name);
    }

    public static void DeletePhotos()
    {
        FileManager.DeleteFilesInFolder(savePath);
    }

    public void CaptureSavePhoto(Camera camera, string folder, string name){
        FileManager.WriteToFile(savePath + folder, name, capture(camera));
    }

    public static Texture2D capture(Camera camera) {
        Camera original = Camera.main;

        RenderTexture.active = camera.targetTexture;
        camera.RenderDontRestore();

        Texture2D tex = new Texture2D(camera.targetTexture.width, camera.targetTexture.height, TextureFormat.RGB24, false);
        // ReadPixels looks at the active RenderTexture.
        tex.ReadPixels(new Rect(0, 0, camera.targetTexture.width, camera.targetTexture.height), 0, 0);
        tex.Apply();

        RenderTexture.active = original.targetTexture;

        return tex;
    }

    public static bool PhotoExists(string folder, string name)
    {
        return FileManager.FileExists(savePath + folder, name);
    }
}