using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyFollow : MonoBehaviour
{
    private Transform player, target1, target2, target3, target4, target5;
    private Vector2 target;
    private float moveSpeedRed = 6f, moveSpeedBlack = 6.5f;
    public float moveSpeed;

    private float number;

    private GameObject RedCar;
    public Vector3 spawnValues;
    private Vector3 spawnPosition;

    public float blackCarPoints = 0;
    private Text BlackCarPoints;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("PlayerCar").GetComponent<Transform>();

        if (gameObject.CompareTag("RedCar"))
        {
            moveSpeed = moveSpeedRed;
        }
        else if (gameObject.CompareTag("BlackCar"))
        {
            moveSpeed = moveSpeedBlack;
        }

        blackCarPoints = 0f;
        PlayerPrefs.GetFloat("blackCarPoints", blackCarPoints);
        BlackCarPoints = GameObject.Find("BlackCarPoints").GetComponent<Text>();

        number = Random.Range(1, 6);

    }

    // Update is called once per frame
    void Update()
    {
        //get the targets transforms in update because they are being deleted and made null by the player on collision
        Targets();

        if (gameObject.CompareTag("RedCar")) //if the script is on the red car follow the player
        {
            target = new Vector2(player.position.x, player.position.y);
            transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        }
        else if (gameObject.CompareTag("BlackCar")) //if the script is on the black car, follow a random enemy car
        {
            TargetDecision();
            transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        }

        blackCarPoints = PlayerPrefs.GetFloat("blackCarPoints", blackCarPoints);
        BlackCarPoints.text = "Black Car: " + blackCarPoints.ToString();

    }

    #region Target
    private void TargetDecision()
    {
        switch (number)
        {
            case 1:
                try //try and catch was used to check if the target transform was null, code has been cleaned up
                {
                    target = new Vector2(target1.position.x, target1.position.y);
                    //Debug.Log("t1"); //check which target is current
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
                break;
            case 2:
                try
                {
                    target = new Vector2(target2.position.x, target2.position.y);
                    //Debug.Log("t2");
                }
                catch (Exception f)
                {
                    Debug.Log(f);
                }
                break;
            case 3:
                try
                {
                    target = new Vector2(target3.position.x, target3.position.y);
                    //Debug.Log("t3");
                }
                catch (Exception g)
                {
                    Debug.Log(g);
                }
                break;
            case 4:
                try
                {
                    target = new Vector2(target4.position.x, target4.position.y);
                    //Debug.Log("t4");
                }
                catch (Exception h)
                {
                    Debug.Log(h);
                }
                break;
            case 5:
                try
                {
                    target = new Vector2(target5.position.x, target5.position.y);
                    //Debug.Log("t5");
                }
                catch (Exception i)
                {
                    Debug.Log(i);
                }
                break;

        }
    }

    void Targets()
    {
        target1 = GameObject.Find("YellowCar(Clone)").GetComponent<Transform>();
        target2 = GameObject.Find("BlueCar(Clone)").GetComponent<Transform>();
        target3 = GameObject.Find("GreenCar(Clone)").GetComponent<Transform>();
        target4 = GameObject.Find("PurpleCar(Clone)").GetComponent<Transform>();
        target5 = GameObject.Find("PinkCar(Clone)").GetComponent<Transform>();
    }
    #endregion

    #region Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        RedCar = GameObject.Find("PlayerCar").GetComponent<Player>().redCar;

        number = Random.Range(1, 6);

        //if the red car bumbc inyo the player respawn it into a different position, delete the previous and deduct three points
        if (gameObject.CompareTag("RedCar") && collision.gameObject.name == ("PlayerCar"))
        {
            Destroy(gameObject);
            spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);
            Instantiate(RedCar, spawnPosition, gameObject.transform.rotation);

            GameObject.Find("YellowCar(Clone)").GetComponent<Enemy>().points -= 3f;
            PlayerPrefs.SetFloat("points", GameObject.Find("YellowCar(Clone)").GetComponent<Enemy>().points);
        }

        //if the black car collides into an enemy car add points and switch the target
        if (gameObject.CompareTag("BlackCar") && collision.gameObject.name == ("YellowCar(Clone)"))
        {
            //Debug.Log("HitY"); //Check which color is hit
            TargetDecision();
            blackCarPoints += 5f;
            PlayerPrefs.SetFloat("blackCarPoints", blackCarPoints);
        }
        if (gameObject.CompareTag("BlackCar") && collision.gameObject.name == ("BlueCar(Clone)"))
        {
            //Debug.Log("HitB");
            TargetDecision();
            blackCarPoints += 10f;
            PlayerPrefs.SetFloat("blackCarPoints", blackCarPoints);
        }
        if (gameObject.CompareTag("BlackCar") && collision.gameObject.name == ("GreenCar(Clone)"))
        {
            //Debug.Log("HitG");
            TargetDecision();
            blackCarPoints += 15f;
            PlayerPrefs.SetFloat("blackCarPoints", blackCarPoints);
        }
        if (gameObject.CompareTag("BlackCar") && collision.gameObject.name == ("PurpleCar(Clone)"))
        {
            //Debug.Log("HitP");
            TargetDecision();
            blackCarPoints += 20f;
            PlayerPrefs.SetFloat("blackCarPoints", blackCarPoints);
        }
        if (gameObject.CompareTag("BlackCar") && collision.gameObject.name == ("PinkCar(Clone)"))
        {
            //Debug.Log("HitP");
            TargetDecision();
            blackCarPoints += 25f;
            PlayerPrefs.SetFloat("blackCarPoints", blackCarPoints);
        }

        if (gameObject.CompareTag("BlackCar") && collision.gameObject.name == ("Puddle(Clone)"))
        {
            Destroy(collision.gameObject);
        }
        if (gameObject.CompareTag("RedCar") && collision.gameObject.name == ("Puddle(Clone)"))
        {
            Destroy(collision.gameObject);
        }

    }
    #endregion
}
