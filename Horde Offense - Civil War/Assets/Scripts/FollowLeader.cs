using UnityEngine;

public class FollowLeader : MonoBehaviour
{
    private Transform targetFollowed;
    [SerializeField] private float followSpeed = 12f;
    private float stoppingDistance = 2f;

    public void StartFollowing(Transform targetPlayer, float distanceOffset)
    {
        targetFollowed = targetPlayer;
        Vector3 offset = new Vector3(0f, 0f, -distanceOffset);
        transform.position = targetFollowed.position + offset;
    }

    private void Update()
    {
        followingRules();
    }

    void followingRules()
    {
        if (targetFollowed != null)
        {
            Vector3 direction = (targetFollowed.position - transform.position).normalized;
            float distanceBetweenPlayer = Vector3.Distance(transform.position, targetFollowed.position);

            if (distanceBetweenPlayer > stoppingDistance)
            {
                transform.position += direction * followSpeed * Time.deltaTime;
                transform.LookAt(targetFollowed);
            }
        }
    }
}