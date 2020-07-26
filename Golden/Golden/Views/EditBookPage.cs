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
    public class EditBookPage : ContentPage
    {
        private ListView listView;
        private Entry _idEntry;
        private Entry _nombreEntry;
        private Entry _autorEntry;
        private Entry _editorialEntry;
        private Button _saveButton;

        Libro _libro = new Libro();
        
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");


        public EditBookPage()
        {
            this.Title = "Editar libro";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Libro>().OrderBy(x => x.Nombre).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idEntry = new Entry();
            _idEntry.Placeholder = "ID";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

            _nombreEntry = new Entry();
            _nombreEntry.Keyboard = Keyboard.Text;
            _nombreEntry.Placeholder = "Nombre del libro";
            stackLayout.Children.Add(_nombreEntry);

            _autorEntry = new Entry();
            _autorEntry.Keyboard = Keyboard.Text;
            _autorEntry.Placeholder = "Nombre del Autor";
            stackLayout.Children.Add(_autorEntry);

            _editorialEntry = new Entry();
            _editorialEntry.Keyboard = Keyboard.Text;
            _editorialEntry.Placeholder = "Nombre de la editorial";
            stackLayout.Children.Add(_editorialEntry);
                
            _saveButton = new Button();
            _saveButton.Text = "Actualizar";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            Libro libro = new Libro()
            {
                Id = Convert.ToInt32(_idEntry.Text),
                Nombre = _nombreEntry.Text,
                Autor = _autorEntry.Text,
                Editorial = _editorialEntry.Text
            };
            db.Update(libro);
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _libro = (Libro)e.SelectedItem;
            _idEntry.Text = _libro.Id.ToString();
            _nombreEntry.Text = _libro.Nombre;
            _autorEntry.Text = _libro.Autor;
            _editorialEntry.Text = _libro.Editorial;
        }
    }
}