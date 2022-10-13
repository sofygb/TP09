namespace TP09.Models
{
    public class Biblioteca
    {
        private int _IdBiblioteca;
        private int _IdUsuario;
        private string _Proxima;
        private string _Leyendo;
        private string _Leido;

        public Biblioteca() {}

        public Biblioteca(int IdBiblioteca, int IdUsuario, string Proxima, string Leyendo, string Leido){
            _IdBiblioteca = IdBiblioteca;
            _IdUsuario = IdUsuario;
            _Proxima = Proxima;
            _Leyendo = Leyendo;
            _Leido = Leido;
        }

        public int IdBiblioteca{
            get {return _IdBiblioteca;}
            set {_IdBiblioteca = value;}
        }
        
        public int IdUsuario{
            get {return _IdUsuario;}
            set {_IdUsuario = value;}
        }
        public string Proxima{
            get {return _Proxima;}
            set {_Proxima = value;}
        }
        public string Leyendo{
            get {return _Leyendo;}
            set {_Leyendo = value;}
        }
        public string Leido{
            get {return _Leido;}
            set {_Leido = value;}
        }
    }
}