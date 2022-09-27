using UnityEngine;

namespace Runner
{
    public class OldPlayerController : BasePlayerController
    {
        protected override void Start()
        {
            base.Start();
        }

        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space)) Jump();

            var direction = Input.GetAxis("Horizontal") * _playerStats.SideSpeed * Time.fixedDeltaTime;

            if (direction == 0f) return;
            _body.velocity += direction * transform.right;
        }
	}
}
