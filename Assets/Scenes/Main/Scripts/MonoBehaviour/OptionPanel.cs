using System.Collections;
using UnityEngine;

public class OptionPanel : MonoBehaviour
{
    private Animator _animator;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open()
    {
        if (_animator == null) { return; }

        _animator.enabled = true;
        _animator.SetTrigger("Open");
    }

    public void Close()
    {
        if (_animator == null) { return; }

        _animator.SetTrigger("Close");
    }

    public void OnClose()
    {
        if (_animator != null)
        {
            StartCoroutine(OnCloseRoutine());
        }
    }

    private IEnumerator OnCloseRoutine()
    {
        yield return null;
        _animator.enabled = false;
        yield break;
    }
}
