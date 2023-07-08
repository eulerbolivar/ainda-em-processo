using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{

    enum Direction
    {
        Left,
        Right,
        Up,
        Down,
        Forward
    }

    [Header("Movement")]

    [SerializeField] Direction startDir;

    [SerializeField] float speed;

    [SerializeField] bool canChangeOnPos1, canChangeOnPos2;

    [SerializeField] float closeDistance;

    [SerializeField] Transform pos1, pos2;

    [SerializeField] Transform childObject;

    Vector3 finalDir;

    [Header("Materials")]

    [SerializeField] private List<MeshRenderer> meshChanges = new List<MeshRenderer>();

    [SerializeField] private List<Material> materials = new List<Material>();

    private Movement collidedPlayer;

    private int materialCounter = 0;

    void Start()
    {
        canChangeOnPos1 = true;
        canChangeOnPos2 = true;

        changeMaterial();

        switch (startDir)
        {
            case Direction.Left:
                finalDir = Vector3.left;
                break;
            case Direction.Right:
                finalDir = Vector3.right;
                break;
            case Direction.Up:
                finalDir = Vector3.up;
                break;
            case Direction.Down:
                finalDir = Vector3.down;
                break;
            case Direction.Forward:
                finalDir = Vector3.forward;
                break;
            default:
                finalDir = Vector3.right;
                break;
        }
    }


    void Update()
    {
        childObject.position += finalDir * speed * Time.deltaTime;

        if (collidedPlayer != null)
        {
            //collidedPlayer.addVelocity(finalDir * speed);
        }

        if (Vector3.Distance(childObject.position, pos2.position) <= closeDistance)
        {
            if (canChangeOnPos2)
            {
                changeDirection();
                changeMaterial();
                canChangeOnPos2 = false;
            }

        }
        else
        {
            canChangeOnPos2 = true;
        }

        if (Vector3.Distance(childObject.position, pos1.position) <= closeDistance)
        {
            if (canChangeOnPos1)
            {
                changeDirection();
                changeMaterial();
                canChangeOnPos1 = false;
            }
        }
        else
        {
            canChangeOnPos1 = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Movement player = other.gameObject.GetComponent<Movement>();

        if (player != null)
        {
            collidedPlayer = player;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Movement player = other.gameObject.GetComponent<Movement>();

        if (player != null)
        {
           // player.addVelocity(Vector3.zero);
            collidedPlayer = null;
        }
    }

    private void changeDirection()
    {
        finalDir *= -1;
    }

    private void changeMaterial()
    {
        materialCounter++;

        if (materialCounter >= materials.Count)
            materialCounter = 0;

        for (int i = 0; i < meshChanges.Count; i++)
        {
            meshChanges[i].material = materials[materialCounter];
        }
    }
}