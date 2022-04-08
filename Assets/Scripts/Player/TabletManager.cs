using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletManager : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] Camera photoCamera;
    [SerializeField] Text fieldOfViewText;

    public float minFOV;
    public float maxFOV;

    private Transform mainCamera;

    private void Start()
    {
        mainCamera = Camera.main.transform;

        photoCamera.fieldOfView = maxFOV;
        fieldOfViewText.text = photoCamera.fieldOfView.ToString();
    }

    void LateUpdate()
    {
        Vector3 lookDirection = transform.position - mainCamera.position;
        lookDirection.Normalize();

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), movementSpeed * Time.deltaTime);
    }

    public bool ModifyFieldOfView(float pChange)
    {
        Debug.Log("Modify " + pChange);
        var changed = (pChange > 0 && photoCamera.fieldOfView < maxFOV)
         || (pChange < 0 && photoCamera.fieldOfView > minFOV);

        if (changed)
        {
            photoCamera.fieldOfView += pChange;

            if (photoCamera.fieldOfView < minFOV)
            {
                photoCamera.fieldOfView = minFOV;
            }
            if (photoCamera.fieldOfView > maxFOV)
            {
                photoCamera.fieldOfView = maxFOV;
            }

            fieldOfViewText.text = ((int)photoCamera.fieldOfView).ToString();
        }

        return changed;
    }
}
