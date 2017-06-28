using System.Collections.Generic;
using UnityEngine;

public enum page { RIGHT, LEFT };

public class BookController : MonoBehaviour, ISubject {
    
    private page mPageLost;
    private bool mFound;
    private List<IObserver> mObservers = new List<IObserver>();
    private UpdateData mUpdate = new UpdateData();
    
    void Start() {
        mFound = false;
    }

    public void FoundPage() {
        if (mFound) {
            if (mPageLost == page.RIGHT)
                mUpdate.Page = 1;
            else
                mUpdate.Page = -1;
            
            mFound = false;
            notify();
        }
    }

    public void LostPage(page who) {
        if (!mFound) {
            mPageLost = who;
            mFound = true;
        }
    }

    public void OpenLink(string link) {
        Application.OpenURL(link);
    }

    public void addObserver(IObserver observer) {
        mObservers.Add(observer);
    }

    public void removeObserver(IObserver observer) {
        mObservers.Remove(observer);
    }

    public void notify() {
        foreach (IObserver observer in mObservers) {
            observer.update(mUpdate);
        }
    }
}