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
    public TextMeshPro PopupTextPrefab;


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

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                // 터치된 위치를 Ray로 변환
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // 터치된 오브젝트가 이 오브젝트니 ?
                    if (hit.transform == transform)
                    {
                        PerformAction();
                    }
                }
            }

        }
    }

    private void PerformAction()
    {

        SoundManager.Instance.PlaySoundPop();


        // particle 
        ParticleSystem particle = Instantiate(ExplosionParticle, transform.position, transform.rotation);
        ParticleSystem.MainModule mainModule = particle.main;
        Color particleStartColor = mainModule.startColor.color;

        GameManager.Instance.UpdateScore(Point);

        if (gameObject.CompareTag("Bad"))
        {
            GameManager.Instance.LoseLife();
        }

        // popup point text
        SetPointPopupText(particleStartColor);

        // play sound
        SoundManager.Instance.PlaySoundPop();
        Destroy(gameObject);
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
        PerformAction();

    }

    private void SetPointPopupText(Color particleStartColor)
    {
        // popup text (Quaternion.identity: 특별한 회전이 필요 없을 때)
        TextMeshPro popupText = Instantiate(PopupTextPrefab, transform.position, Quaternion.identity);
        popupText.color = particleStartColor;

        if (gameObject.CompareTag("Bad"))
        {
            popupText.color = Color.red;
        }
        //point가 0보다 크면 "+" 를 붙인다. 
        popupText.text = (Point > 0) ? $"+{Point}" : Point.ToString();
    }
}
