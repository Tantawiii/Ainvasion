using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LoadScene : MonoBehaviour
{
 

    void Start()
    {
        
        StartCoroutine(LoadSceneAfterDelay(15f));
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        
        
        SceneManager.LoadScene("Level1");
    }
}
