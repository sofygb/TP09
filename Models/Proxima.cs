namespace TP09.Models
{
    public class Proxima
    {
        private int _IdProxima;
        private int _IdLibro;

        public Proxima() {}

        public Proxima(int _IdProxima, int IdLibro){
            _IdProxima = IdProxima;
            _IdLibro = IdLibro;
        }

        public int IdProxima{
            get {return _IdProxima;}
            set {_IdProxima = value;}
        }
        public int IdLibro{
            get {return _IdLibro;}
            set {_IdLibro = value;}
        }

    }
}