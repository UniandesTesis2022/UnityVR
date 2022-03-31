using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] Camera photoCamera;
    [SerializeField] Text fieldOfViewText;

    [SerializeField] Transform corners;

    public float minFOV;
    public float maxFOV;

    private float distFOV;

    public float minCornerX;
    public float maxCornerX;

    public float minCornerY;
    //public float maxCornerY;

    private float distCorner;

    // Start is called before the first frame update
    void Start()
    {
        fieldOfViewText.text = photoCamera.fieldOfView.ToString();

        distFOV = maxFOV - minFOV;
        distCorner = maxCornerX - minCornerX;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModifyFieldOfView( float pChange )
    {
        if( (pChange > 0 && photoCamera.fieldOfView < maxFOV)
         || (pChange < 0 && photoCamera.fieldOfView > minFOV) )
        {
            photoCamera.fieldOfView += pChange;
            if(photoCamera.fieldOfView < minFOV)
            {
                photoCamera.fieldOfView = minFOV;
            }
            if (photoCamera.fieldOfView > maxFOV)
            {
                photoCamera.fieldOfView = maxFOV;
            }

            float distanceX = ((photoCamera.fieldOfView - minFOV) / distFOV) * distCorner + minCornerX;
            float distanceY = ((photoCamera.fieldOfView - minFOV) / distFOV) * distCorner + minCornerY;

            Vector3 actualPosition;
            foreach (Transform item in corners)
            {
                actualPosition = item.localPosition;
                actualPosition.x = actualPosition.x > 0 ? distanceX : -distanceX;
                actualPosition.y = actualPosition.y > 0 ? distanceY : -distanceY;
                item.localPosition = actualPosition;
            }

            fieldOfViewText.text = photoCamera.fieldOfView.ToString();
        }
    } 
}
