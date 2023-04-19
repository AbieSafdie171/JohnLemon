using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;

    public Rigidbody PetSphere;

    public GameObject s;

    Color offColor = Color.blue;

    Color onColor = Color.red;

    Color lerpedColor;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    Vector3 offset = new Vector3(-0.8f, 0f, 0f);

    Vector3 endPosition = new Vector3(18f, 0f, 2f);


    void Start ()
    {
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
        m_AudioSource = GetComponent<AudioSource> ();



    }

    void FixedUpdate ()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("IsWalking", isWalking);
        
        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop ();
        }

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);


        
        PetSphere.position = m_Rigidbody.position + offset;

    }

    void OnAnimatorMove ()
    {
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation (m_Rotation);
    }

    void Update(){
        
        /*
        Vector3 from = new Vector3 (1f, 2f, 3f);
        Vector3 to = new Vector3 (5f, 6f, 7f);

        Vector3 result = Vector3.Lerp (from, to, 0.75f);

        Debug.Log(result);
        */
        var sRend = s.GetComponent<Renderer>();

        // 18, 0, 2

        float p = Math.Abs((m_Rigidbody.position.z + m_Rigidbody.position.x) / (endPosition.z + endPosition.x));

        Debug.Log(p);

        lerpedColor = Color.Lerp(offColor, onColor, p);

        sRend.material.SetColor("_Color", lerpedColor);

        
    }
}