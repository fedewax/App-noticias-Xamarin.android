using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ClaseNoticias.Data;
using ClaseNoticias.Models;

namespace ClaseNoticias.Services
{
    public class Servicios
    {
        private Repositorio _newsRepository;

        public Servicios()
        {
            _newsRepository = new Repositorio();
        }

        public List<NuevaNoticia> GetNuevaNoticia()
        {
            return _newsRepository.GetNuevaNoticia();
        }

        public NuevaNoticia GetNuevaNoticiaById(int Id)
        {
            return _newsRepository.GetNuevaNoticiaById(Id);
        }
    }
}