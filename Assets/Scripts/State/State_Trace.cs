using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy_Enum;

public class State_Trace : State
{
    int Longest_range;

    public string[] special_Range = new string[2];


    public override bool Judge(out State _State, Battle_Character battle_character)
    {
        // 너무 가까우면 뒤로 점프하기 위함
        if ((Vector3.Distance(battle_character.transform.position,
                battle_character.cur_Target.transform.position) <= 1.0f) && battle_character.is_Backword)
        {
            _State = Trans_List[0];
            battle_character.real_AI.pre_State = this;
            return false;
        }

        // 근접 공격 사거리 체크
        if (Trans_List[1] != null) // Round 상태가 있는 경우
        {
            if ((Vector3.Distance(battle_character.transform.position,
                    battle_character.cur_Target.transform.position) <= 5f/*battle_character.mon_Info.P_mon_CloseAtk*/)
                    /*&& battle_character.normal_CoolTime.isCheck*/)
            {
                _State = Trans_List[1]; // state_round로 이동
                Trans_List[1].State_Initialize(battle_character);
                battle_character.real_AI.pre_State = this;
                return false;
            }
        }
        else
        {
            if ((Vector3.Distance(battle_character.transform.position,
                    battle_character.cur_Target.transform.position) <= battle_character.mon_Info.P_mon_CloseAtk)
                    && battle_character.real_Normal_CoolTime.isCheck)
            {
                _State = Trans_List[0]; // state_Attack 로 이동
                battle_character.real_AI.pre_State = this;
                return false;
            }
        }

        // 스킬 공격
        if (int.Parse(special_Range[0]) != 0)
        {
            if ((Vector3.Distance(battle_character.transform.position,
                     battle_character.cur_Target.transform.position) <= int.Parse(special_Range[1]))
                     &&
                     (Vector3.Distance(battle_character.transform.position,
                     battle_character.cur_Target.transform.position) >= int.Parse(special_Range[0]))
                    && battle_character.skill_CoolTime.isCheck
                    && battle_character.delay_CoolTime.isCheck) // 타겟을 공격할 수 있는 사거리 내 진입했다면
            {
                _State = Trans_List[0];
                battle_character.real_AI.pre_State = this;
                return false;
            }
        }
        // 아래 부분들이 다 필요없고 최종 사거리만 계산해서 최종 사거리안에 진입했다면 Attack 스테이트로 돌리면 될듯
        // 변수 추가 받은 후 수정
        // 원거리 공격
        if (battle_character.mon_Info.P_mon_FarAtk != 0 && (Vector3.Distance(battle_character.transform.position,
              battle_character.cur_Target.transform.position) >= battle_character.mon_Info.P_mon_FarAtk) &&
              battle_character.long_CoolTime.isCheck
              && battle_character.delay_CoolTime.isCheck) // 타겟을 공격할 수 있는 사거리 내 진입했다면
        {
            _State = Trans_List[0]; //
            battle_character.real_AI.pre_State = this;
            return false;
        }

        _State = this;
        return true;
    }

    public int Longest_Range_Find(Battle_Character battle_character)
    {
        List<int> judge_List = new List<int>();

        int short_range = battle_character.mon_Info.P_mon_CloseAtk;
        int long_range = battle_character.mon_Info.P_mon_FarAtk;
        int max = -1;
        string[] special_ranges = battle_character.mon_Info.P_mon_SpecialAtk.Split(",");

        judge_List.Add(short_range);
        judge_List.Add(long_range);
        judge_List.Add(int.Parse(special_ranges[1]));

        foreach (int n in judge_List)
        {
            if (n >= max)
                max = n;
        }

        return max;
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

        if (!fflag)
            battle_character.animator.Play("Idle");

        if (battle_character.real_AI.navMesh.enabled)
            battle_character.real_AI.navMesh.SetDestination(battle_character.cur_Target.transform.position);
    }

    public override void State_Initialize(Battle_Character battle_character)
    {
        special_Range = battle_character.mon_Info.P_mon_SpecialAtk.Split(",");
    }
}
