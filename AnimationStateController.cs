using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    int isWalkingHash;
    int isRunningHash;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("IsWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        // Retrieve current animator states
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);

        // Get user input
        bool forwardPress = Input.GetKey("w");
        bool runPress = Input.GetKey(KeyCode.LeftShift);

        // Walking logic
        if (!isWalking && forwardPress)
        {
            animator.SetBool(isWalkingHash, true);
        }
        else if (isWalking && !forwardPress)
        {
            animator.SetBool(isWalkingHash, false);
        }

        // Running logic
        if (!isRunning && forwardPress && runPress)
        {
            animator.SetBool(isRunningHash, true);
        }
        else if (isRunning && (!forwardPress || !runPress))
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}
