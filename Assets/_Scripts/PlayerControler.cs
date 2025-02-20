using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[RequireComponent(typeof(StateManager))]
public class PlayerControler : MonoBehaviour
{

    public Player_ScriptableObject Player_Data;
    [SerializeField] StateManager _stateManager;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteLibrary _asset;
    [SerializeField] _AudioManager _audio;
    [SerializeField] _SceneManager _scManager;
    //ForButton
    public bool _isWalkingLeft = false;
    public bool _isWalkingRight = false;
    public bool _isJumping = false;
    public bool _isTeleporting = false;
    public bool _isDead = false;
    //For moving
    [SerializeField] bool _isFacingRight = true;
    [SerializeField] float _jumpForce = 5f;
    [SerializeField] private bool _isGrounded = true;
    private Vector3 _velocity;
    private Vector3 _inputDirection;
    private float _acceleration = 1.5f;
    private float _maxSpeed = 5f;
    private float _delta;
    private float _countDownTime = 1f;
    private Rigidbody2D _rb;

    void Start()
    {
        _asset = GetComponent<SpriteLibrary>();
        _asset.spriteLibraryAsset = Player_Data._assets[Player_Data.indexOfSkin];
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _stateManager = this.GetComponent<StateManager>();
        _audio = _AudioManager.Instance;
    }
    void FixedUpdate()
    {
        Moving();
        Flip();
        StartCountDown();
        Jump();
    }
    //For moving, jump
    public void Moving()
    {
        //Add acceleration
        _inputDirection = Vector3.zero;
        if (_isWalkingLeft) { _delta = -1.0f; _inputDirection += Vector3.left; }
        else if (_isWalkingRight) { _delta = 1.0f; _inputDirection += Vector3.right; }
        else { _delta = 0f; }
        //Set vector
        Vector3 targetVelocity = _inputDirection.normalized * _maxSpeed;
        //Keep moving
        if (targetVelocity.magnitude > 0)
        {
            _velocity = Vector3.MoveTowards(_velocity, targetVelocity, _acceleration * 5 * Time.deltaTime);
            _stateManager.ChangeState(new RunState(_animator));
            transform.Translate(_velocity * Time.deltaTime);
            if (!_audio.SFXSourceForWalk.isPlaying)
                _audio.PlayWalkSound();
        }
        else
        {
            _velocity = Vector3.zero;
            _audio.StopWalkSound();
            _stateManager.ChangeState(new IdleState(_animator));
        }

    }
    private void Jump()
    {
        if (_isJumping && _isGrounded && _countDownTime == 0)
        {
            _stateManager.ChangeState(new JumpState(_animator));
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _countDownTime = 1f;
        }
    }
    private void Flip()
    {
        if (_isFacingRight && _delta < 0 || !_isFacingRight && _delta > 0)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 Oscale = transform.localScale;
            Oscale.x = Oscale.x * -1;
            transform.localScale = Oscale;
        }
    }
    private void StartCountDown()
    {
        if (_countDownTime > 0)
            _countDownTime -= Time.deltaTime;
        if (_countDownTime < 0)
            _countDownTime = 0;
    }
    //Method of buttons
    public void IsTriggerLeft(bool isActive)
    {
        _isWalkingLeft = isActive;
    }
    public void IsTriggerRight(bool isActive)
    {
        _isWalkingRight = isActive;
    }
    public void IsTriggerJump(bool isActive)
    {
        _isJumping = isActive;
    }
    public void IsTriggerTeleport(bool isActive)
    {
        _isTeleporting = isActive;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TriggerDialogue"))
        {
            _isWalkingLeft
                = _isWalkingRight
                = _isJumping
                = _isTeleporting = false;
        }
        if (collision.gameObject.CompareTag("Enermy"))
        {
            _stateManager.ChangeState(new DeadState(_animator));
        }
        if (collision.gameObject.CompareTag("Portal"))
        {
            _scManager.SetActiveLoadOut();
        }
    }
    public void ReSpawn() => _stateManager.ChangeState(new IdleState(_animator));
    public void ReLoading()
    {
        if (_isDead) return;
        _scManager.ReloadingSceneWhenDie();
        _isDead = true;
    }
}
