using UnityEngine;

public class PlayerController : MonoBehaviour 
{

    public float move_speed = 15;
    private Vector3 move_dir;

    public float horizontal_sensitivity = 10;
    public float vertical_sensitivity = 5;
    public bool invert_y_axis = true;

    private Rigidbody my_body;
    private Transform camera;

    void Start() 
    {
        Cursor.visible = false;
        my_body = GetComponent<Rigidbody>();
        camera = transform.GetChild(0).transform;
    }

    void Update() 
    {
        move_dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }

    void FixedUpdate() 
    {
        Vector3 local_dir = transform.TransformDirection(move_dir);
        my_body.MovePosition(my_body.position + local_dir * move_speed * Time.deltaTime);

        transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse X") * horizontal_sensitivity, Vector3.up);

        if (invert_y_axis)
        {
            camera.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * -vertical_sensitivity, Vector3.right);
        }
        else
        {
            camera.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * vertical_sensitivity, Vector3.right);
        }
    }
}
