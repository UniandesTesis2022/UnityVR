using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class IngameMenuUI : MonoBehaviour
{
    [SerializeField] Transform speciesPanel;

    [SerializeField] GameObject speciePrefab;

    [SerializeField] Transform photoPanel;

    [SerializeField] GameObject photoPrefab;

    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        RenderSpecies();
        RenderPhotos(Animal.Order.Araneae);
    }
    
    private void OnEnable() {
        RenderPhotos(Animal.Order.Araneae);
        scoreText.text = GameplayManager.instance.pictures + "/" + GameplayManager.instance.total;
    }

    private void RenderSpecies(){
        SpeciesBtn btnScript;
        GameObject newObject;

        foreach (Animal.Order specie in 
            new Animal.Order[]{Animal.Order.Araneae, Animal.Order.Coleoptera})
        {
            newObject = Instantiate(speciePrefab, speciesPanel.position, Quaternion.identity, speciesPanel);
            btnScript = newObject.GetComponent<SpeciesBtn>();
            btnScript.SetUp(this, specie);
        }
        newObject = Instantiate(speciePrefab, speciesPanel.position, Quaternion.identity, speciesPanel);
        btnScript = newObject.GetComponent<SpeciesBtn>();
        btnScript.SetUp(this, Animal.Order.Others);
    }

    public void RenderPhotos(Animal.Order name){
        EmptyPanel();

        List<Animal> animals = GameplayManager.GetAnimalsBySpecie(name);
        string imagePath;
        foreach (Animal animal in animals)
        {
            GameObject newObject = Instantiate(photoPrefab, photoPanel.position, Quaternion.identity, photoPanel);
            
            imagePath = Path.Combine(Application.persistentDataPath, "Photos", animal.animalOrder.ToString(), animal.cientificName.Replace(" ", "") + ".jpg");

            PhotoBtn btnScript = newObject.GetComponent<PhotoBtn>();
            if(File.Exists(imagePath)){
                
                Sprite actualPhoto = LoadNewSprite(imagePath);
                btnScript.SetUp(actualPhoto, animal.cientificName);
            }else{
                btnScript.SetUp(animal.image, animal.cientificName);
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
    public void Finish(int pPictures, int pTotal)
    {
        scoreText.text = pPictures + "/" + pTotal;
        resultText.text = pPictures >= pTotal ? "Ganaste!" : "Perdiste :(";
    }

}
