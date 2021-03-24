using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    
    private Animator _animator;
    
    public ParticleSystem explosion, dirt;
    
    public AudioClip jumpSound, crashSound, deathSound;
    private AudioSource _audioSource;

    public Camera camera;
    
    public float jumpForce = 300f;
    private bool isOnGround = true;

    private const string RUNNING_ANIMATION = "Speed_f";
    private const string JUMP_TRIGGER = "Jump_trig";
    private const string JUMP_ANIMATION = "Death_b";
    private const string JUMP_TYPE = "DeathType_int";
    
    private bool _gameOver = false;
    

    public bool GameOver
    {
        get => _gameOver;
        
        //Poniendo el setter de esta forma es muy complicado que te cambien el valor a false,
        //ya que si es true siempre cambiará su valor a true
        // set
        // {
        //     if (_gameOver)
        //     {
        //         _gameOver = true;
        //     }
        //     else
        //     {
        //         _gameOver = value;
        //     }
        // }
    }

    void Start()
    {
        playerRB = GetComponent<Rigidbody>(); // Guarda el componente rb en una variable
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        
        _animator.SetFloat(RUNNING_ANIMATION, 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !_gameOver)
        {
            dirt.Stop();
            _audioSource.PlayOneShot(jumpSound);
            
            playerRB.AddForce(Vector3.up * jumpForce); //Añade una fuerza la eje x, para que el jugador salte
            _animator.SetTrigger(JUMP_TRIGGER);
            isOnGround = false;
            
        }
    }

    // Se activa cuando el jugador colisiona con cualquier objeto
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            dirt.Play();
            isOnGround = true;
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            Debug.Log("Game Over...");
            
            dirt.Stop();
            explosion.Play();
            camera.GetComponent<AudioSource>().Stop();

            _audioSource.PlayOneShot(crashSound);

            _animator.SetBool(JUMP_ANIMATION, true);
            _animator.SetInteger(JUMP_TYPE, Random.Range(1,3));
            
            _audioSource.PlayOneShot(deathSound, 0.3f);
        }
    }
}
