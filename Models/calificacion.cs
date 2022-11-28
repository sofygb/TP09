namespace TP09.Models
{
    public class calificacion
    {
        private int _IdCalificacion;
        private int _IdLibro;
        private string _Comentarios;
        private int _Estrellas;
        private int _IdUsuario;

        public calificacion() {}

        public calificacion(int IdCalificacion, string Comentarios, int Estrellas, int IdUsuario, int IdLibro){
            _IdCalificacion = IdCalificacion;
            _Comentarios = Comentarios;
            _Estrellas = Estrellas;
            _IdLibro = IdLibro;
            _IdUsuario = IdUsuario;
        }
        public int IdLibro{
            get {return _IdLibro;}
            set {_IdLibro = value;}
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
        public int IdUsuario{
            get {return _IdUsuario;}
            set {_IdUsuario = value;}
        }

    }
}