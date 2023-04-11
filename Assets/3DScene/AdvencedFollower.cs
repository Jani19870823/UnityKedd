using UnityEngine;

class AdvencedFollower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float maxSpeed;
    [SerializeField] float maxDistance;
    [SerializeField] AnimationCurve distanceToSpeedCurve;
    [SerializeField] Gradient gradient;
    [SerializeField] Light light;

    float originalIntansity;
    private void Start()
    {
        originalIntansity = light.intensity;
    }


    void Update()
    {
        Vector3 p = transform.position;
        Vector3 t = target.position;

        float distance = Vector3.Distance(p, t);

        float x = distance / maxDistance;
        float speed = distanceToSpeedCurve.Evaluate(x) * maxSpeed;
        Color c = gradient.Evaluate(x);
        light.color = c;
        light.intensity = c.a * originalIntansity;

        transform.position = Vector3.MoveTowards(p, t, speed * Time.deltaTime);
    }
}
