using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public GameObject Defeat;
    public float timeLeft = 12.0f;
    public float speed;
    private int Count;
    private int Timer;
    public Text winText;
    public Text countText;
    public Text loseText;
    public Text TimerText;
    public AudioSource musicSource;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioClip musicClipThree;
    private bool facingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        musicSource.clip = musicClipOne;
        Count = 0;
        winText.text = "";
        loseText.text = "";
        SetCountText();
        musicSource.PlayDelayed(2);
        timeLeft = 12.0f;
    }

    // Update is called once per frame
    void Update()
    {
        {
            float hozMovement = Input.GetAxis("Horizontal");
            float vertMovement = Input.GetAxis("Vertical");
            rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
            if (facingRight == false && hozMovement > 0)
            {
                Flip();
            }
            else if (facingRight == true && hozMovement < 0)
            {
                Flip();
            }

        }
        if (timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
            TimerText.text = (timeLeft).ToString("0");
        }
        if (timeLeft <= 0 && Count < 7)
        {
            loseText.text = "Times up, \n Press ESC to close and restart";
            rd2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickups"))
        {
            musicSource.PlayOneShot(musicClipThree);
            Count = Count += 1;
            SetCountText();
            other.gameObject.SetActive(false);
        }

    }
    void SetCountText()
    {
        countText.text = "Acorns: " + Count.ToString();

        if (Count >= 7)
        {
            musicSource.Stop();
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            winText.text = "Victory, \n Press ESC to close and restart";
            rd2d.constraints = RigidbodyConstraints2D.FreezeAll;
            Destroy(Defeat, 0);
        }

    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
}
