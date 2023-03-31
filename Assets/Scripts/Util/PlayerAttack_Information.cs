using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttack Data", menuName = "Scriptable Object/PlayerAttack Data", order = int.MaxValue)]

public class PlayerAttack_Information : ScriptableObject
{
    [SerializeField]
    private int AttackNum;
    public int P_AttackNum { get { return AttackNum; } set { AttackNum = value; } }
    [SerializeField]
    //�ִϸ��̼� ���
    private float animationPlaySpeed;
    public float P_animationPlaySpeed { get { return animationPlaySpeed; } set { animationPlaySpeed = value; } }

    [SerializeField]
    //�ش� �Ŵϸ��̼� Ŭ��
    private AnimationClip aniclip;
    public AnimationClip P_aniclip { get { return aniclip; } set { aniclip = value; } }

    [SerializeField]
    //�ĵ�����
    private float MovementDelay;
    public float P_MovementDelay { get { return MovementDelay; } set { MovementDelay = value; } }
    [SerializeField]
    //������������ �Ѿ�� ���� �ð�
    //�ش絿���� ������ �ش� �ð� �ȿ� Attack()�Լ��� ȣ��Ǿ���� ������������ �Ѿ��.
    private float NextMovementTimeVal;
    public float P_NextMovementTimeVal { get { return NextMovementTimeVal; } set { NextMovementTimeVal = value; } }

    [SerializeField]
    private float damage;
    public float P_damage { get { return damage; } set { damage = value; } }

    [SerializeField]
    private float EffectStartTime;
    public float P_EffectStartTime { get { return EffectStartTime; } set { EffectStartTime = value; } }

    [SerializeField]
    private GameObject Effect;
    public GameObject P_Effect { get { return Effect; } set { Effect = value; } }

    [SerializeField]
    private Transform EffectPosRot;
    public Transform P_EffectPosRot { get { return EffectPosRot; } set { EffectPosRot = value; } }

    [SerializeField]
    private float movedis;
    public float P_movedis { get { return movedis; } set { movedis = value; } }

    [SerializeField]
    private float movetime;
    public float P_movetime { get { return movetime; } set { movetime = value; } }
}
