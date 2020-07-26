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
    public class AddBookPage : ContentPage
    {
        private Entry _nombreEntry;
        private Entry _autorEntry;
        private Entry _editorialEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");


        public AddBookPage()
        {
            this.Title = "Agragar Libro";
            StackLayout stackLayout = new StackLayout();

            _nombreEntry = new Entry();
            _nombreEntry.Keyboard = Keyboard.Text;
            _nombreEntry.Placeholder = "Nombre del Libro";
            stackLayout.Children.Add(_nombreEntry);


            _autorEntry = new Entry();
            _autorEntry.Keyboard = Keyboard.Text;
            _autorEntry.Placeholder = "Autor del Libro";
            stackLayout.Children.Add(_autorEntry);

            _editorialEntry = new Entry();
            _editorialEntry.Keyboard = Keyboard.Text;
            _editorialEntry.Placeholder = "Editorial del Libro";
            stackLayout.Children.Add(_editorialEntry);

            _saveButton = new Button();
            _saveButton.Text = "Añadir";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;


        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Libro>();

            var maxPK = db.Table<Libro>().OrderByDescending(c => c.Id).FirstOrDefault();

            Libro libro = new Libro()
            {
                Id = (maxPK == null ? 1 : maxPK.Id + 1),
                Nombre = _nombreEntry.Text,
                Autor = _autorEntry.Text,
                Editorial = _editorialEntry.Text
            };

            db.Insert(libro);
            await DisplayAlert(null, libro.Nombre + " Guardado", "Ok");
            await Navigation.PopAsync();
        }
    }
}