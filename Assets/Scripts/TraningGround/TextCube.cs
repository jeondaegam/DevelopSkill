using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextCube : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro tmp;

    // private
    private Rigidbody TargetRB;
    private float MaxTorque = 10f;
    private float MinTorque = 8f;

    private float MinSpeed = 10f;
    private float MaxSpeed = 20;

    private float XPosRange = 2f;
    private float ZPosition = 1f;

    public void SetText(string str)
    {
        tmp.text = str;
    }

    private void Start()
    {
        TargetRB = gameObject.GetComponent<Rigidbody>();

        // 회전
        TargetRB.AddTorque(RandomTorque()
            , RandomTorque()
            , RandomTorque()
            , ForceMode.Impulse);

        // 위로 상승 : 점프력을 다이나믹하게 주기 위해 랜덤값을 곱해준다 
        TargetRB.AddForce(RandomForce(), ForceMode.Impulse);

        // 포지션
        transform.position = RandomPosition();
    }


    // X, Y 값을 가지는 Vector3 리턴
    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-XPosRange, XPosRange), 0, ZPosition);
    }

    private Vector3 RandomForce()
    {
        float randomX = Random.Range(-MaxSpeed, MaxSpeed);
        float randomY = Random.Range(MinSpeed, MaxSpeed);
        //return Vector3.forward * Random.Range(MinSpeed, MaxSpeed);
        //return Vector3.up * Random.Range(MinSpeed, MaxSpeed);
        return new Vector3(randomX, randomY, 1);
    }

    private float RandomTorque()
    {
        return Random.Range(MinTorque, MaxTorque);
    }

}

