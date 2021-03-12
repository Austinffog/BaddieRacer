using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform target1, target2, target3, target4, target5, target6, target7, target8, target9, target10;
    private Vector2 target;
    private float moveSpeedYellow = 5f, moveSpeedBlue = 6.5f, moveSpeedGreen = 7f, moveSpeedPurple = 7.5f, moveSpeedPink = 8f;
    public float moveSpeed;

    private float number;

    private GameObject YellowCar, BlueCar, GreenCar, PurpleCar, PinkCar;
    public Vector3 spawnValues;
    private Vector3 spawnPosition;

    public float points = 0;
    private Text pointsCounter;
    private float blackCarPoint;

    public GameObject speedUp;
    private AudioSource crash;

    // Start is called before the first frame update
    void Start()
    {
        //assign transforms to target gameObjects
        target1 = GameObject.Find("Target1").GetComponent<Transform>();
        target2 = GameObject.Find("Target2").GetComponent<Transform>();
        target3 = GameObject.Find("Target3").GetComponent<Transform>();
        target4 = GameObject.Find("Target4").GetComponent<Transform>();
        target5 = GameObject.Find("Target5").GetComponent<Transform>();
        target6 = GameObject.Find("Target6").GetComponent<Transform>();
        target7 = GameObject.Find("Target7").GetComponent<Transform>();
        target8 = GameObject.Find("Target8").GetComponent<Transform>();
        target9 = GameObject.Find("Target9").GetComponent<Transform>();
        target10 = GameObject.Find("Target10").GetComponent<Transform>();

        //assign specific speed for each enemy car
        if (gameObject.CompareTag("YellowCar"))
        {
            moveSpeed = moveSpeedYellow;
        }
        else if (gameObject.CompareTag("BlueCar"))
        {
            moveSpeed = moveSpeedBlue;
        }
        else if (gameObject.CompareTag("GreenCar"))
        {
            moveSpeed = moveSpeedGreen;
        }
        else if (gameObject.CompareTag("PurpleCar"))
        {
            moveSpeed = moveSpeedPurple;
        }
        else if (gameObject.CompareTag("PinkCar"))
        {
            moveSpeed = moveSpeedPink;
        }

        number = Random.Range(1, 11);

        PlayerPrefs.GetFloat("points", points);
        pointsCounter = GameObject.Find("PointsCounter").GetComponent<Text>();

        crash = GameObject.Find("CrashSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        TargetDecision(); //get a target

        if (transform.position.x == target.x && transform.position.y == target.y) //if the transforms are equal change target
        {
            number = Random.Range(1, 11);
            TargetDecision();
        }
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime); //move the gameObject to target

        points = PlayerPrefs.GetFloat("points", points);
        pointsCounter.text = "Your points: " + points.ToString();
        Points();
    }

    private void TargetDecision()
    {
        switch (number)
        {
            case 1:
                target = new Vector2(target1.position.x, target1.position.y);
                break;
            case 2:
                target = new Vector2(target2.position.x, target2.position.y);
                break;
            case 3:
                target = new Vector2(target3.position.x, target3.position.y);
                break;
            case 4:
                target = new Vector2(target4.position.x, target4.position.y);
                break;
            case 5:
                target = new Vector2(target5.position.x, target5.position.y);
                break;
            case 6:
                target = new Vector2(target6.position.x, target6.position.y);
                break;
            case 7:
                target = new Vector2(target7.position.x, target7.position.y);
                break;
            case 8:
                target = new Vector2(target8.position.x, target8.position.y);
                break;
            case 9:
                target = new Vector2(target9.position.x, target9.position.y);
                break;
            case 10:
                target = new Vector2(target10.position.x, target10.position.y);
                break;
        }
    }

    #region Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //assign the gameObjects
        YellowCar = GameObject.Find("PlayerCar").GetComponent<Player>().yellowCar;
        BlueCar = GameObject.Find("PlayerCar").GetComponent<Player>().blueCar;
        GreenCar = GameObject.Find("PlayerCar").GetComponent<Player>().greenCar;
        PurpleCar = GameObject.Find("PlayerCar").GetComponent<Player>().purpleCar;
        PinkCar = GameObject.Find("PlayerCar").GetComponent<Player>().pinkCar;

        //check which gameObject collided with player, then spawn the enemy car in a new position and delete the previous
        if (gameObject.CompareTag("YellowCar") && collision.gameObject.name == ("PlayerCar"))
        {
            crash.Play();

            Instantiate(speedUp, YellowCar.transform.position, gameObject.transform.rotation);

            spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);
            Instantiate(YellowCar, spawnPosition, gameObject.transform.rotation);
            Destroy(gameObject);

            points += 5f;
            PlayerPrefs.SetFloat("points", points);
        }
        if (gameObject.CompareTag("BlueCar") && collision.gameObject.name == ("PlayerCar"))
        {
            crash.Play();

            Destroy(gameObject);
            spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);
            Instantiate(BlueCar, spawnPosition, gameObject.transform.rotation);

            points += 10f;
            PlayerPrefs.SetFloat("points", points);
        }
        if (gameObject.CompareTag("GreenCar") && collision.gameObject.name == ("PlayerCar"))
        {
            crash.Play();

            Destroy(gameObject);
            spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);
            Instantiate(GreenCar, spawnPosition, gameObject.transform.rotation);

            points += 15f;
            PlayerPrefs.SetFloat("points", points);
        }
        if (gameObject.CompareTag("PurpleCar") && collision.gameObject.name == ("PlayerCar"))
        {
            crash.Play();

            Destroy(gameObject);
            spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);
            Instantiate(PurpleCar, spawnPosition, gameObject.transform.rotation);

            points += 20f;
            PlayerPrefs.SetFloat("points", points);
        }
        if (gameObject.CompareTag("PinkCar") && collision.gameObject.name == ("PlayerCar"))
        {
            crash.Play();

            Destroy(gameObject);
            spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);
            Instantiate(PinkCar, spawnPosition, gameObject.transform.rotation);

            points += 25f;
            PlayerPrefs.SetFloat("points", points);
        }

        if (gameObject.CompareTag("YellowCar")  && collision.gameObject.name == ("Puddle(Clone)"))
        {
            Destroy(collision.gameObject);
        }
        if (gameObject.CompareTag("BlueCar")  && collision.gameObject.name == ("Puddle(Clone)"))
        {
            Destroy(collision.gameObject);
        }
        if (gameObject.CompareTag("GreenCar") && collision.gameObject.name == ("Puddle(Clone)"))
        {
            Destroy(collision.gameObject);
        }
        if (gameObject.CompareTag("PurpleCar") && collision.gameObject.name == ("Puddle(Clone)"))
        {
            Destroy(collision.gameObject);
        }
        if (gameObject.CompareTag("PinkCar") && collision.gameObject.name == ("Puddle(Clone)"))
        {
            Destroy(collision.gameObject);
        }

        //prevents the cars from getting stuck with the BlackCar
        if (gameObject.CompareTag("YellowCar") && collision.gameObject.name == ("BlackCar(Clone)"))
        {
            spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);
            Instantiate(YellowCar, spawnPosition, gameObject.transform.rotation);
            Destroy(gameObject);
        }
        if (gameObject.CompareTag("BlueCar") && collision.gameObject.name == ("BlackCar(Clone)"))
        {
            spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);
            Instantiate(BlueCar, spawnPosition, gameObject.transform.rotation);
            Destroy(gameObject);
        }
        if (gameObject.CompareTag("GreenCar") && collision.gameObject.name == ("BlackCar(Clone)"))
        {
            spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);
            Instantiate(GreenCar, spawnPosition, gameObject.transform.rotation);
            Destroy(gameObject);
        }
        if (gameObject.CompareTag("PurpleCar") && collision.gameObject.name == ("BlackCar(Clone)"))
        {
            spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);
            Instantiate(PurpleCar, spawnPosition, gameObject.transform.rotation);
            Destroy(gameObject);
        }
        if (gameObject.CompareTag("PinkCar") && collision.gameObject.name == ("BlackCar(Clone)"))
        {
            spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);
            Instantiate(PinkCar, spawnPosition, gameObject.transform.rotation);
            Destroy(gameObject);
        }

    }
    #endregion

    #region Points
    void Points()
    {
        blackCarPoint = GameObject.Find("BlackCar(Clone)").GetComponent<EnemyFollow>().blackCarPoints;

        if (points >= 100f && blackCarPoint < 100f)
        {
            GameObject.Find("Menus").GetComponent<Menus>().Victory();
            points = 0f;
            PlayerPrefs.SetFloat("points", points);
            blackCarPoint = 0f;
            PlayerPrefs.SetFloat("blackCarPoints", blackCarPoint);
        }
        if (blackCarPoint >= 100f && points < 100f)
        {
            GameObject.Find("Menus").GetComponent<Menus>().GameOver();
            points = 0f;
            PlayerPrefs.SetFloat("points", points);
            blackCarPoint = 0f;
            PlayerPrefs.SetFloat("blackCarPoints", blackCarPoint);
        }
    }
    #endregion
}

/*
 References

 Freesound. 2021. Retro_Explosion_07 by MATRIXXX_, 4 June 2020. [Online].
 Available at: https://freesound.org/people/MATRIXXX_/sounds/521105/. [Accessed 9 March 2021].

 */
