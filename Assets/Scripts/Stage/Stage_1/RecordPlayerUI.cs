using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordPlayerUI : MonoBehaviour
{
    [SerializeField] public CheckScript check;
    [SerializeField] private bool isClear = false;
    [SerializeField] public GameObject panel;
    [SerializeField] public GameObject child;
    [SerializeField] public PopUpUI popUpUI;
    [SerializeField] public PlaySound playSound;
    [SerializeField] public Sprite changeImage;
    [SerializeField] public GameObject record;

    private void Update()
    {
        if (isClear)
        {
            return;
        }

        if(this.gameObject.GetComponentInChildren<DragAndDrop>() != null)
        {
            if (this.gameObject.GetComponentInChildren<DragAndDrop>().name == "Jazz")
            {
                isClear = true;
                check.Clear();
                //여기서 뭐? 코루틴 하고 스프라이트 변경하고
                StartCoroutine(ChangeSprite());
            }
        }
    }

    IEnumerator ChangeSprite()
    {
        //스프라이트 변경~
        Image test = this.gameObject.GetComponent<Image>();
        test.sprite = changeImage;
        Destroy(record);
        yield return new WaitForSeconds(3.0f);
        popUpUI.PopUp();
        playSound.Play();
    }
}
