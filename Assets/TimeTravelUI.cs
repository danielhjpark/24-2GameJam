using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTravelUI : MonoBehaviour
{

    [SerializeField]
    private Sprite BaseImage;         // ���� �ִ� �̹���
    [SerializeField]
    private Sprite ChangeImage;       // ���� �̹���
    [SerializeField]
    private Image nowImage;         // ���� �̹���

    [SerializeField]
    private TimeTravelController ttcontroller;

    private void FixedUpdate()
    {
        if(ttcontroller == null)
        {
            Debug.Log("��Ʈ�ѷ� ����");
        }

        // TimeTravel�� ������ ������Ʈ ���� �ְ�, ���� �̹����� BaseImage�� �ٲ��ֱ�
        if(ttcontroller.canTimeTravel && nowImage.sprite == BaseImage)
        {
            ImageUpdate(ChangeImage);
        }
        else if(!ttcontroller.canTimeTravel && nowImage.sprite != BaseImage)
        {
            ImageUpdate(BaseImage);
        }
    }

    private void ImageUpdate(Sprite _change)
    {
        nowImage.sprite = _change;
    }
}
