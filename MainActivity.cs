using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using ClaseNoticias.Services;
using Square.Picasso;
using Android.Graphics;





namespace App1Noticas
{
    
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
  
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Aqui estamos haciendo referencia l actitvity main de la carpeta layout
            SetContentView(Resource.Layout.activity_main);

            var servicio = new Servicios();
            var noticia = servicio.GetNuevaNoticiaById(1);

            var objTitulo = FindViewById<TextView>(Resource.Id.textTitulo);
            var objImagen = FindViewById<ImageView>(Resource.Id.imagenNoticia);
            var objNoticia = FindViewById<TextView>(Resource.Id.textNoticia);

            var display = WindowManager.DefaultDisplay;

            Point point = new Point();
            display.GetSize(point);

            var urlImagen = string.Concat(ServicioImagenes.imagenBaseUrl, noticia.Imagen);

            //cargar, redimencionar y meter imagen en el objeto 
            //no olvidar dar permisos para internet desde las prop del proyecto.
            Picasso.With(ApplicationContext)
                .Load(urlImagen)
                .Resize(point.X, 0)
                .Into(objImagen);

            objTitulo.Text = noticia.Titulo;
            objNoticia.Text = noticia.Contenido;
            
            //var icon = GetDrawable(Resource.Mipmap.ic_launcher);
            //objImagen.SetImageDrawable(icon);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}