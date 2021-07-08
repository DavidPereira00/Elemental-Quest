package com.example.elementalquest;

import android.content.Context;
import android.graphics.Color;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.GridView;
import android.widget.ImageButton;
import android.widget.ImageView;

public class ImageAdapter extends BaseAdapter{
    private Context mContext;

    public ImageAdapter(Context c) {
        mContext = c;
    }

    public int getCount() {
        return mThumbIds.length;
    }

    public Object getItem(int position) {
        return null;
    }

    public long getItemId(int position) {
        return 0;
    }

    // create a new ImageView for each item referenced by the Adapter
    public View getView(int position, View convertView, ViewGroup parent) {
        ImageButton imageButton;
        if (convertView == null) {
            // if it's not recycled, initialize some attributes
            imageButton = new ImageButton(mContext);
            imageButton.setLayoutParams(new GridView.LayoutParams(300, 300));
            imageButton.setScaleType(ImageView.ScaleType.CENTER_CROP);
            imageButton.setPadding(20, 20, 20, 20);
            imageButton.setBackgroundColor(Color.TRANSPARENT);

        } else {
            imageButton = (ImageButton) convertView;
        }

        imageButton.setImageResource(mThumbIds[position]);
        return imageButton;
    }


    // references to our images
    private Integer[] mThumbIds = {
            R.drawable.fenix, R.drawable.bea,
            R.drawable.spi, R.drawable.bea,
            R.drawable.fenix, R.drawable.spi,
            R.drawable.bea, R.drawable.spi,
            R.drawable.fenix
    };
}
