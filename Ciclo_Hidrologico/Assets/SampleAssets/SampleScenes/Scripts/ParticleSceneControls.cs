using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnitySampleAssets.Effects;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnitySampleAssets.SceneUtils
{
    public class ParticleSceneControls : MonoBehaviour
    {

        public DemoParticleSystemList demoParticles;
        public float distFromSurface = 0.5f;

        public float multiply = 1;
        public bool clearOnChange = false;
        public Text titleGuiText;
        public Transform demoCam;
        public Text interactionGuiText;

        public Button previousButton;
        public Button nextButton;


        private ParticleSystemMultiplier particleMultiplier;

        private List<Transform> currentParticleList = new List<Transform>();

        private Transform instance;
        private static int selectedIndex = 0;
        private Vector3 camOffsetVelocity = Vector3.zero;
        private Vector3 lastPos;

        public enum Mode
        {
            Activate,
            Instantiate,
            Trail
        }

        public enum AlignMode
        {
            Normal,
            Up
        }

        private static DemoParticleSystem selected;

        private void Awake()
        {
            Select(selectedIndex);

            previousButton.onClick.AddListener(Previous);
            nextButton.onClick.AddListener(Next);
        }

        private void OnDisable()
        {

            previousButton.onClick.RemoveAllListeners();
            previousButton.onClick.RemoveAllListeners();
        }

        private void Previous()
        {
            selectedIndex--;
            if (selectedIndex == -1) selectedIndex = demoParticles.items.Length - 1;
            Select(selectedIndex);

        }

        public void Next()
        {
            selectedIndex++;
            if (selectedIndex == demoParticles.items.Length) selectedIndex = 0;
            Select(selectedIndex);

        }

        private void Update()
        {
            demoCam.localPosition = Vector3.SmoothDamp(demoCam.localPosition, Vector3.forward*-selected.camOffset,
                                                       ref camOffsetVelocity, 1);

            if (selected.mode == Mode.Activate)
            {
                // this is for a particle system that just needs activating, and needs no interaction (eg, duststorm)
                return;
            }


            bool oneShotClick = (Input.GetMouseButtonDown(0) && selected.mode == Mode.Instantiate);
            bool repeat = (Input.GetMouseButton(0) && selected.mode == Mode.Trail);

            if (oneShotClick || repeat)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    var rot = Quaternion.LookRotation(hit.normal);

                    if (selected.align == AlignMode.Up) rot = Quaternion.identity;

                    var pos = hit.point + hit.normal*distFromSurface;

                    if ((pos - lastPos).magnitude > selected.minDist)
                    {

                        if (selected.mode != Mode.Trail || instance == null)
                        {

                            instance = (Transform) Instantiate(selected.transform, pos, rot);

                            if (particleMultiplier != null)
                            {
                                instance.GetComponent<ParticleSystemMultiplier>().multiplier = multiply;
                            }

                            currentParticleList.Add(instance);

                            if (selected.maxCount > 0 && currentParticleList.Count > selected.maxCount)
                            {
                                if (currentParticleList[0] != null)
                                {
                                    Destroy(currentParticleList[0].gameObject);
                                }
                                currentParticleList.RemoveAt(0);

                            }

                        }
                        else
                        {
                            instance.position = pos;
                            instance.rotation = rot;
                        }

                        if (selected.mode == Mode.Trail)
                        {
                            instance.transform.GetComponent<ParticleSystem>().enableEmission = false;
                            instance.transform.GetComponent<ParticleSystem>().Emit(1);
                        }

                        instance.parent = hit.transform;
                        lastPos = pos;
                    }

                }
            }

        }


        private void Select(int i)
        {
            selected = demoParticles.items[i];
            instance = null;
            foreach (var otherEffect in demoParticles.items)
            {
                if ((otherEffect != selected) && (otherEffect.mode == Mode.Activate))
                {
                    otherEffect.transform.gameObject.SetActive(false);
                }
            }
            if (selected.mode == Mode.Activate)
            {
                selected.transform.gameObject.SetActive(true);
            }
            particleMultiplier = selected.transform.GetComponent<ParticleSystemMultiplier>();
            multiply = 1;
            if (clearOnChange)
            {
                while (currentParticleList.Count > 0)
                {
                    Destroy(currentParticleList[0].gameObject);
                    currentParticleList.RemoveAt(0);
                }
            }

            interactionGuiText.text = selected.instructionText;
            titleGuiText.text = selected.transform.name;
        }


        [System.Serializable]
        public class DemoParticleSystem
        {
            public Transform transform;
            public Mode mode;
            public AlignMode align;
            public int maxCount;
            public float minDist;
            public int camOffset = 15;
            public string instructionText;
        }

        [System.Serializable]
        public class DemoParticleSystemList
        {
            public DemoParticleSystem[] items;
        }

    }
}


