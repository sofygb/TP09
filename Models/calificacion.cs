namespace TP_09.Models
{
    public class calificacion
    {
        private int _IdCalificacion;
        private string _Comentarios;
        private int _Estrellas;

        public calificacion() {}

        public calificacion(int IdCalificacion, string Comentarios, int _Estrellas){
            _IdCalificacion = IdCalificacion;
            _Comentarios = Comentarios;
            _Estrellas = Estrellas;
        }

        public int IdCalificacion{
            get {return _IdCalificacion;}
            set {_IdCalificacion = value;}
        }
        public string Comentarios{
            get {return _Comentarios;}
            set {_Comentarios = value;}
        }
        public int Estrellas{
            get {return _Estrellas;}
            set {_Estrellas = value;}
        }

    }
}