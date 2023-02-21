
using UnityEditor.UI;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;

    [SerializeField] float bigRange = 15;
    [SerializeField] float smallRange = 10;
    private void Update()
    {
        Vector3 selfPosition= transform.position;
        Vector3 targetPosition= target.position;

        float distance = Vector3.Distance(selfPosition,targetPosition);
        
        if (distance <= bigRange)
        {
            float t = Mathf.InverseLerp(bigRange, smallRange, distance);
            float actualSpeed = Mathf.Lerp(0, speed, t); 

            transform.position = Vector3.MoveTowards(selfPosition, targetPosition, actualSpeed * Time.deltaTime);
        }


        //Vector3 direction = targetPosition - selfPosition;
        /*
        
        direction.Normalize();

        Vector3 velocity = direction * speed; 

        transform.position =  transform.position + velocity * Time.deltaTime;*/

        //transform.position= Vector3.MoveTowards(selfPosition, targetPosition, speed * Time.deltaTime);
        /*if (direction != Vector3.zero)
        transform.rotation = Quaternion.LookRotation(direction);*/
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, smallRange);
        Gizmos.DrawWireSphere(transform.position, bigRange);
    }

}



