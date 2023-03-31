using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// 스테이트 처리기 함수
public abstract class State_Handler : MonoBehaviour
{
    public _State state;

    [SerializeField]
    protected Battle_Character battle_Character;

    public NavMeshAgent navMesh;

    [SerializeField]
    protected Animator anim;

    public abstract void State_Handler_Update();

    public virtual void State_Handler_Initialize(Battle_Character b_c) // 스테이트 처리기 초기화 함수
    {
        battle_Character = b_c;

        navMesh = battle_Character?.GetComponent<NavMeshAgent>();
        anim = battle_Character.GetComponent<Animator>();

        StartCoroutine(Mana_Regen());
    }

    protected abstract void Patrol_Enter_Process();

    protected abstract void Patrol_Process();

    protected abstract void Patrol_Exit_Process();

    protected abstract void Trace_Process();

    protected abstract void Attack_Process();

    protected abstract void Die_Process();

    protected abstract void Return_Process();

    protected IEnumerator patrol_Think_Coroutine()  // 다음 목적지 생각하는 코루틴
    {
        yield return new WaitForSeconds(1f);

        int randX = Random.Range(-10, 10);
        int randZ = Random.Range(-10, 10);

        battle_Character.destination_Pos = new Vector3(battle_Character.return_Pos.x + randX, battle_Character.return_Pos.y, battle_Character.return_Pos.z + randZ);

        battle_Character.patrol_Start = false;
    }

    protected bool Destination_Move(Vector3 in_destination_Pos)
    {
        if (!navMesh.enabled)
            return false;

        navMesh.SetDestination(in_destination_Pos);

        Vector3 charPos = new Vector3(battle_Character.transform.position.x, 0, battle_Character.transform.position.z);
        Vector3 desPos = new Vector3(in_destination_Pos.x, 0, in_destination_Pos.z);

        if (Vector3.Distance(charPos, desPos) <= 0.5f)
        {
            navMesh.velocity = Vector3.zero;
            //if (cur_State == 4)
            //    anim.SetBool("isReturn", false);
            //else
            //  anim.SetBool("isWalk", false);
            return true;
        }
        else
        {
            //if (cur_State == 4)
            //    anim.SetBool("isReturn", true);
            //else
            //    anim.SetBool("isWalk", true);

            //battle_Character.transform.LookAt(in_destination_Pos);
            return false;
        }
    }

    protected virtual IEnumerator Mana_Regen() // 마나 재생 함수. virtual 이므로 몬스터에 따라 마나 획득량 다르게 할 수도 있음. 아직은 몬스터별 마나 획득량 모르니까 통일
    {
        yield return new WaitForSeconds(1f);

       // battle_Character.Player_Mana += 5; // 몬스터 마나 재생량을 더해주면 될듯.

        StartCoroutine(Mana_Regen());
    }

    protected void Enemy_Skill_Rand()
    {
        battle_Character.next_Skill = Random.Range(1, 3); // 스킬 범위를 데이터를 받아와서 가진 스킬 수 만큼 중에 랜덤으로 나오게
        //battle_Character.Player_Mana = 0;
    }

}
