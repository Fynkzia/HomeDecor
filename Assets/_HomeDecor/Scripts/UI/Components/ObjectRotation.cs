using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HomeDecor.UI 
{
    public class ObjectRotation : MonoBehaviour, IPointerDownHandler, IDragHandler
    {
        [SerializeField] private RectTransform _rect;
        [SerializeField] private Image _preview;
        [SerializeField] private float rotationSpeed = 100f;

        private GameObject _model;
        private Vector2 lastPointerPosition;

        public async void Init(string productId)
        {
            GameObject model = await DataRepository.GetModelById(productId);
            if (model == null)
            {
                _preview.sprite = await DataRepository.GetSpriteById(productId);
                return;
            }
            _model = Instantiate(model, _rect);
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            lastPointerPosition = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 delta = eventData.position - lastPointerPosition;

            if (_model != null)
            {
                float rotationY = -delta.x * rotationSpeed * Time.deltaTime;
                _model.transform.Rotate(Vector3.up, rotationY, Space.Self);
            }

            lastPointerPosition = eventData.position;
        }

        public void Clear()
        {
            _preview.sprite = null;
            _model = null;
            Destroy(_model);
        }
}
}
