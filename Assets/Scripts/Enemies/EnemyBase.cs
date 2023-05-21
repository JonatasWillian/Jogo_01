using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using Animation;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour, IDamageable
    {
        [Header("Collider")]
        public Collider collider;

        [Header("FlasColor")]
        public FlashColor flashColor;

        [Header("Particle")]
        public ParticleSystem particleSystem;

        [Header("Life/Look")]
        public float startLife = 10f;
        public bool lookAtPlayer = false;
        public float timeDeath = .2f;
        [SerializeField] private float _currentLife;

        [Header("Animation")]
        [SerializeField] private AnimationBase _animationBase;

        [Header("Start Animation")]
        public float startAnimationDuration = .2f;
        [Space]
        public Ease startAnimationEase = Ease.OutBack;
        public bool startWithBornAnimation = true;

        [Header("Events")]
        public UnityEvent OnKillEvent;
        public float timeEvent = 1;

        private Player _player;
        private EnemyWalk enemyWalk;

        public virtual void Awake()
        {
            Init();
        }

        private void Start()
        {
            _player = GameObject.FindObjectOfType<Player>();
            //EnemiesManager.Instance.RegisterEnemy(this);
        }

        protected void ResetLife()
        {
            _currentLife = startLife;
        }

        protected virtual void Init()
        {
            ResetLife();
            if(startWithBornAnimation)
                BornAnimation();
        }

        protected virtual void Kill()
        {
            OnKill();
        }

        protected virtual void OnKill()
        {
            if (collider != null) collider.enabled = false;
            PlayAnimationByTrigger(AnimationType.DEATH);
            StartCoroutine(DelayEventKill());
            EnemiesManager.Instance.EnemyDie(this);
        }

        IEnumerator DelayEventKill()
        {
            yield return new WaitForSeconds(timeEvent);
            OnKillEvent?.Invoke();
            Destroy(gameObject, timeDeath);
        }

        public void OnDamage(float f)
        {
            if (flashColor != null) flashColor.Flash();
            if (particleSystem != null) particleSystem.Emit(5);

            transform.position -= transform.forward;

            _currentLife -= f;

            if (_currentLife <= 0)
            {
                Kill();
            }
        }

        #region ANIMATION
        private void BornAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            _animationBase.PlayAnimationByTrigger(animationType);
        }
        #endregion

        public void Damage(float damage)
        {
            OnDamage(damage);
        }

        /*public void Damage(float damage, Vector3 dir)
        {
            OnDamage(damage);
            //transform.DOMove(transform.position - dir, .1f);
        }*/

        private void OnCollisionEnter(Collision collision)
        {
            Player p = collision.transform.GetComponent<Player>();

            if (p != null)
            {
                p.healthBase.Damage(1);
            }
        }

        public virtual void Update()
        {
            if (lookAtPlayer)
            {
                transform.LookAt(_player.transform.position);
            }
        }
    }
}
