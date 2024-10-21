using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering;

public class MoveRigidBody : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    Rigidbody rb;
    Ray ray;
    int destroyObjectLayer;

    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        destroyObjectLayer = LayerMask.NameToLayer("DestroyObject");
    }
    void Start()
    {
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float rayLengh = 5f;
            ray = new Ray(transform.position, transform.forward * rayLengh);
            if (Physics.Raycast(ray, out RaycastHit hit, rayLengh))
            {
                if (hit.collider.gameObject.layer == destroyObjectLayer)
                {
                    Debug.Log(hit.collider.gameObject.name);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 move = Vector3.zero;
        if (horizontalInput != 0) move += Vector3.right * horizontalInput;
        if (verticalInput != 0)move += Vector3.forward * verticalInput;
        rb.velocity = move * _moveSpeed;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward  * 5f);
    }

    //private void Move()
    //{
    //    Vector3 move = Vector3.zero;
    //    if (Input.GetKey(KeyCode.W)) move += Vector3.forward;
    //    if (Input.GetKey(KeyCode.S)) move += Vector3.back;
    //    if (Input.GetKey(KeyCode.A)) move += Vector3.left;
    //    if (Input.GetKey(KeyCode.D)) move += Vector3.right;
    //    rb.AddForce(move * _moveSpeed);
    //}
}
