using System;

namespace ShootEmUp
{
    [Serializable]
    public class Timer
    {
        private float _currentTime;
        private float _countdownTime;

        public Timer(float countdownTime)
        {
            _currentTime = countdownTime;
            _countdownTime = countdownTime;
        }

        public Timer()
        {
            _currentTime = 1f;
            _countdownTime = 1f;
        }

        public bool Tick(float deltaTime)
        {
            bool triggered = false;
            _currentTime -= deltaTime;
            if (_currentTime <= 0)
            {
                triggered = true;
                Reset();
            }
            return triggered;
        }

        public void Reset()
        {
            _currentTime = _countdownTime;
        }
    }
}