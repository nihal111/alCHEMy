using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238



namespace alCHEMy
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        List<string> compounds = new List<string>() {
                            "HCl",
                            "NaOH",
                            "NaCl",
                            "H2O",
                            "KOH",
                            "H2SO4",
                            "Ca(OH)2",
                            "NaHCO3",
                            "C",
                            "CaO",
                            "CaCO3",
                            "CO2",
                            "O2",
                            "Br2",
                            "FeSO4",
                            "Fe",
                            "Cu",
                            "AgNO3",
                            "Ag",
                            "Mg",
                            "ZnSO4",
                            "Zn",
                            "Fe2O3",
                            "KI",
                            "Cl2",
                            "I2",
                            "KCl",
                            "Cu(NO3)2",
                            "CuSO4",
                            "MgSO4",
                            "Na",
                            "H2",
                            "Al",
                            "Al2O3",
                            "Na2SO4",
                            "Heat",
                            "Na2CO3",
                            "KI3",
                            "H2CO3",
                            "H2S",
                            "S",
                            "K2SO4",
                            "CaSO4",
                            "Fe2(SO4)3",
                            "HI",
                            "Al2(SO4)3"
                            };
        List<TextBox> textboxes = new List<TextBox>();
        int reactantcount = 0;
        int productcount = 0;
        int[] arr = new int[7];
        int[] reactants = new int[7];
        int[] products = new int[7];

        string[,] elements = new string[,]{
                            {"HCl","white"},
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
                            {"Br2","orange"},
                            {"FeSO4","green"},
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
                            {"Al2(SO4)3","white"}

                            };
        string[,] reactions= new string[,]{
                                { "100101","102103" },
                                {"116117","114116" },
                                {"115128","114116" }
                            };
        string[] colornames = { "white", "grey", "orange", "green", "red", "violet", "blue", "brown", "yellow", "silver" };
        int[,] colors = new int[,]
                            {
                                {255,255,255,255 },
                                {255,128,138,135 },
                                {255,255,165,0 },
                                {255,0,255,0 },
                                {255,255,0,0 },
                                {255,128,0,128 },
                                {255,0,0,255 },
                                {255,139,69,19 },
                                {255,255,255,0 },
                                {255,192,192,192 },
                            };

        string word = "";
        string input = "";
        int flag = 0;


        public MainPage()
        {
            this.InitializeComponent();
            centerbox.Visibility = Visibility.Collapsed;
            r1.Visibility = Visibility.Collapsed;
            r2.Visibility = Visibility.Collapsed;
            r3.Visibility = Visibility.Collapsed;
            r4.Visibility = Visibility.Collapsed;
            r5.Visibility = Visibility.Collapsed;
            r6.Visibility = Visibility.Collapsed;
            p1.Visibility = Visibility.Collapsed;
            p2.Visibility = Visibility.Collapsed;
            p3.Visibility = Visibility.Collapsed;
            p4.Visibility = Visibility.Collapsed;
            p5.Visibility = Visibility.Collapsed;
            p6.Visibility = Visibility.Collapsed;

            for (int i = 0; i < 7; i++)
            {
                arr[i]= 0;
                reactants[i] = 0;
            }

        }
        

    
        private void remove_Click(object sender, RoutedEventArgs e)
        {
            p1.Visibility = Visibility.Collapsed;
            p2.Visibility = Visibility.Collapsed;
            p3.Visibility = Visibility.Collapsed;
            p4.Visibility = Visibility.Collapsed;
            p5.Visibility = Visibility.Collapsed;
            p6.Visibility = Visibility.Collapsed;
            productcount = 0;
        }

     

        private void add_DropDownOpened(object sender, object e)
        {
            add.ItemsSource = compounds;
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {

            if (add.SelectedItem != null)
            {
                centerbox.Visibility = Visibility.Visible;
                string compound = add.SelectedItem.ToString();
                centerbox.Text = compound;
            }
            else
            {
                centerbox.Visibility = Visibility.Visible;
                centerbox.Text = "Add Reactant!";
            }

        }

        private SolidColorBrush findcolor(string compoundname)
        {
            int pos = compounds.IndexOf(compoundname);
            string colorname = elements[pos, 1];
            pos = Array.IndexOf(colornames, colorname);
            SolidColorBrush background= new SolidColorBrush(Windows.UI.Color.FromArgb((byte) colors[pos,0], (byte)colors[pos, 1], (byte)colors[pos, 2], (byte)colors[pos, 3]));
            return background;
        }

        private void moveleft_Click(object sender, RoutedEventArgs e)
        {
            if (reactantcount >= 6)
                centerbox.Text = "Full!";
            if (reactantcount < 6 && centerbox.Text == "Full!")
                centerbox.Text = "Add Reactant!";

            if ((r1.Visibility == Visibility.Visible && r1.Text == centerbox.Text) || (r2.Visibility == Visibility.Visible && r2.Text == centerbox.Text) || (r3.Visibility == Visibility.Visible && r3.Text == centerbox.Text) || (r3.Visibility == Visibility.Visible && r3.Text == centerbox.Text) || (r4.Visibility == Visibility.Visible && r4.Text == centerbox.Text) || (r5.Visibility == Visibility.Visible && r5.Text == centerbox.Text) || (r6.Visibility == Visibility.Visible && r6.Text == centerbox.Text))
                centerbox.Text = "Already Added!";

            else if (centerbox.Visibility == Visibility.Visible && centerbox.Text != "Add Reactant!" && centerbox.Text != "Already Added!" && centerbox.Text != "Full!" && reactantcount < 6)
            {
                for (int i = 1; i < 7; i++)
                {
                    if (arr[i] == 0)
                    {
                        switch (i)
                        {
                            case 1:
                                r1.Visibility = Visibility.Visible;
                                r1.Text = centerbox.Text;
                                r1.Background = findcolor(r1.Text);
                                centerbox.Visibility = Visibility.Collapsed;
                                arr[i] = 1;
                                break;
                            case 2:
                                r2.Visibility = Visibility.Visible;
                                r2.Text = centerbox.Text;
                                arr[i] = 1;
                                r2.Background = findcolor(r2.Text);
                                centerbox.Visibility = Visibility.Collapsed;
                                break;
                            case 3:
                                r3.Visibility = Visibility.Visible;
                                r3.Text = centerbox.Text;
                                arr[i] = 1;
                                r3.Background = findcolor(r3.Text);
                                centerbox.Visibility = Visibility.Collapsed;
                                break;
                            case 4:
                                r4.Visibility = Visibility.Visible;
                                r4.Text = centerbox.Text;
                                arr[i] = 1;
                                r4.Background = findcolor(r4.Text);
                                centerbox.Visibility = Visibility.Collapsed;
                                break;
                            case 5:
                                r5.Visibility = Visibility.Visible;
                                r5.Text = centerbox.Text;
                                arr[i] = 1;
                                r5.Background = findcolor(r5.Text);
                                centerbox.Visibility = Visibility.Collapsed;
                                break;
                            case 6:
                                r6.Visibility = Visibility.Visible;
                                r6.Text = centerbox.Text;
                                arr[i] = 1;
                                r6.Background = findcolor(r6.Text);
                                centerbox.Visibility = Visibility.Collapsed;
                                break;
                        }


                        break;
                    }
                }
                reactantcount++;



            }
            else if (centerbox.Visibility == Visibility.Collapsed)
            {
                centerbox.Visibility = Visibility.Visible;
                centerbox.Text = "Add Reactant!";
            }
            else if (reactantcount == 6)
            {
                centerbox.Visibility = Visibility.Visible;
                centerbox.Text = "Full!";
            }
            
        



        }

        private void r1_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            r1.Visibility = Visibility.Collapsed;
            arr[1] = 0;
            reactantcount--;
        }

        private void r2_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            r2.Visibility = Visibility.Collapsed;
            arr[2] = 0;
            reactantcount--;
        }

        private void r3_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            r3.Visibility = Visibility.Collapsed;
            arr[3] = 0;
            reactantcount--;
        }

        private void r4_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            r4.Visibility = Visibility.Collapsed;
            arr[4] = 0;
            reactantcount--;
        }

        private void r5_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            r5.Visibility = Visibility.Collapsed;
            arr[5] = 0;
            reactantcount--;
        }

        private void r6_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            r6.Visibility = Visibility.Collapsed;
            arr[6] = 0;
            reactantcount--;
        }
        private void p1_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {

        }

        private void p2_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {

        }

        private void p3_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {

        }

        private void p4_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {

        }

        private void p5_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {

        }

        private void p6_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {

        }

        private void react_Click(object sender, RoutedEventArgs e)
        {
            input = "";
            int r = 0;
            int i = 0;
            if (r1.Visibility == Visibility.Visible)
            {
                input = input + r1.Text + " ";
            }
            if (r2.Visibility == Visibility.Visible)
            {
                input = input + r2.Text + " ";
            }
            if (r3.Visibility == Visibility.Visible)
            {
                input = input + r3.Text + " ";
            }
            if (r4.Visibility == Visibility.Visible)
            {
                input = input + r4.Text + " ";
            }
            if (r5.Visibility == Visibility.Visible)
            {
                input = input + r5.Text + " ";
            }
            if (r6.Visibility == Visibility.Visible)
            {
                input = input + r6.Text + " ";
            }

            for (i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    word = word + input[i];
                }
                else {
                    int pos = compounds.IndexOf(word);
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
            string output = "";         //Output is ""

            for (i = 5; i >= 0; i--)
            {
                if (reactants[i] != 0)
                    output = output + reactants[i].ToString();  //Output is Reactant code
            }

            int reactionscount = reactions.Length / 2;

            for (i = 0; i < reactionscount; i++)
            {
                if (output == reactions[i, 0])
                {
                    output = reactions[i, 1];  //output is product code
                    flag = 1;
                    break;
                }
            }

            if (output != "" && flag==1)
            {


                while (output.Length > 0)
                {
                    products[productcount] = Int32.Parse(output.Substring(0, 3));
                    if (!((p1.Visibility == Visibility.Visible && p1.Text == elements[products[productcount] - 100,0]) || (p2.Visibility == Visibility.Visible && p2.Text == elements[products[productcount] - 100,0]) || (p3.Visibility == Visibility.Visible && p3.Text == elements[products[productcount] - 100,0]) || (p3.Visibility == Visibility.Visible && p3.Text == elements[products[productcount] - 100,0]) || (p4.Visibility == Visibility.Visible && p4.Text == elements[products[productcount] - 100,0]) || (p5.Visibility == Visibility.Visible && p5.Text == elements[products[productcount] - 100,0]) || (p6.Visibility == Visibility.Visible && p6.Text == elements[products[productcount] - 100,0])))
                    {

                        productcount++;
                        switch (productcount)
                        {
                            case 1:
                                p1.Visibility = Visibility.Visible;
                                p1.Text = elements[products[productcount - 1] - 100,0];
                                p1.Background = findcolor(p1.Text);
                                centerbox.Visibility = Visibility.Collapsed;
                                break;
                            case 2:
                                p2.Visibility = Visibility.Visible;
                                p2.Text = elements[products[productcount - 1] - 100,0];
                                p2.Background = findcolor(p2.Text);
                                centerbox.Visibility = Visibility.Collapsed;
                                break;
                            case 3:
                                p3.Visibility = Visibility.Visible;
                                p3.Text = elements[products[productcount - 1] - 100,0];
                                p3.Background = findcolor(p3.Text);
                                centerbox.Visibility = Visibility.Collapsed;
                                break;
                            case 4:
                                p4.Visibility = Visibility.Visible;
                                p4.Text = elements[products[productcount - 1] - 100,0];
                                p4.Background = findcolor(p4.Text);
                                centerbox.Visibility = Visibility.Collapsed;
                                break;
                            case 5:
                                p5.Visibility = Visibility.Visible;
                                p5.Text = elements[products[productcount - 1] - 100,0];
                                p5.Background = findcolor(p5.Text);
                                centerbox.Visibility = Visibility.Collapsed;
                                break;
                            case 6:
                                p6.Visibility = Visibility.Visible;
                                p6.Text = elements[products[productcount - 1] - 100,0];
                                p6.Background = findcolor(p6.Text);
                                centerbox.Visibility = Visibility.Collapsed;
                                break;
                        }
                       
                    }

                    output = output.Substring(3, output.Length - 3);
                }

            }

            for (i = 0; i < 7; i++)
            {
                reactants[i] = 0;
            }
            flag = 0;
        }

        private void remove_reactants_Click(object sender, RoutedEventArgs e)
        {   
            r1.Visibility = Visibility.Collapsed;
            r2.Visibility = Visibility.Collapsed;
            r3.Visibility = Visibility.Collapsed;
            r4.Visibility = Visibility.Collapsed;
            r5.Visibility = Visibility.Collapsed;
            r6.Visibility = Visibility.Collapsed;
            reactantcount = arr[0]=arr[1]=arr[2]=arr[3]=arr[4]=arr[5]=arr[6]=0;
        }
    }
}
