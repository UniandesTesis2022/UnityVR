using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource shotAudio;
    [SerializeField] private AudioSource zoomAudio;
    [SerializeField] private AudioClip forwardSound;
    [SerializeField] private AudioClip rewindSound;

    public void Shoot(){
        shotAudio.Play();
    }

    public void ZoomIn(){
        if(!zoomAudio.isPlaying || zoomAudio.clip != forwardSound){
            zoomAudio.PlayOneShot(forwardSound);
        }
    }

    public void ZoomOut(){
        if(!zoomAudio.isPlaying || zoomAudio.clip != rewindSound){
            zoomAudio.PlayOneShot(rewindSound);
        }
    }

    public void StopZoom(){
        zoomAudio.Stop();
    }
}
