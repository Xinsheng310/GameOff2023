using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TestGameManager : MonoBehaviour
{
    public static TestGameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private                  Camera        camera;
    public                   PlayerManager player;
    public                   Trajectory    trajectory;
    [SerializeField] private float         pushForce = 0.2f;

    private bool isDragging = false;

    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 direction;
    private Vector2 force;
    private float   distance;
    
    private void Start()
    {
        camera = Camera.main;
        player.DeactivateRigidbody();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            OnDragStart();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            OnDragEnd();
        }

        if (isDragging)
        {
            OnDrag();
        }
    }

    private void OnDragStart()
    {
        player.DeactivateRigidbody();
        startPoint = camera.ScreenToWorldPoint(Input.mousePosition);
        
        trajectory.Show();
    }

    private void OnDragEnd()
    {
        player.ActivateRigidbody();
        player.Push(force);
        
        trajectory.Hide();
    }

    private void OnDrag()
    {
        endPoint  = camera.ScreenToWorldPoint(Input.mousePosition);
        distance  = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force     = direction * distance * pushForce;
        
        Debug.DrawLine(startPoint, endPoint);
        
        trajectory.UpdateDots(player.Pos, force);
    }
}
