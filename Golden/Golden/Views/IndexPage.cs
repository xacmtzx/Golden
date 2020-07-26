using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Golden.Views
{
    public class IndexPage : ContentPage
    {
        public IndexPage()
        {
            this.Title = "Selecciona una Opción";

            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Agrega un libro";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Ver libros guardados";
            button.Clicked += Button_Get_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Editar Libros";
            button.Clicked += Button_Edit_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Eliminar Libros";
            button.Clicked += Button_Delete_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;


        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBookPage());
        }
        private async void Button_Get_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetAllBookPage());
        }

        private async void Button_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditBookPage());
        }

        private async void Button_Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteBookPage());
        }
    }
}