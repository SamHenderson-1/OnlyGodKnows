using UnityEngine;

namespace InteractionGameSystem
{
    public class InteractionSystem : MonoBehaviour
    {
        [SerializeField] private RaycastData data = null;

        [SerializeField] private Transform viewCamera = null;

        [SerializeField] private float interactionDistance = 5f;
        [SerializeField] private LayerMask layersToRaycast = 0;

        void Start()
        {
            data.Reset();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (data.HitTransform)
                {
                    var component = data.HitTransform.GetComponent<IInteractable>();
                    if (component != null)
                    {
                        component.Interact();
                    }
                }
            }
            if (Time.frameCount % 4 == 0)
            {
                RaycastHit? hit = DoRaycasting();

                if (hit.HasValue)
                {
                    if (data.IsThisNewObject(hit.Value.transform))
                    {
                        data.UpdateData(hit);
                    }
                }
                else
                {
                    if (data.HitTransform)
                    {
                        data.Reset();
                    }
                }
            }
        }

        private RaycastHit? DoRaycasting()
        {
            Ray ray = new Ray(viewCamera.position, viewCamera.forward);

            RaycastHit hit;

            bool hasHit = Physics.Raycast(ray, out hit, interactionDistance, layersToRaycast);

            if (hasHit)
            {
                return hit;
            }
            return null;
        }
    }
}