package com.arpan.laptop.alchemy;

import android.content.Context;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AbsoluteLayout;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.Toast;

import org.lucasr.twowayview.TwoWayView;

public class MainActivity extends AppCompatActivity{

    TwoWayView listView;
    Context context;
    String[] compounds = new String[]{"HCl", "NaOH", "NaCl", "H2O", "KOH", "H2SO4"
            , "Ca(OH)2", "NaHCO3", "NaOCl", "CaO", "CaCO3"
            , "CO2", "O2", "KMnO4", "FeSO4", "Fe", "Cu", "AgNO3"
            , "Ag", "Mg", "ZnSO4", "Zn", "Fe2O3", "KI", "Cl2"
            , "I2", "KCl", "Cu(NO3)2", "CuSO4", "MgSO4", "Na"
            , "H2", "Al", "Al2O3"};

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        context=this;
        setContentView(R.layout.activity_main);
        ArrayAdapter<String> compoundAdapter = new ArrayAdapter<>(this, R.layout.compound_list_item, compounds);
        listView = (TwoWayView)findViewById(R.id.lvItems);
        listView.setAdapter(compoundAdapter);
        listView.bringToFront();
        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                RelativeLayout rl = (RelativeLayout) findViewById(R.id.relativeLayout);
                String item = ((TextView) view).getText().toString();
                Button added = new Button(context);
                added.setText(item);
                rl.addView(added);
                RelativeLayout.LayoutParams params = (RelativeLayout.LayoutParams) added.getLayoutParams();
                params.addRule(RelativeLayout.CENTER_IN_PARENT);
                added.setLayoutParams(params);
            }
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

}
