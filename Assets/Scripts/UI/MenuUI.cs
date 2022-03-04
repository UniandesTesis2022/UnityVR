using System.Collections;
using System.IO;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] Transform speciesPanel;

    [SerializeField] GameObject speciePrefab;

    [SerializeField] Transform photoPanel;

    [SerializeField] GameObject photoPrefab;

    [SerializeField] Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        RenderSpecies();
        RenderPhotos("SPHERE");
    }
    
    private void OnEnable() {
        transform.position = player.transform.position + offset;
    }

    private void RenderSpecies(){
        string[] temp = {"SPHERE", "SQUARE"};
        foreach (string name in temp)
        {
            GameObject newObject = Instantiate(speciePrefab, speciesPanel.position, Quaternion.identity, speciesPanel);
            SpeciesBtn btnScript = newObject.GetComponent<SpeciesBtn>();
            btnScript.SetUp(this, name);
        }
    }

    public void RenderPhotos(string name){
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath + "/Photos/" + name);
        FileInfo[] info = dir.GetFiles("*.*");
        foreach (FileInfo f in info) 
        {
            if(f.FullName.EndsWith(".jpg")){
                GameObject newObject = Instantiate(photoPrefab, photoPanel.position, Quaternion.identity, photoPanel);
                PhotoBtn btnScript = newObject.GetComponent<PhotoBtn>();
                
                Sprite actualPhoto = LoadNewSprite(f.FullName);
                btnScript.SetUp(actualPhoto);
            }
        }
    }

    public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f) {
   
     // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference
     
     Texture2D SpriteTexture = LoadTexture(FilePath);
     Sprite NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height),new Vector2(0,0), PixelsPerUnit);
 
     return NewSprite;
   }
 
   public Texture2D LoadTexture(string FilePath) {
 
     // Load a PNG or JPG file from disk to a Texture2D
     // Returns null if load fails
 
     Texture2D Tex2D;
     byte[] FileData;
 
     if (File.Exists(FilePath)){
       FileData = File.ReadAllBytes(FilePath);
       Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
       if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
         return Tex2D;                 // If data = readable -> return texture
     }  
     return null;                     // Return null if load failed
   }
}
