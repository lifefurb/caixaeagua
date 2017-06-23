using System.Collections.Generic;
using UnityEngine;

public class TipBook : MonoBehaviour {
    
    private List<string> mTips = new List<string>();
    private string mTip;
    private int mIndex = 0;
    private int mMax = 25;
    private int mLimit;
    private string[] mPage;

    public List<string> Tip(string tip) {
        mPage = tip.Split();

        mLimit = mMax;

        while(mIndex <= mPage.Length){
            string page = "";
            
            while (mIndex <= mLimit){
                if(mIndex < mPage.Length)
                    page += mPage[mIndex] + " ";

                mIndex++;
            }
            mTips.Add(page);
            mLimit += mMax;
        }
        return mTips;
    }
}