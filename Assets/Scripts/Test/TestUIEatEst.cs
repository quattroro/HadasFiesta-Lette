using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Canvas_Enum;
public class TestUIEatEst : MonoBehaviour
{
   

    void Start()
    {
        //UIManager.Instance.Prefabsload("Inven", UIManager.CANVAS_NUM.player_cavas);
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            UIManager.Instance.Prefabsload("Inven", CANVAS_NUM.player_cavas);
        }
    }
}
