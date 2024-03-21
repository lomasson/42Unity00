using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Vector3 velocity;
    [SerializeField]
    private Camera cam;
    private Vector3 rotation;
    private Vector3 camRotation;
    private CapsuleCollider playerCollider;
    private Rigidbody rb;
    // Start is called before the first frame update
    private void Start()
    {
      rb = GetComponent<Rigidbody>();
      playerCollider = GetComponent<CapsuleCollider>();
    }

    public void Move(Vector3 _velocity)
    {
      velocity = _velocity;
    }
    public void Rotate(Vector3 _rotation)
    {
      rotation = _rotation;
    }
    public void CamRotate(Vector3 _camRotation)
    {
      camRotation = _camRotation;
    }
    public void Jump(Vector3 _jumpSpeed)
    {
      if(isGrounded())
      {
        rb.AddForce(_jumpSpeed.y * Vector3.up);
        _jumpSpeed = new Vector3(0,0,0);
      }
    }
    // Update is called once per frame
    private bool isGrounded()
    {
      return Physics.RaycastAll(transform.position, Vector3.down, .8f).Length > 0;
    }

    private void Update()
    {
      PerformMovement();
      PerformRotation();
    }

    private void PerformMovement()
    {
      if (velocity != Vector3.zero)
      {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
      }

    }
    private void PerformRotation()
    {
      rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
      cam.transform.Rotate(-camRotation);
    }
}
