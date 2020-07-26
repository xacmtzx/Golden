using Golden.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Golden.Views
{
    public class DeleteBookPage : ContentPage
    {
        private ListView _listView;
        private Button _button;

        Libro _libro = new Libro();
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public DeleteBookPage()
        {
            this.Title = "Eliminar libro";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Libro>().OrderBy(x => x.Nombre).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _button = new Button();
            _button.Text = "Eliminar libro";
            _button.Clicked += Button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;

        }
        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _libro = (Libro)e.SelectedItem;
        }

         private async void Button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<Libro>().Delete(x =>x.Id == _libro.Id);
            await Navigation.PopAsync();
        }
    }
}