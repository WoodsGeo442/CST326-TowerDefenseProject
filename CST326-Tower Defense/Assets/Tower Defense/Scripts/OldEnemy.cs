using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldEnemy : MonoBehaviour
{
    public Path route;
    private Waypoint[] myPathThroughLife;
    public GameController gameScript;
    public GameObject BigEnemy;
    public GameObject SmallEnemy;
    public int coinWorth;
    public float health;
    public float speed = .25f;
    private int index = 0;
    private Vector3 nextWaypoint;
    private bool stop = false;

    void Awake()
    {
        myPathThroughLife = route.path;
        transform.position = myPathThroughLife[index].transform.position;
        Recalculate();
    }

    void Update()
    {
        if (!stop)
        {
        if ((transform.position - myPathThroughLife[index + 1].transform.position).magnitude < .1f)
        {
            index = index + 1;
            Recalculate();
        }


        Vector3 moveThisFrame = nextWaypoint * Time.deltaTime * speed;
        transform.Translate(moveThisFrame);
        }

    }

    void Recalculate()
    {
        if (index < myPathThroughLife.Length -1)
        {
            nextWaypoint = (myPathThroughLife[index + 1].transform.position - myPathThroughLife[index].transform.position).normalized;

        }
        else
        {
        stop = true;
        }
    }

    public void DamageEnemy(string enemyType)
    {
        if(enemyType == "BigBadGuy")
        {
            BigEnemy.GetComponent<OldEnemy>().health = BigEnemy.GetComponent<OldEnemy>().health - 10;
            Debug.Log("Big Enemy Health: " + BigEnemy.GetComponent<OldEnemy>().health);
            if(BigEnemy.GetComponent<OldEnemy>().health <= 0)
            {
                BigEnemy.SetActive(false);
                gameScript.GetComponent<GameController>().GiveMeMoney(BigEnemy.GetComponent<OldEnemy>().coinWorth);
            }
        }
        
        if(enemyType == "SmallBadGuy")
        {
            SmallEnemy.GetComponent<OldEnemy>().health = SmallEnemy.GetComponent<OldEnemy>().health - 10;
            Debug.Log("Small Enemy Health: " + SmallEnemy.GetComponent<OldEnemy>().health);
            if (SmallEnemy.GetComponent<OldEnemy>().health <= 0)
            {
                SmallEnemy.SetActive(false);
                gameScript.GetComponent<GameController>().GiveMeMoney(SmallEnemy.GetComponent<OldEnemy>().coinWorth);
            }
        }
    }
}
