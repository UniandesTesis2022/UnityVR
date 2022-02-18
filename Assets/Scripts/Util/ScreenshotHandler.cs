using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotHandler : MonoBehaviour {

    [SerializeField] GameObject uiPlayer;

    private static ScreenshotHandler instance;

    private void Awake() {
        instance = this;
    }

    public static void TakeScreenshot(string path, string name){
        instance.TakeScreenshotInNextFrame(path, name);
    }

    private void TakeScreenshotInNextFrame(string path, string name){
        StartCoroutine(CaptureScreen(path, name));
    }

    public IEnumerator CaptureScreen(string path, string name)
    {
        Debug.Log("Pic " + path);
        // Wait till the last possible moment before screen rendering to hide the UI
        yield return null;
        uiPlayer.SetActive(false);
    
        // Wait for screen rendering to complete
        yield return new WaitForEndOfFrame();
    
        // Take screenshot
        Texture2D texture = ResampleAndCrop(ScreenCapture.CaptureScreenshotAsTexture(6));

        byte[] bytes = texture.EncodeToJPG();
        var dirPath = Application.dataPath + "/" + path;
        if(!Directory.Exists(dirPath)) {
            Directory.CreateDirectory(dirPath);
        }
        File.WriteAllBytes(dirPath + "/" + name + ".jpg", bytes);

        // Show UI after we're done
        uiPlayer.SetActive(true);
    }


     public static Texture2D ResampleAndCrop(Texture2D sourceTexture)
     {
        int width = sourceTexture.width / 3;
        int height = sourceTexture.height / 3;

        Color[] c = ((Texture2D) sourceTexture).GetPixels(width, height, width, height);
        Texture2D croppedTexture = new Texture2D(width, height);
        croppedTexture.SetPixels(c);
        croppedTexture.Apply();
        return croppedTexture;
     }
}