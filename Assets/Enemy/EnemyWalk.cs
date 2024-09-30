using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2.0f;
    public float rotationSpeed = 5.0f; 
    private Vector3 target;

    private Animator animator;

    BoxTrigger box;

    private void Start()
    {
        target = pointA.position;
        animator = GetComponent<Animator>();
         box = FindObjectOfType<BoxTrigger>();
    }

    private void Update()
    {
        if(!box.EenemyMoving){
        
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

     
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
           
            target = target == pointA.position ? pointB.position : pointA.position;
        }
    }}

    /*  private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           animator.SetBool("Run", true);
        }
    } */
}
