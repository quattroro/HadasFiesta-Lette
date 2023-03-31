using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class InteractiveObjManager : MySingleton<InteractiveObjManager>
{

    [SerializeField]
    Dictionary<string, List<BaseInteractive>> InteractiveObjDic = new Dictionary<string, List<BaseInteractive>>();
    public void SetInteractiveObj(EnumScp.InteractiveIndex index, BaseInteractive obj) //플레이어와 상호작용 하는 obj의 정보를 딕셔너리에 저장
    {

        if (InteractiveObjDic.ContainsKey(obj.name))
        {
            InteractiveObjDic[obj.name].Add(obj);
        }
        else
        {
            List<BaseInteractive> tempList = new List<BaseInteractive>();
            tempList.Add(obj);
            InteractiveObjDic.Add(obj.name, tempList);
        }

    }

    public List<BaseInteractive> GetInteractiveObj(string name) //obj 정보 리스트 리턴
    {
        return InteractiveObjDic[name];
    }

    public BaseInteractive GetInteractiveObj<T>(T type, int Id) //obj 정보 단일 리턴
    {
        List<BaseInteractive> temp;
        InteractiveObjDic.TryGetValue(type.ToString(), out temp);
        for (int i = 0; i < temp.Count; i++)
        {
            if (temp[i].GetInstanceID() == Id)
                return temp[i];
        }
        return null;
    }


    public void EndInteractiveObj(string name) //obj 딕셔너리에서  리스트 삭제
    {
        List<BaseInteractive> temp;
        InteractiveObjDic.TryGetValue(name, out temp);
        for (int i = 0; i < temp.Count; i++)
        {
            Destroy(temp[i].gameObject);
        }
        InteractiveObjDic.Remove(name);
    }

    public void EndInteractiveObj<T>(T type, int id) //obj 딕셔너리에서  단일 삭제
    {
        List<BaseInteractive> temp;
        InteractiveObjDic.TryGetValue(type.ToString(), out temp);


        for (int i = 0; i < temp.Count; i++)
        {
            if (temp[i].GetInstanceID() == id)
            {
                Destroy(temp[i].gameObject);
                InteractiveObjDic[temp[i].GetType().Name].Remove(temp[i]);
            }
        }

    }
    public bool IsInteractiveObj<T>(T type, int id)
    {
        List<BaseInteractive> temp;
        InteractiveObjDic.TryGetValue(type.ToString(), out temp);

        for (int i = 0; i < temp.Count; i++)
        {
            if (temp[i].GetInstanceID() == id)
                return temp[i].P_IsInteractive;
        }

        return false;
    }

    private void Awake() //이미 씬에 존재하는 상호작용 오브젝트인 경우 미리 저장하여 관리함
    {
        BaseInteractive[] temp = FindObjectsOfType<BaseInteractive>();
        for (int i = 0; i < temp.Length; i++)
        {
            if (InteractiveObjDic.ContainsKey(temp[i].GetType().Name))
            {
                InteractiveObjDic[temp[i].GetType().Name].Add(temp[i]);
            }
            else
            {
                List<BaseInteractive> tempList = new List<BaseInteractive>();
                tempList.Add(temp[i]);
                InteractiveObjDic.Add(temp[i].GetType().Name, tempList);
            }
        }
    }
}