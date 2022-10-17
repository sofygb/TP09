namespace TP09.Models
{
    public class Leido
    {
        private int _IdLeido;
        private int _IdLibro;

        public Leido() {}

        public Leido(int IdLeido, int IdLibro){
            _IdLeido = IdLeido;
            _IdLibro = IdLibro;
        }

        public int IdLeido{
            get {return _IdLeido;}
            set {_IdLeido = value;}
        }
        public int IdLibro{
            get {return _IdLibro;}
            set {_IdLibro = value;}
        }

    }
}