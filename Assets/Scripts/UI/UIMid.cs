using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMid : MonoBehaviour
{
    [Header("UI Mid")]
    [SerializeField] private Button btnRight;

    public void OpenUIMid()
    {
        UIManager.Instance.AnimationUI.UIOnMoveUp(gameObject.GetComponent<RectTransform>());
    }

    public void CloseUIMid()
    {
        UIManager.Instance.AnimationUI.UIOffMoveDown(gameObject.GetComponent<RectTransform>());
    }
}
