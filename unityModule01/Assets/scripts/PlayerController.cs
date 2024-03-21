using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float speed;
  [SerializeField]
  private float mouseSensityvityX;
  [SerializeField]
  private float jumpSpeed;

  [SerializeField]
  private float mouseSensityvityY;
  private PlayerMotor motor;
  private bool isJumping;

  private void Start() {
    motor = GetComponent<PlayerMotor>();
  }

  private void Update() {
    float xMov = Input.GetAxisRaw("Horizontal");
    float zMov = Input.GetAxisRaw("Vertical");
    float yRot = Input.GetAxisRaw("Mouse X");
    float xRot = Input.GetAxisRaw("Mouse Y");

    Vector3 moveHorizontal = transform.right * xMov;
    Vector3 moveVertical = transform.forward * zMov;
    Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;
    Vector3 camRotation = new Vector3(xRot, 0, 0) * mouseSensityvityY;
    Vector3 rotation = new Vector3(0, yRot, 0) * mouseSensityvityX;

    motor.Move(velocity);
    motor.Rotate(rotation);
    motor.CamRotate(camRotation);
    if (Input.GetButtonDown("Jump"))
      motor.Jump(new Vector3(0, jumpSpeed, 0));


  } 
}
