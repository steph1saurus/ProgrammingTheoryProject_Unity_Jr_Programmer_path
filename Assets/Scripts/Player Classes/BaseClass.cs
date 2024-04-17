using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass: MonoBehaviour
{
    private string baseCharacterName = "Base";
    private string baseCharacterHeight = "5ft";
    private float baseSpeed = 4f;
    private float baseShootForce = 5f;

    public virtual string CharacterName
    {
        get => baseCharacterName; set => baseCharacterName = value;
    }

    public virtual string CharacterHeight
    {
        get => baseCharacterHeight; set => baseCharacterHeight = value;
    }

    public virtual float speed
    {
        get => baseSpeed; set => baseSpeed = value;
    }
    public virtual float shootForce
    {
        get => baseShootForce; set => baseShootForce = value;
    }

    //------//
    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;


    private float horizontalInput;
    private float forwardInput;


    //shooting ball mechanics
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform shootingPoint;
    private float shootAngle = 45f;



    // Update is called once per frame
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

        //move player left or right
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        //move player forward or back
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

    }

    public void RotatePlayer()
    {
        if (Input.GetMouseButton(0))
        {
            mPosDelta = Input.mousePosition - mPrevPos;
            transform.Rotate(transform.up, Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
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