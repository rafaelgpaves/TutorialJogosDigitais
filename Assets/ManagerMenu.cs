using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMenu : MonoBehaviour
{
    public void GoToMenu() {
        SceneManager.LoadSceneAsync(0);
    }
    public void PlayGame() {
        SceneManager.LoadSceneAsync(1);
    }

    void Update()
    {
        if (Input.GetAxisRaw("Fire1") > 0) {
            SceneManager.LoadSceneAsync(1);
        }

        if (Input.GetAxisRaw("Fire2") > 0) {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
