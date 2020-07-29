using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public float jump_force = 15;
    private bool airborne = false;

    public float move_speed = 15;
    private Vector3 move_dir;

    public float horizontal_sensitivity = 10;
    public float vertical_sensitivity = 5;
    public bool invert_y_axis = true;

    private Rigidbody my_body;
    private Transform camera_transform;

    void Start() 
    {
        Cursor.visible = false;
        my_body = GetComponent<Rigidbody>();
        camera_transform = transform.GetChild(0).transform;
        GetComponent<Rigidbody>().useGravity = false;
    }

    void Update() 
    {
        move_dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        if (Input.GetKeyDown("space") && !airborne)
        {
            airborne = true;
            transform.GetComponent<Rigidbody>().AddForce(transform.up * jump_force, ForceMode.Impulse);
        }
    }

    void FixedUpdate() 
    {
        Vector3 local_dir = transform.TransformDirection(move_dir);
        my_body.MovePosition(my_body.position + local_dir * move_speed * Time.deltaTime);

        transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse X") * horizontal_sensitivity, Vector3.up);

        if (invert_y_axis)
        {
            camera_transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * -vertical_sensitivity, Vector3.right);
        }
        else
        {
            camera_transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * vertical_sensitivity, Vector3.right);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Planet")
        {
            airborne = false;
        }
    }
}
