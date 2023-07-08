using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLeader : MonoBehaviour
{
    private Transform targetFollowed;
    private Transform nextInQueue;
    public float followSpeed = 9f;
    public float stoppingDistance = 2f;

    public void StartFollowing(Transform next)
    {
        targetFollowed = next;
        nextInQueue = null;
    }

    public void SetNextInQueue(Transform next)
    {
        nextInQueue = next;
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
            float distanceBetweenLeader = Vector3.Distance(transform.position, targetFollowed.position);

            if (distanceBetweenLeader > stoppingDistance)
            {
                transform.position += direction * followSpeed * Time.deltaTime;
                transform.LookAt(targetFollowed);
            }

            if (nextInQueue != null)
            {
                FollowLeader nextFollower = nextInQueue.GetComponent<FollowLeader>();
                if (nextFollower != null)
                {
                    nextFollower.StartFollowing(targetFollowed);
                }
            }
        }
    }
}