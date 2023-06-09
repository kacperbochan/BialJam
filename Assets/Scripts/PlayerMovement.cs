using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sideForce = 500f;
    private Vector3 turn;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Added");
        rb.AddForce(0,0,0);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            turn = new Vector3(0, sideForce, 0);
            Quaternion deltaRotation = Quaternion.Euler(turn * Time.fixedDeltaTime);
            rb.MoveRotation(deltaRotation);
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(Input.GetKey("a"))
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        

    }
}
