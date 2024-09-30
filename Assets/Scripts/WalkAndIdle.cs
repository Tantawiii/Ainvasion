using UnityEngine;

public class WalkAndIdle : MonoBehaviour
{
    private Animator animator;
    public AudioSource WalkSound;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Determine speed
      
        if (move.magnitude > 0){
        
         animator.SetBool("Run", true);
         animator.SetBool("idle",false);
         WalkSound.Play();
         Debug.Log("WalkSound");
    }
        else{
            animator.SetBool("idle",true);
            animator.SetBool("Run", false);
            WalkSound.Stop();
        }
    }
}
