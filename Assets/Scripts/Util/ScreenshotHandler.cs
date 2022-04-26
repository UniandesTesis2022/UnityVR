using System;
using System.IO;
using System.Collections;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour {

    private static ScreenshotHandler instance;

    [SerializeField] GameObject uiPlayer;

    //Save path
    public static string savePath = "Photos";

    private void Awake() {
        instance = this;
    }

    public static Texture2D TakePhoto(Camera camera, string folder, string name)
    {
        return instance.CaptureSavePhoto(camera, folder, name);
    }

    public static void DeletePhotos()
    {
        FileManager.DeleteFilesInFolder(savePath);
    }

    public Texture2D CaptureSavePhoto(Camera camera, string folder, string name)
    {
        Texture2D photo = capture(camera);
        FileManager.WriteToFile(Path.Combine(savePath, folder), name.Replace(" ", ""), photo);
        //StartCoroutine(Screenshot(camera, folder, name, cameraUI, pAnimal));
        return photo;
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

    public static Texture2D capture(Camera camera, int width, int height)
    {
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


    IEnumerator Screenshot(Camera camera, string folder, string name, CameraUI cameraUI, Animal pAnimal)
    {
        yield return new WaitForEndOfFrame();
        RenderTexture renderTexture = camera.targetTexture;

        Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        Rect rect = new Rect(0,0, renderTexture.width, renderTexture.height);
        renderResult.ReadPixels(rect, 0, 0);

        // Do whatever with screenshot
        FileManager.WriteToFile(Path.Combine(savePath, folder), name.Replace(" ", ""), renderResult);
        cameraUI.ShowPhoto(renderResult, pAnimal.image);
    }

    public static bool PhotoExists(string folder, string name)
    {
        return FileManager.FileExists(Path.Combine(savePath, folder), name.Replace(" ",""));
    }
}