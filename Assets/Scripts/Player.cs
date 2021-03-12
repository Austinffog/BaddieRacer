using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 7f;
    private float horizontal, vertical;
    private Vector2 moveDirection;
    private Rigidbody2D rb;

    public GameObject redCar, blackCar, yellowCar, blueCar, greenCar, purpleCar, pinkCar;
    public Vector3 spawnValues;
    private Vector3 spawnPositionYellow, spawnPositionBlue, spawnPositionGreen, spawnPositionPurple, spawnPositionPink, spawnPositionRed,
        spawnPositionBlack;

    public AudioSource puddle, speedUpSound;

    // Start is called before the first frame update
    void Start()
    {
        Enemy();

        EnemyFollow();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput();
    }

    void FixedUpdate()
    {
        Movement();
    }

    #region Movement
    private void MoveInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(horizontal, vertical).normalized;
    }

    private void Movement()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    #endregion


    #region Spawn Enemy
    public void Enemy()
    {
        //a new spawn poistion is given to each car so that they don't spawn in the same poistion and collide
        spawnPositionYellow = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);
        spawnPositionBlue = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);
        spawnPositionGreen = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);
        spawnPositionPurple = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);
        spawnPositionPink = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);

        Instantiate(yellowCar, spawnPositionYellow + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
        Instantiate(blueCar, spawnPositionBlue + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
        Instantiate(greenCar, spawnPositionGreen + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
        Instantiate(purpleCar, spawnPositionPurple + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
        Instantiate(pinkCar, spawnPositionPink + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
    }

    void EnemyFollow()
    {
        //enemy followers
        spawnPositionRed = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);
        spawnPositionBlack = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);

        Instantiate(redCar, spawnPositionRed + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
        Instantiate(blackCar, spawnPositionBlack + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
    }
    #endregion

    #region Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == ("Puddle(Clone)")) //obstacle
        {
            Destroy(collision.gameObject);
            moveSpeed = 5f;
            puddle.Play();
            Invoke("Speed", 7f);
        }
        if (collision.gameObject.name == ("SpeedUp(Clone)")) //power up
        {
            Destroy(collision.gameObject);
            moveSpeed = 8f;
            speedUpSound.Play();
            Invoke("Speed", 7f);
        }
    }

    private void Speed()
    {
        moveSpeed = 7f;
    }
    #endregion
}

/*
 References

 Freesound. 2021. Percussive sample pack by Chris Reierson » frozen wind chime ding, 23 December 2016. [Online].
 Available at: https://freesound.org/people/ChrisReierson/sounds/383979/. [Accessed 9 March 2021].

 Freesound. 2021. JumpIntoPuddle by WildToFurkey, 20 Febraury 2020. [Online]. Available at: 
 https://freesound.org/people/wildtofurkey/sounds/506526/. [Accessed 9 March 2021].

 Freesound. 2021. Race Track by FoolBoyMedia, 8 May 2014. [Online]. Available at: 
 https://freesound.org/people/wildtofurkey/sounds/506526/. [Accessed 9 March 2021].

 */
