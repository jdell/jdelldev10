package com.mxply.app.baseball.client.droid;

import android.app.Activity;
import android.os.Bundle;

public class BaseballActivity extends Activity {
    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
    }
}