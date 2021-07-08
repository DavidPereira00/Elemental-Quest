package com.example.elementalquest;
import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;



import java.util.List;

/**
 * Created by JUNED on 6/16/2016.
 */
public class RecyclerViewAdapter extends RecyclerView.Adapter<RecyclerViewAdapter.ViewHolder> {

    Context context;

    List<GetDataAdapter> getDataAdapter;

    public RecyclerViewAdapter(List<GetDataAdapter> getDataAdapter, Context context){

        super();

        this.getDataAdapter = getDataAdapter;
        this.context = context;
    }

    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {

        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.recyclerview_items, parent, false);

        ViewHolder viewHolder = new ViewHolder(v);

        return viewHolder;
    }

    @Override
    public void onBindViewHolder(ViewHolder holder, int position) {

        GetDataAdapter getDataAdapter1 =  getDataAdapter.get(position);

        holder.NameTextView.setText(getDataAdapter1.getName());
        holder.DescriptionTextView.setText(getDataAdapter1.getDescription());
        holder.LevelTextView.setText(getDataAdapter1.getLevel());



       // holder.PhoneNumberTextView.setText(getDataAdapter1.getPhone_number());

       // holder.SubjectTextView.setText(getDataAdapter1.getSubject());

    }

    @Override
    public int getItemCount() {

        return getDataAdapter.size();
    }

    class ViewHolder extends RecyclerView.ViewHolder{


        public TextView NameTextView;
        public TextView DescriptionTextView;
        public TextView LevelTextView;
        public TextView PhoneNumberTextView;
        public TextView SubjectTextView;


        public ViewHolder(View itemView) {

            super(itemView);

            NameTextView = (TextView) itemView.findViewById(R.id.textView2) ;
            DescriptionTextView = (TextView) itemView.findViewById(R.id.textView4) ;
            LevelTextView = (TextView) itemView.findViewById(R.id.textView6) ;
            //PhoneNumberTextView = (TextView) itemView.findViewById(R.id.textView6) ;
            //SubjectTextView = (TextView) itemView.findViewById(R.id.textView8) ;


        }
    }
}
