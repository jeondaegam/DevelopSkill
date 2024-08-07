using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    // Point
    // Particle
    // Rigidbody

    // referencing
    public int Point;
    public ParticleSystem ExplosionParticle;
    public TextMeshPro PopupDamagePrefab;


    // private
    private Rigidbody TargetRB;
    private float MaxTorque = 10f;
    private float MinSpeed = 9f;
    private float MaxSpeed = 14f;

    private float XPosRange = 4f;
    private float YPosition = -6f;

    void Start()
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
        return new Vector3(Random.Range(-XPosRange, XPosRange), YPosition);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(MinSpeed, MaxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-MaxTorque, MaxTorque);
    }

    // 클릭 이벤트
    private void OnMouseDown()
    {
        // particle 
        Instantiate(ExplosionParticle, transform.position, transform.rotation);
        GameManager.Instance.UpdateScore(Point);
        Destroy(gameObject);

        // point popup
        SetPointPopupText();
    }

    private void SetPointPopupText()
    {
        // popup text (Quaternion.identity: 특별한 회전이 필요 없을 때)
        TextMeshPro popupText = Instantiate(PopupDamagePrefab, transform.position, Quaternion.identity);

        if (gameObject.CompareTag("Bad"))
        {
            popupText.color = Color.red;
        }
        //point가 0보다 크면 "+" 를 붙인다. 
        popupText.text = (Point > 0) ? $"+{Point}" : Point.ToString();
    }
}
