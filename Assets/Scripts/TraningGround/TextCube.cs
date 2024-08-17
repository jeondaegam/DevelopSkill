using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextCube : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro tmp1, tmp2, tmp3;

    [SerializeField]
    private Material[] CubeMaterials;

    // private
    private Rigidbody TargetRB;
    private float MaxTorque = 10f;
    private float MinTorque = 8f;

    private float YMinSpeed = 10f;
    private float YMaxSpeed = 20;

    private float XDirection = 5f; // 날아가는 방향: x값이 -5 ~ +5 사이의 방향으로 날아가게 한다  

    [SerializeField]
    private float XPosRange = 1.5f; // 생성 위치: x값의 범위
    private float ZPosition = 1f;

    public void SetText(string inputStr)
    {
        tmp1.text = inputStr;
        tmp2.text = inputStr;
        tmp3.text = inputStr;
    }

    private void Start()
    {
        //TrainingRoomSoundManager.Instance.PlayCollide();
        TargetRB = gameObject.GetComponent<Rigidbody>();
        Renderer cubeRenderer = GetComponent<MeshRenderer>();

        int randomMaterial = Random.Range(0, CubeMaterials.Length);
        cubeRenderer.material = CubeMaterials[randomMaterial];


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
        // X값 speed를 5~10으로 설정하니까, 오른쪽으로만 날아감 ,
        // 왼쪽으로도 날아가게 하려면 음수도 포함해야하나봄 
        float randomX = Random.Range(-XDirection, XDirection);
        float randomY = Random.Range(YMinSpeed, YMaxSpeed);
        return new Vector3(randomX, randomY, 1);
    }

    private float RandomTorque()
    {
        return Random.Range(MinTorque, MaxTorque);
    }

}

