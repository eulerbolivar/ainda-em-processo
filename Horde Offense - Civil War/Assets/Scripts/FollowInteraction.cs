using UnityEngine;

public class FollowInteraction : MonoBehaviour
{
    public float interactionDistance = 2f;
    public GameObject memberPrefab;
    private Transform playerTransform;
    private Transform lastMemberInteracted;
    private float distanceBetweenMembers = 2f;

    void Start()
    {
        playerTransform = transform;
    }

    void Update()
    {
        memberInteraction();
    }

    void memberInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] nearbyColliders = Physics.OverlapSphere(playerTransform.position, interactionDistance);
            foreach (Collider collider in nearbyColliders)
            {
                if (collider.CompareTag("Member"))
                {
                    //collider.tag = "Unido";
                    Destroy(collider.gameObject);
                    GameObject memberObject = Instantiate(memberPrefab, playerTransform.position, Quaternion.identity);
                    memberObject.tag = "Unido";
                    FollowLeader followLeader = memberObject.GetComponent<FollowLeader>();
                    if (followLeader != null)
                    {
                        if (lastMemberInteracted != null)
                        {
                            followLeader.StartFollowing(lastMemberInteracted, distanceBetweenMembers);
                        }
                        else
                        {
                            followLeader.StartFollowing(playerTransform, 0f);
                        }

                        lastMemberInteracted = memberObject.transform;
                        distanceBetweenMembers += 2f;
                    }
                }
            }
        }
    }
}