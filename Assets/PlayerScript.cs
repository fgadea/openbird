using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{
    public static bool startGame = false;
    public GameObject gameOverUI;
    public Rigidbody2D rb;
    public float jump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Set screen size for Standalone
#if UNITY_STANDALONE
        Screen.SetResolution(564, 960, false);
#endif
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        CheckUserSpriteRotation();
        ProcessUserInput();
    }

    public void RestartGame()
    {
        gameOverUI.SetActive(false);
        transform.position = Vector3.zero;
        var walls = FindObjectsByType<InfiniteForward>(FindObjectsSortMode.None);
        foreach (var wall in walls) {
            Destroy(wall.gameObject);
        }
    }

    private void ProcessUserInput()
    {
        if (!Input.GetKeyDown(KeyCode.Space) && Input.touchCount == 0 && !Input.GetMouseButtonDown(0)) return;
        if (gameOverUI.activeSelf) {
            RestartGame();
            return; 
        }
        if (!startGame)
        {
            startGame = true;
            rb.constraints = RigidbodyConstraints2D.None;
        }
        rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        RotatesUpPlayer();
    }

    private void CheckUserSpriteRotation()
    {
        var velocity = rb.velocity;
        if (velocity == Vector2.zero) return;

        if (velocity.y < 0)  RotatesDownPlayer();
        else RotatesUpPlayer();
    }

    private void RotatesDownPlayer()
    {
        Vector3 rotation = transform.eulerAngles;
        if (rotation.z == -10) return;
        rotation.z = -10;
        transform.eulerAngles = rotation;
    }

    private void RotatesUpPlayer()
    {
        Vector3 rotation = transform.eulerAngles;
        if (rotation.z == 10) return;
        rotation.z = 10;
        transform.eulerAngles = rotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Floor") || collision.gameObject.tag.Equals("Wall"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            startGame = false;
            gameOverUI.SetActive(true);
        }

    }
}
