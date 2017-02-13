using UnityEngine;
using UnityEngine.UI;

namespace UnitySampleAssets.SceneUtils
{
    public class SlowMoButton : MonoBehaviour
    {

        public Sprite FullSpeedTex; // the gui texture for full speed
        public Sprite SlowSpeedTex; // the gui texture for slow motion mode
        public float fullSpeed = 1;
        public float slowSpeed = 0.3f;
        public Button button; // reference to the gui texture that will be changed
        public bool alsoScalePhysicsTimestep = true;
        private bool slowMo;
        private float targetTime;
        private float lastRealTime;
        private float fixedTimeRatio;

        private void Start()
        {
            targetTime = fullSpeed;
            lastRealTime = Time.realtimeSinceStartup;
            fixedTimeRatio = Time.fixedDeltaTime/Time.timeScale;
        }

        private void Update()
        {
            float realDeltaTime = Time.realtimeSinceStartup - lastRealTime;

            if (Time.timeScale != targetTime)
            {
                // lerp towards target time
                Time.timeScale = Mathf.Lerp(Time.timeScale, targetTime, realDeltaTime*2);
                if (alsoScalePhysicsTimestep)
                {
                    Time.fixedDeltaTime = fixedTimeRatio*Time.timeScale;
                }
                // snap if close enough:
                if (Mathf.Abs(Time.timeScale - targetTime) < 0.01f)
                {
                    Time.timeScale = targetTime;
                }
            }
            lastRealTime = Time.realtimeSinceStartup;
        }

        public void ChangeSpeed()
        {
            // toggle slow motion state
            slowMo = !slowMo;

            // update button texture
            var image = button.targetGraphic as Image;
            if (image != null)
                image.sprite = slowMo ? SlowSpeedTex : FullSpeedTex;

            button.targetGraphic = image;

            targetTime = slowMo ? slowSpeed : fullSpeed;
        }
    }
}



