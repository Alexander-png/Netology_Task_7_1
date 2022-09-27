using System.Collections;
using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerStatsComponent))]
    public abstract class BasePlayerController : MonoBehaviour
    {
        [SerializeField]
        protected Rigidbody _body;
        [SerializeField]
        protected PlayerStatsComponent _playerStats;

        protected virtual void Start()
        {
            StartCoroutine(MoveForward());
        }

        protected void Jump()
        {
            _body.AddForce(transform.up * _playerStats.JumpForce, ForceMode.Impulse);
        }

        private IEnumerator MoveForward()
        {
            while(true)
            {
                transform.position += transform.forward * _playerStats.ForwardSpeed * Time.deltaTime;
                yield return null;
			}
		}
    }
}
