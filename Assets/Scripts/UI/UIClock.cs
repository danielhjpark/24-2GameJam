using System.Collections;
using UnityEngine;

public class UIClock : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    public bool openAni = false;
    public bool isPlaying = false;

    public void TriggerAnimation(bool forward)
    {
        if (!isPlaying) // �ִϸ��̼��� ���� ���� �ƴ� ����
        {
            if (forward)
                StartCoroutine(PlayAnimationForward());
            else
                StartCoroutine(PlayAnimationReverse());
        }
    }

    private IEnumerator PlayAnimationForward()
    {
        isPlaying = true;
        animator.SetBool("ColPlayer", true);
        yield return null;
        isPlaying = false;
    }

    private IEnumerator PlayAnimationReverse()
    {
        isPlaying = true;
        animator.SetBool("ColPlayer", false);
        yield return null;
        isPlaying = false;
    }
}
