using UnityEngine;

namespace Models
{
    public class Character
    {
        public Vector3 Position { get; private set; }
        public Vector3 Destination { get; private set; }

        public void SetDestination(Vector3 destination)
        {
            Destination = destination;
        }
        
        public void SetPosition(Vector3 position)
        {
            Position = position;
        }
    }
}