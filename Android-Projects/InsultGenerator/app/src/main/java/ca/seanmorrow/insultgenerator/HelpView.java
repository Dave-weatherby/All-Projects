package ca.seanmorrow.insultgenerator;

import android.app.Activity;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.*;
import android.graphics.Typeface;
import android.content.SharedPreferences;

public class HelpView extends AppCompatActivity {

    private TextView lblInsultCount;
    private HelpPresenter presenter;
    private SharedPreferences sharedPreferences;
    private int insultCount;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.help);

        sharedPreferences = getSharedPreferences("StoredData", MODE_PRIVATE);
        insultCount = sharedPreferences.getInt("insultCount", 0);

        lblInsultCount = (TextView) findViewById(R.id.lblInsultCount);

        // construct typeFace object
        Typeface typeface = Typeface.createFromAsset(getAssets(),"fonts/HURRYUP.ttf");
        // apply typeFace object to appropriate views
        ((TextView) findViewById(R.id.lblInsultCount)).setTypeface(typeface);
        ((TextView) findViewById(R.id.lblHelp)).setTypeface(typeface);
        ((TextView) findViewById(R.id.lblTitle)).setTypeface(typeface);

        presenter = new HelpPresenter(this);
    }

    // ----------------------------------------------------- public methods
    public void updateCount(int insult_count) {
        insultCount = insultCount + insult_count;
        SharedPreferences.Editor editor = sharedPreferences.edit();
        editor.putInt("insultCount",insultCount);
        editor.apply();
        lblInsultCount.setText(this.getString(R.string.lblInsultCount) + " " + insultCount);
    }

}