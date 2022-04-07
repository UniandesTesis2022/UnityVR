using System;
using System.IO;
using System.Collections;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour {

    private static ScreenshotHandler instance;

    [SerializeField] GameObject uiPlayer;

    //Save path
    public string savePath = "Photos/";

    private void Awake() {
        instance = this;
    }

    public static void TakePhoto(Camera camera, string folder, string name){
        instance.CaptureSavePhoto(camera, folder, name);
    }

    public static void DeletePhotos()
    {
        FileManager.DeleteFilesInFolder(instance.savePath);
    }

    public void CaptureSavePhoto(Camera camera, string folder, string name){

        Vector2 size = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        FileManager.WriteToFile(savePath + folder, name, capture(camera, (int)size.x, (int)size.y));
    }

    public static Texture2D capture(Camera camera, int width, int height) {
        RenderTexture rt = new RenderTexture(width, height, 0);

        rt.depth = 24;
        rt.antiAliasing = 8;

        camera.targetTexture = rt;
        camera.RenderDontRestore();

        RenderTexture.active = rt;
        Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false, true);
        Rect rect = new Rect(0, 0, width, height);
        texture.ReadPixels(rect, 0, 0);
        texture.filterMode = FilterMode.Point;
        texture.Apply();
        camera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);

        return texture;
    }

    public static bool PhotoExists(string folder, string name)
    {
        return FileManager.FileExists(instance.savePath + folder, name);
    }
}