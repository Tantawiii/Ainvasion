using UnityEngine;

public class canvasH : MonoBehaviour
{
    [SerializeField] private Camera cam; 

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main; 
        }

        
    }

    void Update()
    {
        if (cam != null)
        {
            transform.LookAt(cam.transform.position); 
            transform.Rotate(0, 180, 0); 
        }
    }
}
