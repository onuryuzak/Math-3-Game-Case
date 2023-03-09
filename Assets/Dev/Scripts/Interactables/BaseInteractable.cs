using System;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace GameCore.Scripts.Interactables
{
    public abstract class BaseInteractable : MonoBehaviour
    {
        #region INSPECTOR PROPERTIES

        [SerializeField] private bool interactable = true;
        [SerializeField] private bool oneShotCollision;
        [SerializeField] private float contactPeriod;

        #endregion

        #region PRIVATE FIELDS

        private float lastContactTime = Single.NegativeInfinity;

        #endregion

        #region PRIVATE PROPERTIES

        private bool _collided;

        #endregion

        #region PUBLIC EVENTS

        [FoldoutGroup("Unity Events")] public CollisionUnityEvent onCollisionEnter;
        [FoldoutGroup("Unity Events")] public CollisionUnityEvent onCollisionStay;
        [FoldoutGroup("Unity Events")] public CollisionUnityEvent onCollisionExit;
        [FoldoutGroup("Unity Events")] public ColliderUnityEvent onTriggerEnter;
        [FoldoutGroup("Unity Events")] public ColliderUnityEvent onTriggerStay;
        [FoldoutGroup("Unity Events")] public ColliderUnityEvent onTriggerExit;

        #endregion

        #region UNITY METHODS

        protected virtual void OnCollisionEnter(Collision other)
        {
            if (CheckIfActorCanCollide(other.gameObject))
                PerformOnCollidedEnter(other);
        }

        protected virtual void OnCollisionStay(Collision other)
        {
            if (CheckIfActorCanCollide(other.gameObject))
                PerformOnCollidedStay(other);
        }

        protected virtual void OnCollisionExit(Collision other)
        {
            if (CheckIfActorCanCollide(other.gameObject))
                PerformOnCollidedExit(other);
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (CheckIfActorCanCollide(other.gameObject))
                PerformOnTriggeredEnter(other);
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            if (CheckIfActorCanCollide(other.gameObject))
                PerformOnTriggeredStay(other);
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            if (CheckIfActorCanCollide(other.gameObject))
                PerformOnTriggeredExit(other);
        }

        #endregion

        #region ABSTRACT METHODS

        protected abstract bool ValidateActor(GameObject g);

        #endregion

        #region PRIVATE METHODS

        private bool CheckIfActorCanCollide(GameObject g)
        {
            if (!interactable)
                return false;

            if (Time.time - lastContactTime < contactPeriod)
                return false;

            lastContactTime = Time.time;

            if (_collided && oneShotCollision)
                return false;

            var validated = ValidateActor(g);
            _collided = validated;

            return validated;
        }

        private void PerformOnCollidedEnter(Collision col)
        {
            OnCollidedEnter(col);
            onCollisionEnter?.Invoke(col);
        }

        private void PerformOnCollidedStay(Collision col)
        {
            OnCollidedStay(col);
            onCollisionStay?.Invoke(col);
        }

        private void PerformOnCollidedExit(Collision col)
        {
            OnCollidedExit(col);
            onCollisionExit?.Invoke(col);
        }

        private void PerformOnTriggeredEnter(Collider col)
        {
            OnTriggeredEnter(col);
            onTriggerEnter?.Invoke(col);
        }

        private void PerformOnTriggeredStay(Collider col)
        {
            OnTriggeredStay(col);
            onTriggerStay?.Invoke(col);
        }

        private void PerformOnTriggeredExit(Collider col)
        {
            OnTriggeredExit(col);
            onTriggerExit?.Invoke(col);
        }

        #region PROTECTED METHODS

        protected virtual void OnCollidedEnter(Collision col)
        {
        }

        protected virtual void OnCollidedStay(Collision col)
        {
        }

        protected virtual void OnCollidedExit(Collision col)
        {
        }

        protected virtual void OnTriggeredEnter(Collider other)
        {
        }

        protected virtual void OnTriggeredStay(Collider other)
        {
        }

        protected virtual void OnTriggeredExit(Collider other)
        {
        }

        #endregion

        #endregion

        #region PUBLIC METHODS

        public void SetInteractable(bool value)
        {
            interactable = value;
        }

        #endregion
    }
}