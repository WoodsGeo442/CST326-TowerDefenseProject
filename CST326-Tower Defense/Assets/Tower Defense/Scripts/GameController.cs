using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public OldEnemy enemyScript;
    [SerializeField] private Text coinCount;
    public float totalMoney;

    private void Start()
    {
        totalMoney = 0;
        coinCount.text = "" + totalMoney;
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider BC = hit.collider as BoxCollider;
                if (BC != null)
                {
                    if (BC.gameObject.name == "BigBadGuy")
                    {
                        enemyScript.GetComponent<OldEnemy>().DamageEnemy(BC.gameObject.name);
                    }
                    if (BC.gameObject.name == "SmallBadGuy")
                    {
                        enemyScript.GetComponent<OldEnemy>().DamageEnemy(BC.gameObject.name);
                    }

                }
            }
        }
    }

    public void GiveMeMoney(int coins)
    {
        totalMoney += coins;
        coinCount.text = "" + totalMoney;
    }
}
