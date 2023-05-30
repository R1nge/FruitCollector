using UnityEngine;
using VContainer;

namespace Collectables
{
    public class Banana : Collectable
    {
        [SerializeField] private int point;
        private ScoreHandler _scoreHandler;
        
        [Inject]
        private void Construct(ScoreHandler scoreHandler)
        {
            _scoreHandler = scoreHandler;
        }

        protected override void PickUp()
        {
            base.PickUp();
            _scoreHandler.AddScore(point);
            Destroy(gameObject);
        }
    }
}