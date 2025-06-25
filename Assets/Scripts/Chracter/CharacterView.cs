using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
    private const string IsRunnig = "IsRunnig";
    private const string IsJumping = "IsJumping";
    private const string IsDie = "IsDie";
    private const string IsFall = "IsFall";
    private const string IsCrawl = "IsCrawl";
    private const string IsClimb = "IsClimb";
    private const string IsClimbing = "IsClimbing";
    private const string IsIdling = "IsIdling";
    private const string IsCrawling = "IsCrawling";

    private Transform _transform;
    private Animator _animator;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _transform.position = new Vector3(4.42f, -3.2f, 0);
    }

    public void StartIdling() => _animator.SetBool(IsIdling, true);
    public void StopIdling() => _animator.SetBool(IsIdling, false);

    public void StartRunnig() => _animator.SetBool(IsRunnig, true); 
    public void StopRunnig() => _animator.SetBool(IsRunnig, false);

    public void StartJumping() => _animator.SetBool(IsJumping, true); 
    public void StopJumping() => _animator.SetBool(IsJumping, false);

    public void StartDie() => _animator.SetBool(IsDie, true);
    public void StopDie() => _animator.SetBool(IsDie, false);

    public void StartFalling() => _animator.SetBool(IsFall, true);
    public void StopFalling() => _animator.SetBool(IsFall, false);

    public void StartClimb() => _animator.SetBool(IsClimb, true);
    public void StopClimb() => _animator.SetBool(IsClimb, false);

    public void StartCrawl() => _animator.SetBool(IsCrawl, true);
    public void StopCrawl() => _animator.SetBool(IsCrawl, false);

    public void StartCrawlIng() => _animator.SetBool(IsCrawling, true);
    public void StopCrawlIng() => _animator.SetBool(IsCrawling, false);

    public void StartClimbing() => _animator.SetBool(IsClimbing, true);
    public void StopClimbing() => _animator.SetBool(IsClimbing, false);

}
