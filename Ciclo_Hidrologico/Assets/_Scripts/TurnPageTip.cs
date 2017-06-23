using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class TurnPageTip : MonoBehaviour, ITrackableEventHandler, IObserver
{

    public page m_PagePosition;
    public Text m_Page;
    public BookController m_BookController;
    #region PRIVATE_MEMBER_VARIABLES

    private TrackableBehaviour mTrackableBehaviour;
    private int mCount;
    private bool mShow = false;
    private bool mFirstFound;
    #endregion // PRIVATE_MEMBER_VARIABLES

    #region UNTIY_MONOBEHAVIOUR_METHODS

    void Awake() {
        mFirstFound = false;
    }

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        m_BookController.addObserver(this);
        mCount = 0;
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    /// Implementation of the ITrackableEventHandler function called when the
    /// tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            mShow = true;
            OnTrackingFound();
            if (mFirstFound)
                m_BookController.FoundPage();

            mFirstFound = true;
        }
        else
        {
            mShow = false;
            OnTrackingLost();
            m_BookController.LostPage(m_PagePosition);
        }
    }

    #endregion // PUBLIC_METHODS



    #region PRIVATE_METHODS

    private void OnTrackingFound() {
        if (Quiz.m_TipSplit.Count > 0)
            m_Page.text = Quiz.m_TipSplit[mCount];
        else
            m_Page.text = "Nenhuma pergunta selecionada.";

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
    }

    private void OnTrackingLost() {
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
    }

    public void update(UpdateData update) {
        if ((mCount + update.Page) >= 0 && (mCount + update.Page) < Quiz.m_TipSplit.Count) {
            if (mShow)
                OnTrackingLost();

            mCount += update.Page;
        }
        if (mShow)
            OnTrackingFound();

    }

    #endregion // PRIVATE_METHODS
}