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
                    Debug.Log("Personagem principal interagiu com: " + collider.gameObject.name);
                    
                    FollowLeader followLeader = collider.GetComponent<FollowLeader>();
                    if (followLeader != null)
                    {
                        followLeader.StartFollowing(transform);
                    }
                    else
                    {
                        Debug.LogWarning("O objeto Member não possui o componente FollowBehavior anexado.");
                    }
                }
                if (collider.CompareTag("Enemy"))
                {
                    Debug.Log("Personagem principal interagiu com: " + collider.gameObject.name);
                }
                
            }
        }
    }
}
