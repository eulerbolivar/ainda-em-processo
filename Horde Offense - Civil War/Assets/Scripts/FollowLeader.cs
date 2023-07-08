using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLeader : MonoBehaviour
{
    private Transform targetFollowed;
    public float followSpeed = 9f;
    public float stoppingDistance = 2f;

    public void StartFollowing(Transform targetPlayer)
    {
        targetFollowed = targetPlayer;
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