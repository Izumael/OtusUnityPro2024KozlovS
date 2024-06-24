using System;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private EnemyMoveAgent _moveAgent;
        [SerializeField] private float _attackTime;

        private GameObject _target;
        private HitPointsComponent _targetHitPoints;
        private Timer _attackTimer;
        private BulletManager _bulletManager;

        private void Awake()
        {
            _attackTimer = new Timer(_attackTime);
        }

        private void FixedUpdate()
        {
            if (!_moveAgent.IsReached)
            {
                return;
            }
            
            if (!_targetHitPoints.IsHitPointsExists())
            {
                return;
            }

            if (_attackTimer.Tick(Time.fixedDeltaTime))
            {
                Attack();
            }
        }

        public void SetTarget(GameObject target)
        {
            _target = target;
            _targetHitPoints = target.GetComponent<HitPointsComponent>();
        }
        public void SetBulletManager(BulletManager bulletManager)
        {
            _bulletManager = bulletManager;
        }

        private void Attack()
        {
            var startPosition = _weaponComponent.Position;
            var vector = (Vector2) _target.transform.position - startPosition;
            var direction = vector.normalized;
            _bulletManager.Shoot(this.gameObject, direction);
        }
    }
}