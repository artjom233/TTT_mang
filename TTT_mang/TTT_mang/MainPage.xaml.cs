using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TTT_mang
{
    public partial class MainPage : ContentPage
    {
        Grid grid4x1, grid3x3;
        Button uus_mang, esimene, teema;
       // BoxView b;
        Image cross, round, ime;
        Random rnd;
        Color color;
        int[,] T = new int[3, 3];
        bool esi =false;
        public MainPage()
        {
            color = new Color();
           // color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            grid4x1 = new Grid
            {
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {

                    new RowDefinition { Height = new GridLength(3, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions=
                {
                new ColumnDefinition { Width=new GridLength(1,GridUnitType.Star)}
            }
            };
            //Uus_mang();
            uus_mang = new Button()
            {
                Text = "UUS MANG"
            };
            uus_mang.Clicked += Uus_mang_Clicked;
            esimene = new Button()
            {
                Text = "Kes on esimene"
            };
            esimene.Clicked += Esimene_Clicked;
            teema = new Button()
            {
                Text = "Teema"
            };
            teema.Clicked += Teema_Clicked;
            
            grid4x1.Children.Add(uus_mang, 0, 1);
            grid4x1.Children.Add(esimene,0, 2);
            grid4x1.Children.Add(teema, 0, 3);
            Content = grid4x1;
        }
        int voit = 0;
        //00 10 20
        //01 11 21
        //02 12 22

        //00 01 02
        //10 11 12
        //20 21 22

        //00 11 22
        //02 11 20
        public int Kontroll()
        {
            if (T[0,0]==1 && T[1,0]==1 && T[2,0]==1 || T[0, 1] == 1 && T[1, 1] == 1 && T[2, 1] == 1 || T[0, 2] == 1 && T[1, 2] == 1 && T[2, 2] == 1)
            {
                voit = 1;
            }
            else if (T[0, 0] == 1 && T[0, 1] == 1 && T[0, 2] == 1 || T[1, 0] == 1 && T[1, 1] == 1 && T[1, 2] == 1 || T[2, 0] == 1 && T[2, 1] == 1 && T[2, 2] == 1)
            {
                voit = 1;
            }
            else if (T[0, 0] == 1 && T[1, 1] == 1 && T[2, 2] == 1 || T[0, 2] == 1 && T[1, 1] == 1 && T[2, 0] == 1)
            {
                voit = 1;
            }
            else if (T[0, 0] == 2 && T[1, 0] == 2 && T[2, 0] == 2 || T[0, 1] == 2 && T[1, 1] == 2 && T[2, 1] == 2 || T[0, 2] == 2 && T[1, 2] == 2 && T[2, 2] == 2)
            {
                voit = 2;
            }
            else if (T[0, 0] == 2 && T[0, 1] == 2 && T[0, 2] == 2 || T[1, 0] == 2 && T[1, 1] == 2 && T[1, 2] == 2 || T[2, 0] == 2 && T[2, 1] == 2 && T[2, 2] == 2)
            {
                voit = 2;
            }
            else if (T[0, 0] == 2 && T[1, 1] == 2 && T[2, 2] == 2 || T[0, 2] == 2 && T[1, 1] == 2 && T[2, 0] == 2)
            {
                voit = 2;
            }
            else if (T[0,0] != 0 && T[0, 1] != 0 && T[0, 2] != 0 && T[1, 0] != 0 && T[1, 2] != 0 && T[1, 1] != 0 && T[2, 0] != 0 && T[2, 1] != 0 && T[2, 2] != 0)
            {
                voit = 3;
            }
            return voit;
        }
        public void Lopp()
        {
            voit = Kontroll();
            if(voit==1)
            {
                DisplayAlert("Victory", "N1", "OK");

            }
            else if (voit==2)
            {
                DisplayAlert("Victory", "N2", "OK");
            }
            else if (voit==3)
            {
                DisplayAlert("None", "None", "OK");
            }
        }

        int r = 0, g = 0, b = 0;
        private void Teema_Clicked(object sender, EventArgs e)
        {
            rnd = new Random();
            grid3x3.BackgroundColor = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));

        }

        private async void Esimene_Clicked(object sender, EventArgs e)
        {
            Kes_esimene();
        }
        public async void Kes_esimene()
            {
            string e_valik = await DisplayPromptAsync("Kes on esimene", "Tee oma valik 1-cross,2-round", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (e_valik == "1")
            {
                esi = true;
            }
            else
            {
                esi = false;
            }
        }

        private void Uus_mang_Clicked(object sender, EventArgs e)
        {
            Kes_esimene();
            Uus_mang();

        }

        public void Uus_mang()
        {
            grid3x3 = new Grid
            {
                BackgroundColor = Color.Aqua,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {

                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                   new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                   new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                new ColumnDefinition { Width=new GridLength(3,GridUnitType.Star)},
                new ColumnDefinition { Width=new GridLength(3,GridUnitType.Star)},
                new ColumnDefinition { Width=new GridLength(3,GridUnitType.Star)},
            }
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                  //  b = new BoxView { Color = Color.Black };
                   ime = new Image { Source = "B.jpg" };
                    //round = new Image { Source = "round.png" };
                    grid3x3.Children.Add(ime, j, i);
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    ime.GestureRecognizers.Add(tap);
                    T[j, i] = 0;
                    voit = 0;
                }
            }
            grid4x1.Children.Add(grid3x3, 0, 0);
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
             var ime = (Image)sender;
            //var b = (BoxView)sender;
            var r = Grid.GetRow(ime);
            var c = Grid.GetColumn(ime);
            if (esi)
            {
                 ime.Source = "cross.png";
               // b.Color = Color.Red;
                esi = false;
                T[r, c] = 1;
            }
            else
            {
                  ime.Source = "round.png";
               // b.Color = Color.Yellow;
                esi = true;
                T[r, c] = 2;
            }
            Lopp();
        }
    }
}
