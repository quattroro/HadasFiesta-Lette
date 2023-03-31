using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Weapon : MonoBehaviour
{
    public Battle_Character parent_character;

    [SerializeField]
    public Enemy_Enum.Enemy_Attack_Logic my_Logic;

    void Start()
    {
        if (parent_character == null)
            parent_character = GetComponentInParent<Battle_Character>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ㅍㄹ레이어알ㅇㅇㄹㅇㄹㅇㄹㅇㄹㅇㄹ");
            Vector3 p = collision.collider.ClosestPoint(collision.transform.position);

            switch (parent_character.attack_Type) // 공격 타입에 맞게 데미지를 입혀줌.
            {
                case Enemy_Enum.Enemy_Attack_Type.Normal_Attack:
                    collision.gameObject.GetComponent<PlayableCharacter>().BeAttacked(parent_character.mon_Info.P_mon_Atk, /*collider.transform.position*/p
                        , parent_character.cur_Groggy);
                    break;
                case Enemy_Enum.Enemy_Attack_Type.Skill_Attack:
                    // 캐릭터의 damaged 함수호출
                    collision.gameObject.GetComponent<PlayableCharacter>().BeAttacked
                        (parent_character.now_Skill_Info.P_skill_dmg, p, parent_character.cur_Groggy);
                    break;
            }

            if (/*my_Logic == Enemy_Enum.Enemy_Attack_Logic.Long_Attack ||*/
                my_Logic == Enemy_Enum.Enemy_Attack_Logic.Skill_Using)
            {
                if (parent_character.real_AI.now_State.GetComponent<State_Attack>() != null)
                {
                    State_Attack attack = parent_character.real_AI.now_State.GetComponent<State_Attack>();

                    attack.Attack_Result = true;
                    attack.Result_return_Object = this.gameObject;

                    collision.gameObject.GetComponent<PlayableCharacter>().BeAttacked
                       (parent_character.now_Skill_Info.P_skill_dmg, p, parent_character.cur_Groggy);
                }
            }

            if (my_Logic == Enemy_Enum.Enemy_Attack_Logic.Long_Attack)
            {
                GameMG.Instance.Resource.Destroy<GameObject>(this.gameObject);
                //Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Vector3 p = collider.ClosestPoint(collider.transform.position);

            switch (parent_character.attack_Type) // 공격 타입에 맞게 데미지를 입혀줌.
            {
                case Enemy_Enum.Enemy_Attack_Type.Normal_Attack:
                    collider.gameObject.GetComponent<PlayableCharacter>().BeAttacked(parent_character.mon_Info.P_mon_Atk, /*collider.transform.position*/p
                        , parent_character.cur_Groggy);
                    break;
                case Enemy_Enum.Enemy_Attack_Type.Skill_Attack:
                    // 캐릭터의 damaged 함수호출
                    collider.gameObject.GetComponent<PlayableCharacter>().BeAttacked
                        (parent_character.now_Skill_Info.P_skill_dmg, p, parent_character.cur_Groggy);
                    break;
            }

            if (/*my_Logic == Enemy_Enum.Enemy_Attack_Logic.Long_Attack ||*/
                my_Logic == Enemy_Enum.Enemy_Attack_Logic.Skill_Using)
            {
                if (parent_character.real_AI.now_State.GetComponent<State_Attack>() != null)
                {
                    State_Attack attack = parent_character.real_AI.now_State.GetComponent<State_Attack>();

                    attack.Attack_Result = true;
                    attack.Result_return_Object = this.gameObject;

                    collider.gameObject.GetComponent<PlayableCharacter>().BeAttacked
                       (parent_character.now_Skill_Info.P_skill_dmg, p, parent_character.cur_Groggy);
                }
            }

            if (my_Logic == Enemy_Enum.Enemy_Attack_Logic.Long_Attack)
            {
                GameMG.Instance.Resource.Destroy<GameObject>(this.gameObject);
                //Destroy(this.gameObject);
            }
        }
    }

    void Update()
    {

    }
}
