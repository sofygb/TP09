namespace TP09.Models
{
    public class Libro
    {
        private int _IdLibro;
        private string _Nombre;
        private string _Portada;
        private string _Contraportada;
        private string _Autor;
        private int _CantPaginas;
        private string _Descripción;
        private string _TW;
        private int _CantLibros;
        private string _Generos;
        private string _Categoria;
        private int _IdCalificacion;
        private int _IdGuardar;
        private bool _Guardar;
        private string _GeneroPrincipal;

        public Libro() {}

        public Libro(int IdLibro, string Nombre, string Portada,string Contraportada, string Autor, int CantPaginas, string Descripción, string TW, int CantLibros, string Generos, string _GeneroPrincipal, string Categoria, int IdCalificacion, int IdGuardar, bool Guardar){
            _IdLibro = IdLibro;
            _Nombre = Nombre;
            _Portada = Portada;
            _Contraportada = Contraportada;
            _Autor = Autor;
            _CantPaginas = CantPaginas;
            _Descripción = Descripción;
            _TW = TW;
            _CantLibros = CantLibros;
            _Generos = Generos;
            _Categoria = Categoria;
            _IdCalificacion = IdCalificacion;
            _IdGuardar = IdGuardar;
            _Guardar = Guardar;
            _GeneroPrincipal = GeneroPrincipal;
        }

        public int IdLibro{
            get {return _IdLibro;}
            set {_IdLibro = value;}
        }
        public string Nombre{
            get {return _Nombre;}
            set {_Nombre = value;}
        }
        public string Portada{
            get {return _Portada;}
            set {_Portada = value;}
        }
        public string Contraportada{
            get {return _Contraportada;}
            set {_Contraportada = value;}
        }
        public string Autor{
            get {return _Autor;}
            set {_Autor = value;}
        }
        public int CantPaginas{
            get {return _CantPaginas;}
            set {_CantPaginas = value;}
        }
        public string Descripción{
            get {return _Descripción;}
            set {_Descripción = value;}
        }
        public string TW{
            get {return _TW;}
            set {_TW = value;}
        }
        public int CantLibros{
            get {return _CantLibros;}
            set {_CantLibros = value;}
        }
        public string Generos{
            get {return _Generos;}
            set {_Generos = value;}
        }
        public string Categoria{
            get {return _Categoria;}
            set {_Categoria = value;}
        }
        public int IdCalificacion{
            get {return _IdCalificacion;}
            set {_IdCalificacion = value;}
        }
        
        public int IdGuardar{
            get {return _IdGuardar;}
            set {_IdGuardar = value;}
        }
        public bool Guardar{
            get {return _Guardar;}
            set {_Guardar = value;}
        }
        public string GeneroPrincipal{
            get {return _GeneroPrincipal;}
            set {_GeneroPrincipal = value;}
        }

    }
}