using UnityEngine;

namespace NpcSpawning
{
    public class NpcSpawner : MonoBehaviour
    {
        [SerializeField] private Npc _npcPrefab;
        [SerializeField] private Vector2 _zoneSize = Vector2.one;

        private Vector2 Center => transform.position;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(Center, _zoneSize);
        }

        public void Spawn()
        {
            var min = Center - _zoneSize / 2;
            var max = Center + _zoneSize / 2;
            var position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
            Instantiate(_npcPrefab, position, Quaternion.identity);
        }
    }
}