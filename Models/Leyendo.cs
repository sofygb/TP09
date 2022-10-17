namespace TP09.Models
{
    public class Leyendo
    {
        private int _IdLeyendo;
        private int _IdLibro;

        public Leyendo() {}

        public Leyendo(int IdLeyendo, int IdLibro){
            _IdLeyendo = IdLeyendo;
            _IdLibro = IdLibro;
        }

        public int IdLeyendo{
            get {return _IdLeyendo;}
            set {_IdLeyendo = value;}
        }
        public int IdLibro{
            get {return _IdLibro;}
            set {_IdLibro = value;}
        }

    }
}