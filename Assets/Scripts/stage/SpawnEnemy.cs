using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace stage
{
    public class SpawnEnemy : MonoBehaviour
    {
        private Button _button;

        public GameObject enemyPrefab;
        public Transform spawnPointStart;
        public Transform spawnPointEnd;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            var position = spawnPointStart.position;
            var position1 = spawnPointEnd.position;
            Instantiate(enemyPrefab,
                new Vector3(Random.Range(position.x, position1.x),
                    Random.Range(position.y, position1.y), 0), Quaternion.identity);
            EventSystem.current.SetSelectedGameObject(null);

        }
    }
}