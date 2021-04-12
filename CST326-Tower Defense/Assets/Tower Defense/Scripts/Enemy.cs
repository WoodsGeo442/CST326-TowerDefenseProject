using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
  public Path route;
  private Waypoint[] myPathThroughLife;
  public PlaceTower9001 towerScript;
  public GameController gameScript;
  public HordeManager hordeScript;
  public int coinWorth;
  public float health = 100;
  public float speed = .25f;
  private int index = 0;
  private Vector3 nextWaypoint;
  private bool stop = false;
  private float healthPerUnit;

  public Transform healthBar;

  public UnityEvent DeathEvent;

  void Start()
  {
    healthPerUnit = 100f / health;

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
      Time.timeScale = 0f;
      gameScript.GetComponent<GameController>().ShowRestart();
    }
  }

  public void Damage(float damageAmount)
  {
    health -= damageAmount;
    if (health <= 0)
    {
        towerScript.GetComponent<PlaceTower9001>().GimmeMyMoney(this.GetComponent<Enemy>().coinWorth);
        hordeScript.GetComponent<HordeManager>().RemoveEnemy();
        Debug.Log($"{this.coinWorth} is Dead");
        DeathEvent.Invoke();
        DeathEvent.RemoveAllListeners();
        Destroy(this.gameObject);
    }

    float percentage = healthPerUnit * health;
    Vector3 newHealthAmount = new Vector3(percentage/100f , healthBar.localScale.y, healthBar.localScale.z);
    healthBar.localScale = newHealthAmount;
  } 

}
