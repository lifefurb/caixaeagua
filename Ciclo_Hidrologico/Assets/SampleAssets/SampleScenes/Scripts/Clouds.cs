using UnityEngine;
using System.Collections;

namespace UnitySampleAssets.SceneUtils
{

    [RequireComponent(typeof (BoxCollider))]
    public class Clouds : MonoBehaviour
    {

        [SerializeField] [Range(0, 1)] private float density;
        [SerializeField] private float noiseScale = 0.0003f;
        [SerializeField] private float minSize = 2000;
        [SerializeField] private float maxSize = 4000;
        [SerializeField] private float stepSize = 500;

        private Bounds area;

        private void Start()
        {
            area = (GetComponent<Collider>() as BoxCollider).bounds;
            StartCoroutine(GenerateClouds());
        }

        public IEnumerator GenerateClouds()
        {
            ParticleSystem system = GetComponent<ParticleSystem>();

            system.Clear();

            Random.seed = 0;

            for (float x = area.min.x; x < area.max.x; x += stepSize)
            {
                for (float z = area.min.z; z < area.max.z; z += stepSize)
                {
                    float p = Mathf.PerlinNoise(x*noiseScale + area.min.x, z*noiseScale + area.min.z);

                    if (p < density)
                    {
                        float size = Mathf.Lerp(minSize, maxSize, Mathf.InverseLerp(density, 0, p));

                        float y = area.center.y + area.size.y*(Random.value - 0.5f)*(Random.value - 0.5f);
                        Vector3 pos = new Vector3(x, y, z);
                        pos += new Vector3(Random.value*stepSize, 0, Random.value*stepSize);
                        system.Emit(pos, Vector3.zero, size, 99999, Color.white);

                    }
                }
            }
            yield return null;
        }
    }
}
