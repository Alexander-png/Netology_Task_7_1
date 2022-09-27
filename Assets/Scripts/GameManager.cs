using Runner.Assistance;
using UnityEngine;
using UnityEngine.UI;

namespace Runner
{
    public class GameManager : MonoBehaviour
    {
        private int _progress = 0;
        private const float _levelSegmentLength = 6f;
        private const float _deathZoneY = -1f;

        [SerializeField, Range(1, 100), Tooltip("Это здоровье игрока, не перепутай")]
        private int Health = 3;
        [SerializeField]
        private Transform _player;

        [SerializeField]
        private Transform[] _levels;

        [SerializeField]
        private Transform _levelSegmentPool;

        [SerializeField, Space]
        private Text _text;

        public static GameManager Self { get; private set; }
        private int LevelLength => _levels.Length;

        private void Awake()
        {
            Self = this;
        }

        private void Start()
        {
            FindLevelSegments();
        }

        private void FindLevelSegments()
        {
            _levels = new Transform[_levelSegmentPool.childCount];
            for (int i = 0; i < _levelSegmentPool.childCount; i++)
            {
                _levels[i] = _levelSegmentPool.transform.GetChild(i);
            }
        }

		private void Update()
		{
            DebugLogger.WriteToLog("Game Manager Update");
            if (_player.position.y <= _deathZoneY) SetDamage();
        }

		public void SetDamage()
        {
            Health -= 1;

            DebugLogger.WriteToLog("Current health: " + Health);

            if(Health <= 0)
            {
                DebugLogger.WriteToLog("---Игрок погиб!---");
                UnityEditor.EditorApplication.isPaused = true;
			}
		}

        private void UpdateUI()
        {
            _text.text = _progress.ToString();
        }

        public void UpdateLevel(GameObject passedSegment)
        {
            _progress++;
            UpdateUI();

            var position = passedSegment.transform.position;
            position.z += _levelSegmentLength * LevelLength;
            passedSegment.transform.position = position;
        }
    }
}