package ca.seanmorrow.insultgenerator;

import android.support.v7.app.AppCompatActivity;
import android.content.Context;
import android.content.Intent;
import android.graphics.Typeface;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.*;

public class MainView extends AppCompatActivity {

    // view objects
    private ImageButton btnGo;
    private ImageButton btnClear;
    private ImageButton btnHelp;
    private EditText txtName;
    private TextView txtOutput;
    private TextView lblPrompt;
    // private variables
    private MainPresenter presenter;
    private Toast toast;

    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);

        // get references to objects
        txtName = (EditText) findViewById(R.id.txtName);
        lblPrompt = (TextView) findViewById(R.id.lblPrompt);
        txtOutput = (TextView) findViewById(R.id.txtOutput);
        // get reference and setup event listeners for buttons
        btnGo = (ImageButton) findViewById(R.id.btnGo);
        btnGo.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v) {
                presenter.generate();
            }
        });
        btnClear = (ImageButton) findViewById(R.id.btnClear);
        btnClear.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v) {
                presenter.clear();
            }
        });
        btnHelp = (ImageButton) findViewById(R.id.btnHelp);
        btnHelp.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v) {
                presenter.help();
            }
        });

        // construct typeFace object
        Typeface typeFace = Typeface.createFromAsset(getAssets(),"fonts/HURRYUP.ttf");
        // apply typeFace object to appropriate views
        lblPrompt.setTypeface(typeFace);
        txtName.setTypeface(typeFace);
        txtOutput.setTypeface(typeFace);

        // --------------- CHALLENGE SOLUTION
        // construct Toast object for error message and change font
        toast = Toast.makeText(this, this.getString(R.string.error), Toast.LENGTH_SHORT);
        LinearLayout toastLayout = (LinearLayout) toast.getView();
        TextView txtToastMessage = (TextView) toastLayout.getChildAt(0);
        txtToastMessage.setTypeface(typeFace);
        // ----------------------------------

        presenter = new MainPresenter(this);
    }

    // ----------------------------------------------------- public methods
    public String getVictim() {
        return txtName.getText().toString();
    }

    public void showError() {
        txtName.setText("");
        toast.show();
    }

    public void showInsult(String insult) {
        // forcing the keyboard closed
        InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
        imm.hideSoftInputFromWindow(txtName.getWindowToken(), 0);
        // display the insult
        txtOutput.setText(insult);
    }

    public void showHelpPopup() {
        // construct intent object
        Intent intent = new Intent("ca.seanmorrow.insultgenerator.HELPPOPUP");
        startActivity(intent);
    }

    public void reset() {
        txtOutput.setText(this.getString(R.string.testInsult));
        txtName.setText("");
    }
}