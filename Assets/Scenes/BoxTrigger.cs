using Unity.VisualScripting;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    public GameObject Enemy;

    public GameObject Player;
    private Animator animatorE;
    bool isChasing;
    public float speed;

    public bool EenemyMoving = false;

    public float rotationSpeed = 5.0f;

    void Start()
    {
        animatorE = Enemy.GetComponent<Animator>();
    }



    void Update()
    {
        // In the Box script for the enemy chasing the player
        if (isChasing)
        {
            Vector3 direction = (Player.transform.position - Enemy.transform.position).normalized;
            direction.y = 0; // Ignore vertical movement
            Enemy.transform.position += direction * speed * Time.deltaTime;

            // Rotate the enemy to face the player
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animatorE.SetBool("Run", true);
            isChasing = true;
            EenemyMoving = true;
        }
    }
}
