using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float _MovementSmoothing = .05f;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _velocity= Vector3.zero;
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float move)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity =
            Vector3.SmoothDamp(_rigidbody2D.velocity, targetVelocity, ref _velocity, _MovementSmoothing);
    }

    public void Anim(bool move)
    {
        _anim.SetBool("isRunning",move);
    }
}
