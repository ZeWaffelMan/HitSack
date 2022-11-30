using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioManager _audioManager;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = _audioManager.GetComponent<AudioManager>();
    }

    public void Play()
    {
        audioManager.Play("Tap");
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        audioManager.Play("Tap");
        Application.Quit();
    }

    public void Menu()
    {
        audioManager.Play("Tap");
        SceneManager.LoadScene(0);
    }
}
