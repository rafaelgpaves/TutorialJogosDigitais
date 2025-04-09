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
}
