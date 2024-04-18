using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass: MonoBehaviour
{
    private string baseCharacterName = "Base";
    private string baseCharacterHeight = "5ft";
    private float baseSpeed = 4f;
    private float baseShootForce = 3f;

    public virtual string CharacterName {
        get => baseCharacterName; set => baseCharacterName = value;
    }

    public virtual string CharacterHeight{
        get => baseCharacterHeight; set => baseCharacterHeight = value;
    }

    public virtual float speed{
        get => baseSpeed; set => baseSpeed = value;
    }

    public virtual float shootForce{
        get => baseShootForce; set => baseShootForce = value;
    }

    //old player movement
    //Vector3 mPrevPos = Vector3.zero;
    //Vector3 mPosDelta = Vector3.zero;

    //old player inputs
    //private float horizontalInput;
    //private float forwardInput;

    //new player input
    private Vector3 mPrevPos;
    private Vector3 mPosDelta;


    private float rotationSpeed = 10f; //rotatiing player speed

    //shooting ball mechanics
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform shootingPoint;
    private float shootAngle = 75f;



    void Update()
    {
        MovePlayer();
        RotatePlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBall();
        }

    }

    public void MovePlayer()
    {

        //move player based on camera direection
        float horizontalInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        //project camera direction and ignore vertical component
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        //normalize vectors
        cameraForward.Normalize();
        cameraRight.Normalize();


        //calculate movemeent
        Vector3 moveDirection = (cameraForward * forwardInput + cameraRight * horizontalInput).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);


        //old player movement
        //transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

    }

    public void RotatePlayer()
    {
        if (Input.GetMouseButton(0))
        {
            //    mPosDelta = Input.mousePosition - mPrevPos;
            //    transform.Rotate(transform.up, Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
            mPosDelta = Input.mousePosition - mPrevPos;

            float rotationAngle = Vector3.Dot(mPosDelta, Camera.main.transform.right) * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAngle, Space.World);
        }
        mPrevPos = Input.mousePosition;
    }

    public void ShootBall()
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