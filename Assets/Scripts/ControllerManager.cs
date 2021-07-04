using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class ControllerManager : MonoBehaviour
{
    public GameObject canvas;
    public AudioSource voice;

    public Animator animator;

    public bool isFirstTime;
    public bool isPlaying;

    public void HandPause()
    {
        if (!isPlaying)
        {
            Debug.Log("Play");

            isPlaying = true;
            canvas.SetActive(false);

            if(!isFirstTime)
            {
                isFirstTime = true;
                voice.Play();
                animator.SetBool("Playing", true);
            }
            else
            {
                Time.timeScale = 1;
                voice.UnPause();
            }

        }
        else
        {
            Debug.Log("Pause");

            isPlaying = false;
            canvas.SetActive(true);

            Time.timeScale = 0;

            voice.Pause();
        }
    }

    public void PrimaryButton()
    {
        Scene activeScene;
        activeScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(activeScene.name);
    }
}
