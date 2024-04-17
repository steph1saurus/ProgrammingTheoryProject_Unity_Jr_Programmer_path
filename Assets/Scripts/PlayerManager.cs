using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    //player movement

    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;
    

    private float horizontalInput;
    private float forwardInput;

    [SerializeField] float speed;
    

    //shooting ball mechanics
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform shootingPoint;
    public float shootForce;
    private float shootAngle = 45f;



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


        // Calculate the shooting direction (upward)
        Vector3 shootingDirection = transform.up;

        // Apply the forward force to the ball
        ball.GetComponent<Rigidbody>().velocity = transform.forward * shootForce;

        // Calculate the initial velocity based on the desired angle and force
        Vector3 arcVelocity = shootingDirection * shootForce;
        arcVelocity.y = Mathf.Sqrt(arcVelocity.magnitude * Physics.gravity.magnitude / Mathf.Sin(2 * Mathf.Deg2Rad * shootAngle));

        // Apply the arc velocity to the ball rigidbody
        ball.GetComponent<Rigidbody>().velocity += arcVelocity;

     

    }

}

   
