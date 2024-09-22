using UnityEngine;

namespace Ores
{
    public class OreShow : MonoBehaviour
    {
        public OreUnit oreData;
        private SpriteRenderer image;

        private void Awake()
        {
            image = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            image.sprite = oreData.oreImage;
        }
    }
}