package com.example.elementalquest;

import android.app.Dialog;
import android.content.Context;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.GridView;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;


public class enemies extends AppCompatActivity {

    final Context context = this;
    private ImageButton imageButton2;
    private ImageButton imageButton3;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.enemies);



        /*gridview.setOnItemClickListener (new AdapterView.OnItemClickListener() {
            public void onItemClick(AdapterView<?> parent, View v,
                                    int position, long id) {
               Log.v("hello","hello");
            }
        });*/


        imageButton3=  (ImageButton) findViewById(R.id.fenixOMG);
        imageButton2 = (ImageButton) findViewById(R.id.wolfOMG);

        // add button listener

        imageButton2.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View arg0) {

                // custom dialog
                final Dialog dialog = new Dialog(context);
                dialog.setContentView(R.layout.specificenemy);
                dialog.setTitle("Title...");

                // set the custom dialog components - text, image and button

                //ImageView image = (ImageView) dialog.findViewById(R.id.image);
                //image.setImageResource(R.drawable.ic_stat_name);

                // Button dialogButton = (Button) dialog.findViewById(R.id.dialogButtonOK);
                // if button is clicked, close the custom dialog
                /*dialogButton.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        dialog.dismiss();
                    }
                });*/

                dialog.show();
            }
        });
        imageButton3.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View arg0) {

                // custom dialog
                final Dialog dialog = new Dialog(context);
                dialog.setContentView(R.layout.specificenemy);
                dialog.setTitle("Title...");

                // set the custom dialog components - text, image and button


                // Button dialogButton = (Button) dialog.findViewById(R.id.dialogButtonOK);
                // if button is clicked, close the custom dialog
                /*dialogButton.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        dialog.dismiss();
                    }
                });*/

                dialog.show();
            }
        });
    }
}

