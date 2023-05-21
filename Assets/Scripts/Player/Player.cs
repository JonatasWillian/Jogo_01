using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using Cloth;

public class Player : Singleton<Player>//, IDamageable
{
    public List<Collider> colliders;
    public Animator animator;
    public CharacterController characterController;

    [Header("Status Player")]
    public float speed = 1f;
    public float turnSpeed = 1f;
    public float gravit = -9.8f;
    public float jumpSpeed = 15f;

    [Header("Run Setup")]
    public KeyCode keyRun = KeyCode.LeftShift;
    public float speedRun = 1.5f;

    private float vSpeed = 0;

    [Header("Flash")]
    public List<FlashColor> flashColors;

    [Header("Life")]
    public HealthBase healthBase;
    public UIFillUpdater uiGunUpdater;
    public float reviveDuration = 3f;

    [Header("Boss")]
    private GameObject boss;
    private bool gameObjectBoss = false;

    [Header("UI")]
    public GameObject text;

    [Space]
    [SerializeField] private ClothChanger _clothChanger;

    private Coroutine checkLifePack = null;

    private bool _alive = true;

    private void Start()
    {
        StartCoroutine(CheckLifePackCoroutine());
    }


    IEnumerator CheckLifePackCoroutine()
    {
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);

        yield return new WaitForSeconds(.5f);
        text.gameObject.SetActive(false);

        checkLifePack = null;
    }

    private void OnValidate()
    {
        if (healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    protected override void Awake()
    {
        base.Awake();
        OnValidate();

        healthBase.OnDamage += Damage;
        healthBase.OnKill += OnKill;
    }

    #region LIFE
    private void OnKill(HealthBase h)
    {
        if (_alive)
        {
            _alive = false;
            animator.SetTrigger("Death");
            colliders.ForEach(i => i.enabled = false);

            Invoke(nameof(Revive), reviveDuration);
        }
    }

    private void Revive()
    {
        _alive = true;
        healthBase.ResetLife();
        animator.SetTrigger("Revive");
        Respown();
        Invoke(nameof(TurnOnColliders), .1f);
    }

    private void TurnOnColliders()
    {
        colliders.ForEach(i => i.enabled = true);
    }

    public void Damage(HealthBase h)
    {
        flashColors.ForEach(i => i.Flash());
        //EfectsManager.Instance.ChangeVignette();
        //ShakeCamera.Instance.Shake();
    }

    public void Damage(float damage, Vector3 dir)
    {
        //Damage(damage);
    }
    #endregion

    private void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        var inputAxisVertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * inputAxisVertical * speed;

        if (characterController.isGrounded)
        {
            vSpeed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                vSpeed = jumpSpeed;
            }
        }

        var isWalking = inputAxisVertical != 0;

        if (isWalking)
        {
            if (Input.GetKey(keyRun))
            {
                speedVector *= speedRun;
                animator.speed = speedRun;
            }
            else
            {
                animator.speed = 1;
            }
        }

        vSpeed -= gravit * Time.deltaTime;
        speedVector.y = vSpeed;

        characterController.Move(speedVector * Time.deltaTime);

        animator.SetBool("Run", isWalking);
    }

    [NaughtyAttributes.Button]
    public void Respown()
    {
        if (CheckPointManager.Instance.HasCheckPoint())
        {
            transform.position = CheckPointManager.Instance.GetPosition();
        }
    }

    public void ChangeSpeed(float speed, float duration)
    {
        StartCoroutine(ChangeSpeedCoroutine(speed, duration));
    }

    IEnumerator ChangeSpeedCoroutine(float localSpeed, float duration)
    {
        var defaultSpeed = speed;
        speed = localSpeed;
        yield return new WaitForSeconds(duration);
        speed = defaultSpeed;
    }

    public void ChangeTexture(ClothSetup setup)
    {
        _clothChanger.ChangeTexture(setup);
        //StartCoroutine(ChangeTextureCoroutine(setup, duration));
    }

    IEnumerator ChangeTextureCoroutine(ClothSetup setup, float duration)
    {
        _clothChanger.ChangeTexture(setup);
        yield return new WaitForSeconds(duration);
        _clothChanger.ResetTexture();
    }
}
