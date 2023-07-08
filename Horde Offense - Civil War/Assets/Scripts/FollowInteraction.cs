using UnityEngine;

public class FollowInteraction : MonoBehaviour
{
    public float interactionDistance = 2f;

    void Update()
    {
        memberInteraction();
    }

    void memberInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, interactionDistance);
            foreach (Collider collider in nearbyColliders)
            {
                if (collider.CompareTag("Member"))
                {
                    
                    FollowLeader followLeader = collider.GetComponent<FollowLeader>();
                    if (followLeader != null)
                    {
                        followLeader.StartFollowing(transform);
                    }
                }
            }
        }
    }
}
