using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SceneManager : MonoBehaviour
{
    public void MainMenuLoad()
    {
        SoundManager.instance.PlaySound(Sounds.buttonClick);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
    }

    public void IngameLoad()
    {
        SoundManager.instance.PlaySound(Sounds.buttonClick);
        UnityEngine.SceneManagement.SceneManager.LoadScene("InGameScene");
    }
}
