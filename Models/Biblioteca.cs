namespace TP09.Models
{
    public class Biblioteca
    {
        private int _IdBiblioteca;
        private int _IdUsuario;
        private string _IdLibro;

        public Biblioteca() {}

        public Biblioteca(int IdBiblioteca, int IdUsuario, string IdLibro){
            _IdBiblioteca = IdBiblioteca;
            _IdUsuario = IdUsuario;
            _IdLibro = IdLibro;
        }

        public int IdBiblioteca{
            get {return _IdBiblioteca;}
            set {_IdBiblioteca = value;}
        }
        
        public int IdUsuario{
            get {return _IdUsuario;}
            set {_IdUsuario = value;}
        }
        public string IdLibro{
            get {return _IdLibro;}
            set {_IdLibro = value;}
        }
    }
}