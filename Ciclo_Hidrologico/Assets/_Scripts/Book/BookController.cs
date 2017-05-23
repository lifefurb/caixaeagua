using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum page { RIGHT, LEFT };

public class BookController : MonoBehaviour, ISubject {
    
    private page mPageLost;
    private bool mFound;
    private List<IObserver> observers = new List<IObserver>();
    private UpdateData update = new UpdateData();

    void Start() {
        mFound = false;
    }

    public void FoundPage() {
        if (mFound) {
            if (mPageLost == page.RIGHT) {
                update.Page = 1;
            }
            else {
                update.Page = -1;
            }

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
        observers.Add(observer);
    }

    public void removeObserver(IObserver observer) {
        observers.Remove(observer);
    }

    public void notify() {
        foreach (IObserver observer in observers) {
            observer.update(update);
        }
    }
}
