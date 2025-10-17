using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerNavMovement : MonoBehaviour
{
    public float speed = 6f;
    public float rotationSpeed = 100f;

    private NavMeshAgent agent;
    private Rigidbody rb;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        agent.speed = speed;
        rb.isKinematic = true;

        agent.updatePosition = false;
        agent.updateRotation = false;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = transform.forward * vertical + transform.right * horizontal;

        agent.velocity = direction.normalized * speed;

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        Vector3 nextPosition = rb.position + agent.velocity * Time.deltaTime;
        rb.MovePosition(nextPosition);
    }

    void LateUpdate()
    {
        agent.nextPosition = rb.position;
    }
}