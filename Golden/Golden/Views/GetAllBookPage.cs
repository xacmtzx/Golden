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
    public class GetAllBookPage : ContentPage
    {
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public GetAllBookPage()
        {
            this.Title = "Libros";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Libro>().OrderBy(x => x.Nombre).ToList();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;

        }
    }
}