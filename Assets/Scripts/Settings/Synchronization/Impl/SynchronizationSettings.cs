using UnityEngine;

namespace Settings.Synchronization.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(SynchronizationSettings), fileName = nameof(SynchronizationSettings))]
    public class SynchronizationSettings : ScriptableObject, 
        ISynchronizationSettings
    {
        [SerializeField] private float positionDivergence;

        public float PositionDivergence => positionDivergence;
    }
}