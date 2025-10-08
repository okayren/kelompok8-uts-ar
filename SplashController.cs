using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashController : MonoBehaviour
{
    // Durasi animasi loading (sekitar 2 detik)
    public float loadDuration = 2.0f; 
    
    // Nama scene halaman utama
    public string nextSceneName = "MainScene"; 

    void Start()
    {
        // Memulai coroutine untuk delay dan pindah scene
        StartCoroutine(LoadNextSceneAfterDelay(loadDuration));
    }

    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        // Tunggu selama 'delay' detik
        yield return new WaitForSeconds(delay); 

        // Pindah ke halaman utama
        SceneManager.LoadScene(nextSceneName); 
    }
}
