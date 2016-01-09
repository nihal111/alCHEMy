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
        string[,] names = { {"Hydrogen Chloride","HCl"},{"Sodium Hydroxide","NaOH"},
                            {"Sodium Chloride","NaCl"},{"Water","H2O"},
                            {"Potassium Hydroxide","KOH"},{"Sulphuric Acid/Hydrogen Sulphate","H2SO4"},
                            {"Calcium Hydroxide","Ca(OH)2"},{"Sodium Hydrogen Carbonate/Sodium bicarbonate/Baking Soda","NaHCO3"},
                            {"Sodium Hypochlorite/Hydrogen Peroxide","NaOCl"},{"Calcium Oxide","CaO"},
                            {"Calcium Carbonate","CaCO3"},{"Carbon Dioxide","CO2"},
                            {"Oxygen","O2"},{"Potassium Permanganate","KMNO4"},
                            {"Ferrous Sulphate","FeSO4"},{"Iron","Fe"},{"Copper","Cu"},
                            {"Silver Nitrate","AgNO3"},{"Silver","Ag"},{"Magnesium","Mg"},
                            {"Zinc Sulphate","ZnSO4"},{"Zinc","Zn"},{"Ferric Oxide","Fe2O3"},
                            {"Potassium Iodide","KI"},{"Chlorine","Cl2"},{"I2","Iodine"},
                            {"Potassium Chloride","KCl"},{"Copper Nitrate","Cu(NO3)2"},
                            {"Copper Sulphate","CuSO4"},{"Magnesium Sulphate","MgSO4"},
                            {"Sodium","Na"},{"Hydrogen","H2"},{"Aluminium","Al"},
                            {"Aluminum Oxide","Al2O3"}
                        };

        List<string> compounds = new List<string>() { "HCl","NaOH","NaCl","H2O","KOH","H2SO4"
                            ,"Ca(OH)2","NaHCO3","NaOCl","CaO","CaCO3"
                            ,"CO2","O2","KMNO4","FeSO4","Fe","Cu","AgNO3"
                            ,"Ag","Mg","ZnSO4","Zn","Fe2O3","KI","Cl2"
                            ,"I2","KCl","Cu(NO3)2","CuSO4","MgSO4","Na"
                            ,"H2","Al","Al2O3"
                            };



        public MainPage()
        {
            this.InitializeComponent();
        }
        

    
        private void remove_Click(object sender, RoutedEventArgs e)
        {

        }

     

        private void add_DropDownOpened(object sender, object e)
        {
            add.ItemsSource = compounds;
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
