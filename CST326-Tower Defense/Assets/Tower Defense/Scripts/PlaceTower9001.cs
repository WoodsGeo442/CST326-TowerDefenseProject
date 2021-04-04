using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceTower9001 : MonoBehaviour
{
  public GameObject Tower;
  [SerializeField] private Text coinCount;
  public float totalMoney;
  public GameObject World;
    // Start is called before the first frame update
    void Start()  
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      coinCount.text = "" + totalMoney;
      if (Input.GetMouseButtonDown(0))
      {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
          if (hit.transform.tag == "TowerSpot")
          {
                //Book keeping
                // if good 
                if(totalMoney < 100)
                {
                    Debug.Log("You're broke");
                } else
                {
                    hit.transform.gameObject.SetActive(false);
                    PlaceTower(hit.transform.position);
                }
                
          }
        else
          print("I'm looking at nothing!");
        
    }

    //raycast
    //hitplace
    //purse script $$$$
    //instantiate a tower

  }

    void PlaceTower(Vector3 position)
    {
        //Book keeping
        Instantiate(Tower, position, Quaternion.identity, World.transform);
        totalMoney -= 100;
        
    }

    public void GimmeMyMoney(int amount)
    {
        totalMoney += amount;
    }
}
