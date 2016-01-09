package com.arpan.laptop.alchemy;

import android.content.Context;
import android.opengl.Visibility;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.TextView;

import org.lucasr.twowayview.TwoWayView;

import java.lang.reflect.Array;
import java.util.Arrays;

public class MainActivity extends AppCompatActivity{

    TwoWayView listView;
    Context context;
    String item;
    TextView tv1,tv2,tv3,tv4,tv5,tv6,p1,p2,p3,p4,p5,p6;
    Button compound;
    int[] arr = new int[7];
    int[] reactants = new int[7];
    int[] products = new int[7];
    int no_of_reactants=0;
    int flag=0;
    int productcount=0;
    String[] compounds = new String[]{"HCl", "NaOH", "NaCl", "H2O", "KOH", "H2SO4"
            , "Ca(OH)2", "NaHCO3", "NaOCl", "CaO", "CaCO3"
            , "CO2", "O2", "KMnO4", "FeSO4", "Fe", "Cu", "AgNO3"
            , "Ag", "Mg", "ZnSO4", "Zn", "Fe2O3", "KI", "Cl2"
            , "I2", "KCl", "Cu(NO3)2", "CuSO4", "MgSO4", "Na"
            , "H2", "Al", "Al2O3"};
    String[][] elements = { {" HCl","white "},
            {"NaOH","white"},
            {"NaCl","white"},
            {"H2O","white"},
            {"KOH","white"},
            {"H2SO4","white"},
            {"Ca(OH)2","white"},
            {"NaHCO3","white"},
            {"C","grey"},
            {"CaO","white"},
            {"CaCO3","white"},
            {"CO2","white"},
            {"O2","white"},
            {"Br2","Orange"},
            {"FeSO4","Green"},
            {"Fe","grey"},
            {"Cu","orange"},
            {"AgNO3","white"},
            {"Ag","silver"},
            {"Mg","grey"},
            {"ZnSO4","white"},
            {"Zn","grey"},
            {"Fe2O3","red"},
            {"KI","white"},
            {"Cl2","green"},
            {"I2","violet"},
            {"KCl","white"},
            {"Cu(NO3)2","blue"},
            {"CuSO4","blue"},
            {"MgSO4","white"},
            {"Na","silver"},
            {"H2","white"},
            {"Al","silver"},
            {"Al2O3","white"},
            {"Na2SO4","white"},
            {"Heat","red"},
            {"Na2CO3","white"},
            {"KI3","brown"},
            {"H2CO3","white"},
            {"H2S","white"},
            {"S","yellow"},
            {"K2SO4","white"},
            {"CaSO4","white"},
            {"Fe2(SO4)3","yellow"},
            {"HI","white"},
            {"Al2(SO4)3","white"}};
    String[][] reactions= {
        { "100101","102103"},
        {"116117","114116"},
        {"115128","114116"}
    };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        context=this;
        setContentView(R.layout.activity_main);
        for(int i=0 ; i<7 ; i++)
        {
            arr[i]=0;
        }
        tv1=(TextView)findViewById(R.id.textView1);
        tv2=(TextView)findViewById(R.id.textView2);
        tv3=(TextView)findViewById(R.id.textView3);
        tv4=(TextView)findViewById(R.id.textView4);
        tv5=(TextView)findViewById(R.id.textView5);
        tv6=(TextView)findViewById(R.id.textView6);
        p1=(TextView)findViewById(R.id.textView7);
        p2=(TextView)findViewById(R.id.textView8);
        p3=(TextView)findViewById(R.id.textView9);
        p4=(TextView)findViewById(R.id.textView10);
        p5=(TextView)findViewById(R.id.textView11);
        p6=(TextView)findViewById(R.id.textView12);
        compound = (Button)findViewById(R.id.compound);
        compound.setEnabled(false);
        ArrayAdapter<String> compoundAdapter = new ArrayAdapter<>(this, R.layout.compound_list_item, compounds);
        listView = (TwoWayView)findViewById(R.id.lvItems);
        listView.setAdapter(compoundAdapter);
        listView.bringToFront();
        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, final View view, int position, long id) {
                item = ((TextView) view).getText().toString();
                compound.setEnabled(true);
                compound.setVisibility(View.VISIBLE);
                compound.setText(item);
                compound.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) { //TODO:loop through all to find lowest unoccupied index
                        for (int i = 1; i < 7; i++) {
                            if (arr[i] == 0) {
                                switch (i) {
                                    case 1:
                                        tv1.setVisibility(View.VISIBLE);
                                        tv1.setText(item);
                                        v.setVisibility(View.INVISIBLE);
                                        v.setEnabled(false);
                                        arr[i] = 1;
                                        break;
                                    case 2:
                                        tv2.setVisibility(View.VISIBLE);
                                        tv2.setText(item);
                                        v.setVisibility(View.INVISIBLE);
                                        v.setEnabled(false);
                                        arr[i] = 1;
                                        break;
                                    case 3:
                                        tv3.setVisibility(View.VISIBLE);
                                        tv3.setText(item);
                                        v.setVisibility(View.INVISIBLE);
                                        v.setEnabled(false);
                                        arr[i] = 1;
                                        break;
                                    case 4:
                                        tv4.setVisibility(View.VISIBLE);
                                        tv4.setText(item);
                                        v.setVisibility(View.INVISIBLE);
                                        v.setEnabled(false);
                                        arr[i] = 1;
                                        break;
                                    case 5:
                                        tv5.setVisibility(View.VISIBLE);
                                        tv5.setText(item);
                                        v.setVisibility(View.INVISIBLE);
                                        v.setEnabled(false);
                                        arr[i] = 1;
                                        break;
                                    case 6:
                                        tv6.setVisibility(View.VISIBLE);
                                        tv6.setText(item);
                                        v.setVisibility(View.INVISIBLE);
                                        v.setEnabled(false);
                                        arr[i] = 1;
                                        break;
                                }
                                break;
                            }
                        }
                    }
                });
            }
        });

    }

    public void removeFromBeaker(View v)
    {
        v.setVisibility(View.INVISIBLE);
        switch(v.getId())
        {
            case R.id.textView1:
                reactants[1]=0;
                arr[1]=0;
                break;
            case R.id.textView2:
                reactants[2]=0;
                arr[2]=0;
                break;
            case R.id.textView3:
                reactants[3]=0;
                arr[3]=0;
                break;
            case R.id.textView4:
                reactants[4]=0;
                arr[4]=0;
                break;
            case R.id.textView5:
                reactants[5]=0;
                arr[5]=0;
                break;
            case R.id.textView6:
                reactants[6]=0;
                arr[6]=0;
                break;
        }
        no_of_reactants-=1;
    }

    public void React(View v)
    {
        String input = "";
        String word = "";
        int r = 0;
        int i = 0;
        if (tv1.getVisibility()==View.VISIBLE)
        {
            input = input + tv1.getText().toString() + " ";
        }
        if (tv2.getVisibility()==View.VISIBLE)
        {
            input = input + tv2.getText().toString() + " ";
        }
        if (tv3.getVisibility()==View.VISIBLE)
        {
            input = input + tv3.getText().toString() + " ";
        }
        if (tv4.getVisibility()==View.VISIBLE)
        {
            input = input + tv4.getText().toString() + " ";
        }
        if (tv5.getVisibility()==View.VISIBLE)
        {
            input = input + tv5.getText().toString() + " ";
        }
        if (tv6.getVisibility()==View.VISIBLE)
        {
            input = input + tv6.getText().toString() + " ";
        }
        for (i = 0; i < input.length(); i++)
        {
            if (input.charAt(i) != ' ')
            {
                word = word + input.charAt(i);
            }
            else {
                int pos = Arrays.asList(elements).indexOf(word);
                if (pos > -1)
                {
                    pos = pos + 100;
                    reactants[r] = pos;
                    r++;

                }
                word = "";
            }
        }

        int j, key, numLength = 6;

        for (j = 1; j < numLength; j++)    // Start with 1 (not 0)
        {
            key = reactants[j];
            for (i = j - 1; (i >= 0) && (reactants[i] < key); i--)   // Smaller values move up
            {
                reactants[i + 1] = reactants[i];
            }
            reactants[i + 1] = key;    //Put key into its proper location
        }
        String output = "";         //Output is ""

        for (i = 5; i >= 0; i--)
        {
            if (reactants[i] != 0)
                output = output + Integer.toString(reactants[i]);  //Output is Reactant code
        }

        int reactionscount = reactions.length / 2;

        for (i = 0; i < reactionscount; i++)
        {
            if (output.equals(reactions[i][0]))
            {
                output = reactions[i][1];  //output is product code
                compound.setText(output);
                compound.setVisibility(View.VISIBLE);
                flag = 1;
                break;
            }
        }

        if (!(output.equals("") && flag==1))
        {
            while (output.length() > 0)
            {
                products[productcount] = Integer.parseInt(output.subSequence(0, 3).toString());
                if (!((p1.getVisibility()==View.VISIBLE && p1.getText().toString().equals(elements[products[productcount] - 100][0])) || (p2.getVisibility()==View.VISIBLE && p2.getText().toString().equals(elements[products[productcount] - 100][0])) || (p3.getVisibility()==View.VISIBLE && p3.getText().toString().equals(elements[products[productcount] - 100][0])) || (p4.getVisibility()==View.VISIBLE && p4.getText().toString().equals(elements[products[productcount] - 100][0])) || (p5.getVisibility()==View.VISIBLE && p5.getText().toString().equals(elements[products[productcount] - 100][0])) || (p6.getVisibility()==View.VISIBLE && p6.getText().toString().equals(elements[products[productcount] - 100][0]))))
                {

                    productcount++;
                    switch (productcount)
                    {
                        case 1:
                            p1.setVisibility(View.VISIBLE);
                            p1.setText(elements[products[productcount - 1] - 100][0]);
                            break;
                        case 2:
                            p2.setVisibility(View.VISIBLE);
                            p2.setText(elements[products[productcount - 1] - 100][0]);
                            compound.setVisibility(View.INVISIBLE);
                            break;
                        case 3:
                            p3.setVisibility(View.VISIBLE);
                            p3.setText(elements[products[productcount - 1] - 100][0]);
                            compound.setVisibility(View.INVISIBLE);
                            break;
                        case 4:
                            p4.setVisibility(View.VISIBLE);
                            p4.setText(elements[products[productcount - 1] - 100][0]);
                            compound.setVisibility(View.INVISIBLE);
                            break;
                        case 5:
                            p5.setVisibility(View.VISIBLE);
                            p5.setText(elements[products[productcount - 1] - 100][0]);
                            compound.setVisibility(View.INVISIBLE);
                            break;
                        case 6:
                            p6.setVisibility(View.VISIBLE);
                            p6.setText(elements[products[productcount - 1] - 100][0]);
                            compound.setVisibility(View.INVISIBLE);
                            break;
                    }

                }

                output = output.subSequence(3, output.length()).toString();
            }

        }

        for (i = 0; i < 7; i++)
        {
            reactants[i] = 0;
        }
        flag = 0;
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
