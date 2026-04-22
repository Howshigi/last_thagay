using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Ball Settings")]
    public float maxSpeed = 20f;
    public float extraBounce = 1.1f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        rb.useGravity = true;
        rb.mass = 1f;
        rb.linearDamping = 0f;
        rb.angularDamping = 0.05f;
    }

    void FixedUpdate()
    {
        
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("ชน: " + col.gameObject.name);

        
        if (col.gameObject.CompareTag("Line"))
        {
            Vector3 normal = col.contacts[0].normal;
            Vector3 reflect = Vector3.Reflect(rb.linearVelocity, normal);

            rb.linearVelocity = reflect * extraBounce;
        }

        
        
    }
}