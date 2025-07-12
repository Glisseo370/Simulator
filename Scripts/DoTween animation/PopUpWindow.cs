using UnityEngine;
using DG.Tweening;

public class PopUpWindow : MonoBehaviour
{
    [SerializeField] private Vector3 placeForUI;
    [SerializeField] private CanvasGroup bodyAlphaGroup;

    private Sequence notEnough;
    private void OnEnable()
    {
        Show();
    }

    public void Hide()
    {
        notEnough = DOTween.Sequence();
        notEnough.Join(gameObject.transform.DOScale(Vector3.zero, 1f)).Join(bodyAlphaGroup.DOFade(0, 1f).OnComplete(() => gameObject.SetActive(false)));
    }

    public void Show()
    {
        notEnough = DOTween.Sequence();
        notEnough.Join(gameObject.transform.DOScale(Vector3.one, 1f)).Join(bodyAlphaGroup.DOFade(1, 1f));
    }
}
