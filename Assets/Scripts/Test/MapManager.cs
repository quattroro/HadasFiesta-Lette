using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager :Singleton<MapManager>
{
  
    public GameObject unit;
    public GameObject Map;
    bool flag = false;

    private void Start()
    {
        Map.SetActive(flag);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            flag = !flag;

            if(Map!=null)
            Map.SetActive(flag);
        }

    }
    public void MoveUnit(Vector3 target)
    {

        GameObject temp2 = AddressablesLoadManager.Instance.Find_InstantiateObj<GameObject>("PlayerCharacter");


        //  Debug.Log("gkgk" + unit.transform.position);
        if (temp2 != null)
        {

            PathRequestManager.RequestPath(temp2.transform.position, target, temp2.GetComponent<Unit>().OnPathFound);
        }

        else
        {
            PathRequestManager.RequestPath(unit.transform.position, target, unit.GetComponent<Unit>().OnPathFound);

        }
    }
}
