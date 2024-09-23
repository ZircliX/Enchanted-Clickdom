using UnityEngine;
using UnityEngine.UI;

namespace Ores
{
    public class OreShow : MonoBehaviour
    {
        public OreUnit oreData;
        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void Update()
        {
            image.sprite = oreData.oreImage;
        }
    }
}