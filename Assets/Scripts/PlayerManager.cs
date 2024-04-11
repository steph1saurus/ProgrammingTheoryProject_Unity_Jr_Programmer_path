using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    //player movement

    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;

    [SerializeField] float horizontalInput;
    [SerializeField] float forwardInput;

    private float m_speed = 4f;
    [SerializeField]
    float speed //set one speed that people can't adjust
    {
        get { return m_speed; }
        set { m_speed = value; }

    }

    //shooting ball mechanics
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float shootForce = 5f;
    [SerializeField] float shootAngle = 45f;
    [SerializeField] Transform shootingPoint;

    private float initialYRotation; // Initial rotation on the y-axis

    private void Start()
    {
        initialYRotation = transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShootBall();
        }

    }

    private void MovePlayer()
    {

        //move player left or right
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        //move player forward or back
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

    }

    private void RotatePlayer()
    {
        if (Input.GetMouseButton(0))
        {
            mPosDelta = Input.mousePosition - mPrevPos;
            transform.Rotate(transform.up, Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
        }
        mPrevPos = Input.mousePosition;
    }

    private void ShootBall()
    {

        // Instantiate the ball prefab
        GameObject ball = Instantiate(ballPrefab, shootingPoint.position, Quaternion.identity);

        // Store the current rotation
        Quaternion originalRotation = transform.rotation;

        // Reset the rotation on the y-axis to the initial value
        Vector3 euler = transform.rotation.eulerAngles;
        euler.y = initialYRotation;
        transform.rotation = Quaternion.Euler(euler);

        // Calculate the shooting direction (upward)
        Vector3 shootingDirection = transform.up;

        // Apply the forward force to the ball
        ball.GetComponent<Rigidbody>().velocity = transform.forward * shootForce;

        // Calculate the initial velocity based on the desired angle and force
        Vector3 arcVelocity = shootingDirection * shootForce;
        arcVelocity.y = Mathf.Sqrt(arcVelocity.magnitude * Physics.gravity.magnitude / Mathf.Sin(2 * Mathf.Deg2Rad * shootAngle));

        // Apply the arc velocity to the ball rigidbody
        ball.GetComponent<Rigidbody>().velocity += arcVelocity;

        // Restore the original rotation
        transform.rotation = originalRotation;

    }

}

   
