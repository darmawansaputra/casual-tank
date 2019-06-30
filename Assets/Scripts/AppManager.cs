using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    public static AppManager instance;
    AudioSource audioSource;


    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this);

            audioSource = GetComponent<AudioSource>();

            return;
        }

        Destroy(this.gameObject);
    }

    public void ToggleBackground() {
        audioSource.mute = !audioSource.mute;
    }
}
