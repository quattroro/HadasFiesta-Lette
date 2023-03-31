using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEventDamage : MonoBehaviour
{
    public float damage;


    public void DamageSetting(float m_damage)
    {
        damage = m_damage;
    }

    // 어떤 공격시 생성될 이펙트가 가지고 있을 스크립트
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 데미지 적용
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("ColliderEventDamage : " + other.name);

        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Battle_Character>().Damaged(Convert.ToInt32(damage), this.transform.position);

            Debug.Log("적군 공격");
        }
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        collision.gameObject.GetComponent<Battle_Character>().Damaged(Convert.ToInt32(damage), collision.contacts[0].point);

    //        Debug.Log("적군 공격");
    //    }
    //}
}
