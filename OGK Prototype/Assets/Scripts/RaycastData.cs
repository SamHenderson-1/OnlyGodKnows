
using UnityEngine;

namespace InteractionGameSystem
{
    [CreateAssetMenu(fileName = "RaycastData", menuName = "Game/new RaycastData")]
    public class RaycastData : ScriptableObject
    {
        public Transform HitTransform { private set; get; }
        public RaycastHit? Hit { private set; get; }

        public void UpdateData(RaycastHit? _hit)
        {
            HitTransform = _hit.Value.transform;
            Hit = _hit;

            Debug.Log(HitTransform.name);
        }

        public bool IsThisNewObject(Transform transform)
        {
            if (HitTransform == null) return true;

            if (HitTransform == transform) return false;

            return true;
        }

        public void Reset()
        {
            HitTransform = null;
            Hit = null;
        }
    }
}