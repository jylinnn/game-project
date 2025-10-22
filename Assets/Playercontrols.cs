using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;
public class Playercontrols : MonoBehaviour
{
    private int score;
    private Rigidbody hitbox;
    public TMP_Text scoreText;


    public float XSpeed;
    public float YSpeed;
    public float ZSpeed;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
        hitbox = GetComponent<Rigidbody>();

        XSpeed = 0f;
        YSpeed = 0f;
        ZSpeed = 0f;
        speed = 0.1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        XSpeed += speed*moveHorizontal;
        ZSpeed += speed*moveVertical;

        XSpeed *= 0.6f;
        ZSpeed *= 0.6f;

        Vector3 movement = new Vector3(XSpeed+gameObject.transform.position.x, YSpeed+gameObject.transform.position.y, ZSpeed+gameObject.transform.position.z);
        hitbox.MovePosition(movement);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pick up"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
