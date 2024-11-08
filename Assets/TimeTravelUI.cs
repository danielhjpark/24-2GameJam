using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTravelUI : MonoBehaviour
{

    [SerializeField]
    private Sprite BaseImage;         // 닫혀 있는 이미지
    [SerializeField]
    private Sprite ChangeImage;       // 열린 이미지
    [SerializeField]
    private Image nowImage;         // 현재 이미지

    [SerializeField]
    private TimeTravelController ttcontroller;

    private void FixedUpdate()
    {
        if(ttcontroller == null)
        {
            Debug.Log("컨트롤러 없음");
        }

        // TimeTravel이 가능한 오브젝트 위에 있고, 지금 이미지가 BaseImage면 바꿔주기
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
