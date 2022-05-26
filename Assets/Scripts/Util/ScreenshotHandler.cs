using System;
using System.IO;
using System.Collections;
using UnityEngine;

public class ScreenshotHandler {

    //Save path
    public static string savePath = "Photos";

    public static Texture2D TakePhoto(Camera camera, string folder, string name)
    {
        Texture2D photo = capture(camera);
        FileManager.WriteToFile(Path.Combine(savePath, folder), name.Replace(" ", ""), photo);
        //StartCoroutine(Screenshot(camera, folder, name, cameraUI, pAnimal));
        return photo;
    }

    public static void DeletePhotos()
    {
        FileManager.DeleteFilesInFolder(savePath);
    }

    public static Texture2D capture(Camera camera) {
        Camera original = Camera.main;

        camera.RenderDontRestore();

        RenderTexture.active = camera.targetTexture;
        Texture2D image = new Texture2D(camera.targetTexture.width, camera.targetTexture.height, TextureFormat.ARGB32, false, true);
        Rect rect = new Rect(0, 0, camera.targetTexture.width, camera.targetTexture.height);
        image.ReadPixels(rect, 0, 0);
        image.filterMode = FilterMode.Point;
        image.Apply();

        RenderTexture.active = original.targetTexture;
        return image;
    }

    public static bool PhotoExists(string folder, string name)
    {
        return FileManager.FileExists(Path.Combine(savePath, folder), name.Replace(" ",""));
    }
}