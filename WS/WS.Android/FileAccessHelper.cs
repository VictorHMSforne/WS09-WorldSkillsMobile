using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WS.Droid
{
    public class FileAccessHelper
    {
        //Método para fazer com que o BD seja inseriro na pasta Personal do Celular e pegando de parâmetro o nome do BD
        public static string GetLocaFilePath(string fileName)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, fileName);
        }
    }
}