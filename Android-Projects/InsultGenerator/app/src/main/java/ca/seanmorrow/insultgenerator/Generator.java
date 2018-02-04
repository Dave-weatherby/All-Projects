package ca.seanmorrow.insultgenerator;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Map;
import java.util.Random;
import java.util.Set;
import android.app.Activity;
import android.content.res.Resources;
import android.support.annotation.Nullable;
import android.os.Parcel;
import android.os.Parcelable;

public class Generator{

    // the number of adjectives added to insult
    private final int NUM_OF_ADJECTIVES = 4;

    // random object
    Random random;
    // array declaration
    private String[] aryAdjective;
    private String[] aryNoun;
    private int counter;
    private int adjectiveCount;
    private int insultCount;
    private String insult;
    private Resources resources;
    private String victim;

    private static Generator instance = null;

    // ----------------------------------------------- constructor method
    public static Generator getInstance() {
        if (instance == null) {
            instance = new Generator();
        }
        return instance;
    }

    private Generator() {
        // construct Random object
        random = new Random();
        counter = 0;
        insultCount = 0;
        adjectiveCount = NUM_OF_ADJECTIVES;
        insult = "";
        // get array data from strings.xml
        aryAdjective = null;
        aryNoun = null;
    }

    // ----------------------------------------------- get/set methods
    public int getInsultCount(){
        return insultCount;
    }

    public void setInsultCount(int value) {
        insultCount = value;
    }

    public String getInsult(){
        return insult;
    }

    public void setResources(Resources myResources) {
        resources = myResources;
        // update arrays with data from strings.xml
        aryAdjective = resources.getStringArray(R.array.adjectives_array);
        aryNoun = resources.getStringArray(R.array.nouns_array);
        // update default insult to be default message
        if (insult.equals("")) insult = resources.getString(R.string.testInsult);
    }

    // ----------------------------------------------- private methods
    private String getAdjectives() {
        String adjectives = "";

        // convert aryAdjective array to an arraylist - shuffle method only works with an ArrayList
        ArrayList<String> aryAdjectiveArrayList = new ArrayList(Arrays.asList(aryAdjective));
        // shuffle up the ArrayList into a random order (cool class method!)
        Collections.shuffle(aryAdjectiveArrayList);
        // pluck first four adjectives and concatenate onto string
        for (int n=0; n<adjectiveCount; n++) {
            adjectives += aryAdjectiveArrayList.get(n) + " ";
        }

        return adjectives;
    }

    private String getNoun() {
        String noun = "";

        // get random index of array
        int index = random.nextInt(aryNoun.length);
        noun = aryNoun[index];
        return noun;
    }

    // ----------------------------------------------- public methods
    public String hitMe(String myVictim) {
        victim = myVictim;
        insult = getAdjectives();
        insult += getNoun();
        // concatenate final insult
        insult = victim + " " + resources.getString(R.string.insultJoin) + " " + insult;
        // increment insult counter
        insultCount++;

        return insult;
    }

    public void reset() {
        // resets the insult counter
        insultCount = 0;
        insult = resources.getString(R.string.testInsult);
    }

}
