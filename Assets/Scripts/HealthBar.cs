using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image BG;
    private CharacterController characterController;
    public float CurrentH;
    public GameObject hitParticleSystem;
  /*   public GameObject hitParticleSystem2;
    public GameObject hitParticleSystem3; */

    public GameObject white;
    Animator animator;
    Animator animatorW;

    /*     public Camera cam; */

    void Start()
    {
        hitParticleSystem.SetActive(false);
       /*  hitParticleSystem2.SetActive(false);
        hitParticleSystem3.SetActive(false); */
        animatorW = white.GetComponent<Animator>();
    }
    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        animator = GetComponent<Animator>();
        BG.fillAmount = currentHealth / maxHealth;
        characterController = GetComponent<CharacterController>();
    }


    /*  void Update()
     {

         BG.transform.LookAt(cam.transform.position);
         BG.transform.Rotate(0, 180, 0);
     }
  */

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            float damage = 50f;
            TakeDamage(damage);
            hitParticleSystem.SetActive(true);
        /*     hitParticleSystem2.SetActive(true);
            hitParticleSystem3.SetActive(true); */
            StartCoroutine(StopParticleSystemAfterDelay(2f));

        }

        if (other.CompareTag("Portal"))
        {
            animatorW.SetBool("White", true);
        }
    }

    public void TakeDamage(float damage)
    {
        CurrentH -= damage;
        Debug.Log(CurrentH);
        if (CurrentH <= 0)
        {
            CurrentH = 0;
            animator.SetTrigger("Dead");
            animator.SetBool("idle", false);
            animator.SetBool("Run", false);
        }

        UpdateHealthBar(100, CurrentH);
    }


    private IEnumerator StopParticleSystemAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        hitParticleSystem.SetActive(false);
     /*    hitParticleSystem2.SetActive(false);
        hitParticleSystem3.SetActive(false); */
    }
}
