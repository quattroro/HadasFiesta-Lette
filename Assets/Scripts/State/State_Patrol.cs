using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Patrol : State
{
    public override bool Judge(out State _State, Battle_Character battle_character)
    {
        // Collider[] cols = new Collider[10];
        Collider[] cols = Physics.OverlapSphere(battle_character.transform.position,
                          battle_character.mon_Target_Info.P_mon_Range);

        //, 1 << 8); // 비트 연산자로 8번째 레이어

        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].CompareTag("Player"))
                {
                    battle_character.cur_Target = cols[i].gameObject;
                    battle_character.real_AI.pre_State = this;
                    _State = Trans_List[0];
                    return false;
                }
            }
        }

        _State = this;
        return true;
    }

    public override void Run(Battle_Character battle_character)
    {
        bool fflag = false;
        foreach (AnimationClip clip in battle_character.animator.m_tempclips)
        {
            if (clip.name == "Walk")
            {
                fflag = true;
                battle_character.animator.Play("Walk");
                break;
            }
        }

        //if (!fflag)
        //    battle_character.animator.Play("Idle");
        // else
        //     battle_character.animator.Play("Idle");

        Vector3 charPos = new Vector3(battle_character.transform.position.x,
            0, battle_character.transform.position.z);
        Vector3 desPos = new Vector3(battle_character.destination_Pos.x
            , 0, battle_character.destination_Pos.z);

        if (Vector3.Distance(charPos, desPos) <= 1f)
        {
            if (!battle_character.patrol_Start)
            {
                StartCoroutine(patrol_Think_Coroutine(battle_character));
                battle_character.patrol_Start = true;
                //anim.SetBool("isWalk", false);
            }
        }
        else
        {
            battle_character.real_AI.navMesh.SetDestination(battle_character.destination_Pos);
           // battle_character.real_AI.navMesh.SetDestination(battle_character.transform.position);
        }
    }

    protected IEnumerator patrol_Think_Coroutine(Battle_Character battle_character)  // 다음 목적지 생각하는 코루틴
    {
        yield return new WaitForSeconds(1f);

        int randX = Random.Range(-5, 5);
        int randZ = Random.Range(-5, 5);

        battle_character.destination_Pos = new Vector3(battle_character.return_Pos.x + randX, battle_character.transform.position.y, battle_character.return_Pos.z + randZ);

        battle_character.patrol_Start = false;
    }
}
