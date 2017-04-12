using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text timeText;
    public Text timerText;
    private float timeLimit = 40.0f;

    private Rigidbody rb;
    private int count;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 14)
        {
            winText.text = "You Win!";
        }
        
    }

    void Update()
    {
        // translate object for 10 seconds.
        if (timeLimit > 1)
        {
            // Decrease timeLimit.
            timeLimit -= Time.deltaTime;
            // translate backward.
            transform.Translate(Vector3.back * Time.deltaTime, Space.World);
            Debug.Log(timeLimit);
            timerText.text = "Time: " + timeLimit.ToString();
        }

        if (timeLimit <= 1.0f)
        {
            timeText.text = "GAME OVER!";
        }
    }

}
