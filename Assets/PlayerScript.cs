using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static bool startGame = false;
    public Rigidbody2D rb;
    public float jump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!startGame) { 
                startGame = true;
                rb.constraints = RigidbodyConstraints2D.None;
            }
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Floor") || collision.gameObject.tag.Equals("Wall"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            startGame = false;
        }

    }
}
