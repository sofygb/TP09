namespace TP09.Models
{
    public class Biblioteca
    {
        private int _IdBiblioteca;
        private int _IdUsuario;
        private string _IdProxima;
        private string _IdLeyendo;
        private string _IdLeido;

        public Biblioteca() {}

        public Biblioteca(int IdBiblioteca, int IdUsuario, string IdProxima, string IdLeyendo, string IdLeido){
            _IdBiblioteca = IdBiblioteca;
            _IdUsuario = IdUsuario;
            _IdProxima = IdProxima;
            _IdLeyendo = IdLeyendo;
            _IdLeido = IdLeido;
        }

        public int IdBiblioteca{
            get {return _IdBiblioteca;}
            set {_IdBiblioteca = value;}
        }
        
        public int IdUsuario{
            get {return _IdUsuario;}
            set {_IdUsuario = value;}
        }
        public string IdProxima{
            get {return _IdProxima;}
            set {_IdProxima = value;}
        }
        public string IdLeyendo{
            get {return _IdLeyendo;}
            set {_IdLeyendo = value;}
        }
        public string IdLeido{
            get {return _IdLeido;}
            set {_IdLeido = value;}
        }
    }
}