using UnityEngine;

public class InfiniteForward : MonoBehaviour
{
    public float velocity = 0.02F;
    private Transform transform;
    private float time = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerScript.startGame) return;
        time += Time.deltaTime;
        if (time < 0.016)
        {
            return;
        }
        time = 0;
        transform.SetPositionAndRotation(new Vector3(transform.position.x - velocity, transform.position.y, transform.position.z), transform.rotation);
    }
}
