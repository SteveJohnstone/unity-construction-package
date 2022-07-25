using SteveJstone;
using UnityEngine;

namespace SteveJstone
{
    public class Building : MonoBehaviour
    {
        //[SerializeField] private SimulationEvents _events = default;
        [SerializeField] private BuildingType _type = default;

        public BuildingType Type => _type;



        public void Start()
        {
          //  _events.OnTick.AddListener(OnTick);
        }

        private void OnTick()
        {
            //Debug.Log("Building Tick");
        }
    }
}
