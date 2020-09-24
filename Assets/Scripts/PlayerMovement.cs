using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Text commandsUI;

    public float forwardForce = 2000f;
    public float sideForce = 500f;
    public float milestoneScore;


    public delegate void MilestoneReached();
    public static event MilestoneReached OnMilestone;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            Command moveRight = new MoveRight(rb, sideForce);
            Invoker invoker = new Invoker();
            invoker.SetCommand(moveRight);
            commandsUI.text += "\n" + moveRight.ToString();
            invoker.ExecuteCommand();
        }

        if (Input.GetKey("a"))
        {
            Command moveLeft = new MoveLeft(rb, sideForce);
            Invoker invoker = new Invoker();
            invoker.SetCommand(moveLeft);
            commandsUI.text += "\n" + moveLeft.ToString();
            invoker.ExecuteCommand();
        }

        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame(null);
        }

        if(rb.GetComponentInParent<Transform>().position.z > milestoneScore)
        {
            OnMilestone?.Invoke();
        }
    }
}
