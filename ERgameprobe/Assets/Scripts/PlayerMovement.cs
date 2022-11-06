using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 dir;
    [SerializeField] private float speedOfPlayer;
    [SerializeField] private float JumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject pauseBtn;
    [SerializeField] private int coins = 0;
    [SerializeField] private Text coinsDisplayText;
    // *** //
    private int MoveBand = 1; // Текущая часть дороги
    public float BandWidth = 4.0f; // Ширина дороги
    [SerializeField] private float maxSpeed = 35;


    // Start is called before the first frame update
    void Start()
    {
        pauseBtn.SetActive(true);
        controller = GetComponent<CharacterController>();
        Time.timeScale = 1;
        StartCoroutine(SpeedIncrease());
    }

    // Update is called once per frame
    private void Update() 
    {
        // Определяем передвижение по полосам
        if (Swipes.swipeRight)
        {
            if (MoveBand < 2)
                MoveBand++;
        } else if (Swipes.swipeLeft)
        {
            if (MoveBand > 0)
                MoveBand--;
        }

        // определение целевого местоположения
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (MoveBand == 0)
            targetPosition += Vector3.left * BandWidth;
        else if (MoveBand == 2)
            targetPosition += Vector3.right * BandWidth;

        if (Swipes.swipeUp)
        {
            if (controller.isGrounded)
            Jump();
        }

        if (transform.position == targetPosition)
        {
            return;
        }

        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;

        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            controller.Move(moveDir);
        }
        else
        {
            controller.Move(diff);
        }

    }

    private void Jump()
    {
        dir.y = JumpForce;
    }

    void FixedUpdate()
    {
        dir.z = speedOfPlayer;
        dir.y += gravity * Time.fixedDeltaTime; 
        controller.Move(dir * Time.fixedDeltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if (hit.gameObject.tag == "obstacle") 
        {
            Time.timeScale = 0;
            losePanel.SetActive(true);
            pauseBtn.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "coin")
        {
            coins++;
            coinsDisplayText.text = "Coins: " + coins.ToString();
            Destroy(other.gameObject);
        }    
    }

    // ускорение игрока
    // запускаем функцию каждые 3 секунды
    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(3);
        if (speedOfPlayer < maxSpeed )
        {
            speedOfPlayer += 5;
            StartCoroutine(SpeedIncrease());
        }
    }

}
