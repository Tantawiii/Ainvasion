using System.Collections;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    
   [SerializeField] public AudioSource audioSource;

 
    public float delay = 3f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySoundAfterDelay(delay));
    }
  
    private IEnumerator PlaySoundAfterDelay(float delay)
    {
        
        yield return new WaitForSeconds(delay);

        
        audioSource.Play();
    }
}
