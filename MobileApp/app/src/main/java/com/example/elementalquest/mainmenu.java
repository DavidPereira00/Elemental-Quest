package com.example.elementalquest;

import android.app.Dialog;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;

import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.DefaultItemAnimator;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.androidquery.AQuery;
import com.androidquery.callback.AjaxStatus;

import org.json.JSONObject;

import java.util.ArrayList;

public class mainmenu extends AppCompatActivity {

    private dailyQuests dailyqq;


    private ArrayList<dailyQuests> myDQArray = new ArrayList<dailyQuests>(4);
    final Context context = this;
    ImageButton imageButton;
    AQuery aq = new AQuery(this);
    dailyQuests dailyQ;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.mainmenu);

        ImageButton mybutton=(ImageButton) findViewById(R.id.imageButton4);
        ImageButton yourButton = (ImageButton) findViewById(R.id.imageButton5);


        mybutton.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                startActivity(new Intent(mainmenu.this, items.class));
            }
        });


        yourButton.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                startActivity(new Intent(mainmenu.this, enemies.class));
            }
        });

        imageButton = (ImageButton) findViewById(R.id.imageView8);

    }

    public void buttonclick(View v) {

        AQuery aq = new AQuery(this);
        String url = "http://10.0.2.2/android/profile.php";
        aq.ajax(url, JSONObject.class, this, "jsonCallback");
        startActivity(new Intent(mainmenu.this, Showbox.class));
        //imageButton.setImageResource(R.drawable.close1);
    }
    public void jsonCallback(String url, JSONObject json, AjaxStatus status) {
        if (json != null) {

            try {
                String msg = json.getString("msg");
                Toast.makeText(this, msg, Toast.LENGTH_LONG).show();
            } catch (Exception ex) {
            }
        } else {
        }
    }
    @Override
    public void onBackPressed() {
    }
/*
    private void createOpDeck(){

        //in here I create an opponent deck to test the game system
        for(int i=0;i<4;i++) {
            dailyqq=new dailyQuests();
            dailyqq.setName("D");
            dailyqq.setDescription("DS");
            dailyqq.setCompleted("DSSS");
            dailyqq.setLevel("DSS");
            //dailyqq.setName("Enemy"+i);
/*
            if(getRandomNumberInRange(1,3)==1)
                aCard.setClass("Warrior");
            else if(getRandomNumberInRange(1,3)==2)
                aCard.setClass("Priest");
            else
                aCard.setClass("Mage");*/
            /*myDQArray.add(i,dailyqq);

        }




    }*/

}

