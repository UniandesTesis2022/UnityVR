using System;
using System.Collections;
using System.Collections.Generic;
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
        RenderPhotos(Animal.species.SPHERE);
    }
    
    private void OnEnable() {
        transform.position = player.transform.position + offset; 
        RenderPhotos(Animal.species.SPHERE);
    }

    private void RenderSpecies(){   
        foreach(Animal.species specie in Enum.GetValues(typeof(Animal.species)))
        {
            GameObject newObject = Instantiate(speciePrefab, speciesPanel.position, Quaternion.identity, speciesPanel);
            SpeciesBtn btnScript = newObject.GetComponent<SpeciesBtn>();
            btnScript.SetUp(this, specie);
        }
    }

    public void RenderPhotos(Animal.species name){
        EmptyPanel();

        List<Animal> animals = GameViewController.GetAnimalsBySpecie(name);
        string imagePath;
        foreach (Animal animal in animals)
        {
            GameObject newObject = Instantiate(photoPrefab, photoPanel.position, Quaternion.identity, photoPanel);
            
            imagePath = Path.Combine(Application.persistentDataPath, "Photos", animal.specie.ToString(), animal.name + ".jpg");

            PhotoBtn btnScript = newObject.GetComponent<PhotoBtn>();
            if(File.Exists(imagePath)){
                
                Sprite actualPhoto = LoadNewSprite(imagePath);
                btnScript.SetUp(actualPhoto, animal.name);
            }else{
                btnScript.SetUp(animal.name);
            }
        }
    }

    public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f) {
           
        FileManager.LoadFromFile(FilePath, out Texture2D SpriteTexture);
        Sprite NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height),new Vector2(0,0), PixelsPerUnit);

        return NewSprite;
   }

   public void EmptyPanel(){
        int children = photoPanel.childCount;
        for (int i = children - 1; i >= 0; i--){
            Destroy(photoPanel.GetChild(i).gameObject);
        }
   }
 
}
