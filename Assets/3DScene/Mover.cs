using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] Transform cameraTransform;
    [SerializeField] float angularVelocity = 20;

    [SerializeField] bool moveInCameraSpace;
    [SerializeField] HealthObject healthObject;
    /*void Start()
    {
        Vector2 v2a = new Vector2(1, 4);
        Vector3 v3a = new Vector3(4, 5, 7.545f);

        float f1 = v2a.x;
        float f2 = v3a.z;

        Transform t=transform;

        t.position= v3a;
    }
    */

     void OnValidate()
    {
        if(healthObject == null)
            healthObject = gameObject.GetComponent<HealthObject>();
    }
    void Update()
    {
   /* if (healthObject != null)
        {
            if (!healthObject.IsAlive()) return; //ez és a lenti ugyanaz
        }*/

        if(healthObject != null && !healthObject.IsAlive()) return; // ez és a fenti ugyanaz


        bool up = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        bool down = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        bool right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        bool left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        
        /*
        Vector3 upDir= Vector3.up;
        Vector3 upDir2 = new Vector3(0,1,0);
        Vector3 localUp = transform.up;
        */

        float z = 0;
        if (up && down)
            z = 0;
        else if (up)
            z = 1;
        else if (down)
            z = -1;

        //mindkét megoldás ugyanazt az eredményt adja
        
        float x = 0;
        if (right)
            x += 1;
        if (left)
            x -= 1;

        //Vector3 rightDir = Vector3.right;
        //Vector3 forwardDir = Vector3.forward;

        Vector3 rightDir = moveInCameraSpace ? cameraTransform.right : Vector3.right;
        Vector3 forwardDir = moveInCameraSpace ? cameraTransform.forward : Vector3.forward;

        //Vector3 velocity = new Vector3(x, 0, z);

        Vector3 velocity = rightDir * x + forwardDir * z;
        velocity.y = 0;

        velocity.Normalize();   //normalizálja a sebességet, hogy két billentyû lenyomása esetén ne legyen nagyobb a vektor
        velocity *= speed;

        

        Vector3 p = transform.position;

        Vector3 newPos = p + (velocity * Time.deltaTime);
        transform.position = newPos;

        
        if (velocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity);
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, angularVelocity * Time.deltaTime);

        }
    }
}
