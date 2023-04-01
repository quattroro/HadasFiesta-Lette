//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AttackManager : MonoBehaviour
//{
//    [SerializeField]
//    CurState curval;
//    [SerializeField]
//    List<float> Movedic = new List<float>();
//    [SerializeField]
//    List<float> Movetime = new List<float>();
//    [SerializeField]
//    List<string> nameClip = new List<string>();
//    public CMoveComponent movecom;
//    public AnimationEventSystem eventsystem;

//    public bool ComboAttackState;
//    public PlayerAttack PlayerScp;
//    public Battle_Character enemyScp;



//    public GameObject effectManagerTest;
//    // public 몬스터 scp
//    public void PlayerAddAttackInfo(string name , float move , float time)
//    {
//        PlayerScp = GetComponentInChildren<PlayerAttack>();
//        nameClip.Add(name);
//        Movetime.Add(time);
//        Movedic.Add(move);

//        eventsystem.AddEvent(new KeyValuePair<string, AnimationEventSystem.beginCallback>(null, null),
//                new KeyValuePair<string, AnimationEventSystem.midCallback>(name, AttackMove),
//               new KeyValuePair<string, AnimationEventSystem.endCallback>(name, AttackEnd));
//    }
//    public void MonsterAddAttackInfo(string name, float move, float time)
//    {
//        enemyScp = GetComponentInChildren<Battle_Character>();
//        nameClip.Add(name);
//        Movetime.Add(time);
//        Movedic.Add(move);

//        eventsystem.AddEvent(new KeyValuePair<string, AnimationEventSystem.beginCallback>(null, null),
//                new KeyValuePair<string, AnimationEventSystem.midCallback>(name, AttackMove),
//               new KeyValuePair<string, AnimationEventSystem.endCallback>(name, AttackEnd));
//    }
//    public void AttackMana(AnimationController animator, string AniName, float time)
//    {
//        if (movecom == null)
//        {
//            movecom = PlayableCharacter.Instance.GetMyComponent(CharEnumTypes.eComponentTypes.MoveCom) as CMoveComponent;
//            //testAttckmanager.AddComponent(movecom);
//            curval = movecom.curval;
//        }
//        Debug.Log(AniName);
//        animator.Play(AniName, time);
//    }
//    public void ComboAttackMana(AnimationController animator, string AniName, float time)
//    {
//        if (movecom == null)
//        {
//            movecom = PlayableCharacter.Instance.GetMyComponent(CharEnumTypes.eComponentTypes.MoveCom) as CMoveComponent;
//            //testAttckmanager.AddComponent(movecom);
//            curval = movecom.curval;
//        }
//        Debug.Log(AniName);
//        ComboAttackState = true;
//        animator.Play(AniName, time);
//    }

//    public void CreateEffect(string adressableAdress , Transform EffectPosRot , float destroyTime , float damage)
//    {
//        GameObject effectobj;
       
//        effectobj = EffectManager.Instance.InstantiateEffect(adressableAdress, EffectPosRot.position, EffectPosRot.rotation, destroyTime);
//        effectobj.GetComponent<ColliderEventDamage>().DamageSetting(damage);
       
//        //StartCoroutine(Cor_TimeCounter(destroyTime , effectobj));

//    }

//    IEnumerator Cor_TimeCounter(float time , GameObject obj)
//    {
//        float starttime = Time.time;

//        while (true)
//        {
//            if ((Time.time - starttime) >= time)
//            {
//                Destroy(obj);
//                yield break;
//            }
//            yield return new WaitForSeconds(Time.deltaTime);
//        }
//    }
//    public void AttackMove(string clipname)
//    {
//        Debug.Log("attackMove");

//        for (int i = 0; i < nameClip.Count; i++)
//        {
//            if (nameClip[i] == clipname)
//            {
//                movecom.FowardDoMove(Movedic[i], Movetime[i]);
//                return;
//            }
//        }
//    }

//    public void AttackEnd(string s_val)
//    {
//        //if (effectobj != null)
//        //{
//        //    Debug.Log($"dasdw공격 끝 들어옴 -> {s_val}");
//        //    effectobj.transform.parent = preparent;
//        //}


//        if (curval.IsAttacking == true)
//            curval.IsAttacking = false;
//        if (ComboAttackState)
//            ComboAttackEnd();
//        Debug.Log("AttackEnd");

//    }

    
//    public void ComboAttackEnd()
//    {        
//        float lastAttackTime = Time.time;
//        PlayerScp.AttackTime(lastAttackTime);
//        ComboAttackState = false;
//    }
    

//    private void Awake()
//    {
//        eventsystem = GetComponentInChildren<AnimationEventSystem>();       
//    }

//    void Start()
//    {
//        ComboAttackState = false;
        

//    }


//    void Update()
//    {

//    }

////    foreach (var item in ComboEffectDic)
////        {
////            if (item.Key == Id)
////            {
////                RemoveDic(item.Value, Id);
////}
////        }
//}
